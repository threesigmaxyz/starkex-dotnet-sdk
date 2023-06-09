namespace StarkEx.Crypto.SDK.Hashing;

using Nethereum.Hex.HexConvertors.Extensions;
using Org.BouncyCastle.Math;
using StarkEx.Crypto.SDK.Enums;
using StarkEx.Crypto.SDK.Extensions;
using StarkEx.Crypto.SDK.Guards;
using StarkEx.Crypto.SDK.Models;

/// <inheritdoc />
public class SpotTradingMessageHasher : ISpotTradingMessageHasher
{
    private readonly IPedersenHash pedersenHash;

    /// <summary>
    /// Initializes a new instance of the <see cref="SpotTradingMessageHasher"/> class.
    /// </summary>
    /// <param name="pedersenHash">The <see cref="IPedersenHash"/> instance to use for performing cryptographic hashes.</param>
    public SpotTradingMessageHasher(IPedersenHash pedersenHash)
    {
        this.pedersenHash = pedersenHash;
    }

    /// <inheritdoc />
    public BigInteger EncodeLimitOrder(EncodeLimitOrderModel encodeLimitOrderModel)
    {
        Guards.NotNullOrEmptyOrWhitespace(encodeLimitOrderModel.AssetIdSold);
        Guards.NotInvalidHex(encodeLimitOrderModel.AssetIdSold, nameof(encodeLimitOrderModel.AssetIdSold));
        Guards.NotNullOrEmptyOrWhitespace(encodeLimitOrderModel.AssetIdBought);
        Guards.NotInvalidHex(encodeLimitOrderModel.AssetIdBought, nameof(encodeLimitOrderModel.AssetIdBought));
        Guards.NotNullOrEmptyOrWhitespace(encodeLimitOrderModel.AssetIdUsedForFees);
        Guards.NotInvalidHex(encodeLimitOrderModel.AssetIdUsedForFees, nameof(encodeLimitOrderModel.AssetIdUsedForFees));

        var fourthWeight = CalculateFourthWeight(
            encodeLimitOrderModel.QuantizedAmountSold,
            encodeLimitOrderModel.QuantizedAmountBought,
            encodeLimitOrderModel.QuantizedAmountUsedForFees,
            encodeLimitOrderModel.Nonce);

        var fifthWeight = CalculateFifthWeightForLimitOrderWithFees(
            OrderType.LimitOrderWithFees,
            encodeLimitOrderModel.VaultIdUsedForFees,
            encodeLimitOrderModel.VaultIdUsedForSelling,
            encodeLimitOrderModel.VaultIdUsedForBuying,
            encodeLimitOrderModel.ExpirationTimestamp);

        var firstInnerHash = pedersenHash.CreateHash(
            new BigInteger(encodeLimitOrderModel.AssetIdSold.RemoveHexPrefix(), 16),
            new BigInteger(encodeLimitOrderModel.AssetIdBought.RemoveHexPrefix(), 16));
        var secondInnerHash = pedersenHash.CreateHash(
            firstInnerHash,
            new BigInteger(encodeLimitOrderModel.AssetIdUsedForFees.RemoveHexPrefix(), 16));
        var thirdInnerHash = pedersenHash.CreateHash(secondInnerHash, fourthWeight);

        return pedersenHash.CreateHash(thirdInnerHash, fifthWeight);
    }

    /// <inheritdoc />
    public BigInteger EncodeTransfer(EncodeTransferModel encodeTransferModel)
    {
        Guards.NotNullOrEmptyOrWhitespace(encodeTransferModel.AssetIdSold);
        Guards.NotInvalidHex(encodeTransferModel.AssetIdSold, nameof(encodeTransferModel.AssetIdSold));
        Guards.NotNullOrEmptyOrWhitespace(encodeTransferModel.AssetIdUsedForFees);
        Guards.NotInvalidHex(encodeTransferModel.AssetIdUsedForFees, nameof(encodeTransferModel.AssetIdUsedForFees));
        Guards.NotNullOrEmptyOrWhitespace(encodeTransferModel.ReceiverStarkKey);
        Guards.NotInvalidHex(encodeTransferModel.ReceiverStarkKey, nameof(encodeTransferModel.ReceiverStarkKey));

        var fourthWeight = CalculateFourthWeight(
            encodeTransferModel.VaultIdFromSender,
            encodeTransferModel.VaultIdFromReceiver,
            encodeTransferModel.VaultIdUsedForFees,
            encodeTransferModel.Nonce);

        var fifthWeight = CalculateFifthWeightForTransferWithFees(
            OrderType.TransferWithFees,
            encodeTransferModel.QuantizedAmountToTransfer,
            encodeTransferModel.QuantizedAmountToLimitMaxFee,
            encodeTransferModel.ExpirationTimestamp);

        var firstInnerHash = pedersenHash.CreateHash(
            new BigInteger(encodeTransferModel.AssetIdSold.RemoveHexPrefix(), 16),
            new BigInteger(encodeTransferModel.AssetIdUsedForFees.RemoveHexPrefix(), 16));
        var secondInnerHash = pedersenHash.CreateHash(
            firstInnerHash,
            new BigInteger(encodeTransferModel.ReceiverStarkKey.RemoveHexPrefix(), 16));
        var thirdInnerHash = pedersenHash.CreateHash(secondInnerHash, fourthWeight);

        return pedersenHash.CreateHash(thirdInnerHash, fifthWeight);
    }

    /// <inheritdoc />
    public BigInteger EncodeConditionalTransfer(EncodeTransferModel encodeTransferModel)
    {
        Guards.NotNullOrEmptyOrWhitespace(encodeTransferModel.AssetIdSold);
        Guards.NotInvalidHex(encodeTransferModel.AssetIdSold, nameof(encodeTransferModel.AssetIdSold));
        Guards.NotNullOrEmptyOrWhitespace(encodeTransferModel.AssetIdUsedForFees);
        Guards.NotInvalidHex(encodeTransferModel.AssetIdUsedForFees, nameof(encodeTransferModel.AssetIdUsedForFees));
        Guards.NotNullOrEmptyOrWhitespace(encodeTransferModel.ReceiverStarkKey);
        Guards.NotInvalidHex(encodeTransferModel.ReceiverStarkKey, nameof(encodeTransferModel.ReceiverStarkKey));
        Guards.NotNull(encodeTransferModel.Fact);
        Guards.NotNull(encodeTransferModel.FactRegistryAddress);
        Guards.NotInvalidHex(encodeTransferModel.Fact, nameof(encodeTransferModel.Fact));
        Guards.NotInvalidHex(encodeTransferModel.FactRegistryAddress, nameof(encodeTransferModel.FactRegistryAddress));

        var condition = GetCondition(encodeTransferModel.Fact, encodeTransferModel.FactRegistryAddress);

        return EncodeConditionalTransfer(encodeTransferModel, condition.ToByteArray().ToHex());
    }

    /// <inheritdoc />
    public BigInteger EncodeConditionalTransfer(
        EncodeTransferModel encodeTransferModel,
        string condition)
    {
        Guards.NotNullOrEmptyOrWhitespace(encodeTransferModel.AssetIdSold);
        Guards.NotInvalidHex(encodeTransferModel.AssetIdSold, nameof(encodeTransferModel.AssetIdSold));
        Guards.NotNullOrEmptyOrWhitespace(encodeTransferModel.AssetIdUsedForFees);
        Guards.NotInvalidHex(encodeTransferModel.AssetIdUsedForFees, nameof(encodeTransferModel.AssetIdUsedForFees));
        Guards.NotNullOrEmptyOrWhitespace(encodeTransferModel.ReceiverStarkKey);
        Guards.NotInvalidHex(encodeTransferModel.ReceiverStarkKey, nameof(encodeTransferModel.ReceiverStarkKey));

        var fourthWeight = CalculateFourthWeight(
            encodeTransferModel.VaultIdFromSender,
            encodeTransferModel.VaultIdFromReceiver,
            encodeTransferModel.VaultIdUsedForFees,
            encodeTransferModel.Nonce);

        var fifthWeight = CalculateFifthWeightForTransferWithFees(
            OrderType.ConditionalTransferWithFees,
            encodeTransferModel.QuantizedAmountToTransfer,
            encodeTransferModel.QuantizedAmountToLimitMaxFee,
            encodeTransferModel.ExpirationTimestamp);

        var firstInnerHash = pedersenHash.CreateHash(
            new BigInteger(encodeTransferModel.AssetIdSold.RemoveHexPrefix(), 16),
            new BigInteger(encodeTransferModel.AssetIdUsedForFees.RemoveHexPrefix(), 16));
        var secondInnerHash = pedersenHash.CreateHash(
            firstInnerHash,
            new BigInteger(encodeTransferModel.ReceiverStarkKey.RemoveHexPrefix(), 16));
        var thirdInnerHash = pedersenHash.CreateHash(
            secondInnerHash,
            new BigInteger(condition.RemoveHexPrefix(), 16));
        var fourthInnerHash = pedersenHash.CreateHash(thirdInnerHash, fourthWeight);

        return pedersenHash.CreateHash(fourthInnerHash, fifthWeight);
    }

    /// <inheritdoc />
    [Obsolete("Implementation obsolete, only implemented to test against Starkware Dataset")]
    public BigInteger EncodeConditionalTransferWithoutFees(EncodeTransferWithoutFeesModel encodeTransferWithoutFeesModel, string condition)
    {
        Guards.NotNullOrEmptyOrWhitespace(encodeTransferWithoutFeesModel.AssetIdSold);
        Guards.NotInvalidHex(encodeTransferWithoutFeesModel.AssetIdSold, nameof(encodeTransferWithoutFeesModel.AssetIdSold));
        Guards.NotNullOrEmptyOrWhitespace(encodeTransferWithoutFeesModel.ReceiverStarkKey);
        Guards.NotInvalidHex(encodeTransferWithoutFeesModel.ReceiverStarkKey, nameof(encodeTransferWithoutFeesModel.ReceiverStarkKey));
        Guards.NotNull(condition);
        Guards.NotInvalidHex(encodeTransferWithoutFeesModel.Fact, nameof(encodeTransferWithoutFeesModel.Fact));
        Guards.NotInvalidHex(encodeTransferWithoutFeesModel.FactRegistryAddress, nameof(encodeTransferWithoutFeesModel.FactRegistryAddress));

        var packedMessage = BigInteger.Two
            .ShiftLeft(31).Add(encodeTransferWithoutFeesModel.VaultIdFromSender)
            .ShiftLeft(31).Add(encodeTransferWithoutFeesModel.VaultIdFromReceiver)
            .ShiftLeft(63).Add(encodeTransferWithoutFeesModel.QuantizedAmountToTransfer)
            .ShiftLeft(63).Add(BigInteger.Zero)
            .ShiftLeft(31).Add(new BigInteger(encodeTransferWithoutFeesModel.Nonce.ToString()))
            .ShiftLeft(22).Add(new BigInteger((encodeTransferWithoutFeesModel.ExpirationTimestamp / 3600).ToString()));

        var firstInnerHash = pedersenHash.CreateHash(
            new BigInteger(encodeTransferWithoutFeesModel.AssetIdSold.RemoveHexPrefix(), 16),
            new BigInteger(encodeTransferWithoutFeesModel.ReceiverStarkKey.RemoveHexPrefix(), 16));

        var secondInnerHash = pedersenHash.CreateHash(
            firstInnerHash,
            new BigInteger(condition.RemoveHexPrefix(), 16));

        return pedersenHash.CreateHash(secondInnerHash, packedMessage);
    }

    /// <inheritdoc />
    [Obsolete("Implementation obsolete, only implemented to test against Starkware Dataset")]
    public BigInteger EncodeLimitOrderWithoutFees(EncodeLimitOrderWithoutFeesModel encodeLimitOrderWithoutFeesModel)
    {
        Guards.NotNullOrEmptyOrWhitespace(encodeLimitOrderWithoutFeesModel.AssetIdSold);
        Guards.NotInvalidHex(encodeLimitOrderWithoutFeesModel.AssetIdSold, nameof(encodeLimitOrderWithoutFeesModel.AssetIdSold));
        Guards.NotNullOrEmptyOrWhitespace(encodeLimitOrderWithoutFeesModel.AssetIdBought);
        Guards.NotInvalidHex(encodeLimitOrderWithoutFeesModel.AssetIdBought, nameof(encodeLimitOrderWithoutFeesModel.AssetIdBought));

        var packedMessage = BigInteger.Zero
            .ShiftLeft(31).Add(encodeLimitOrderWithoutFeesModel.VaultIdUsedForSelling)
            .ShiftLeft(31).Add(encodeLimitOrderWithoutFeesModel.VaultIdUsedForBuying)
            .ShiftLeft(63).Add(encodeLimitOrderWithoutFeesModel.QuantizedAmountSold)
            .ShiftLeft(63).Add(encodeLimitOrderWithoutFeesModel.QuantizedAmountBought)
            .ShiftLeft(31).Add(new BigInteger(encodeLimitOrderWithoutFeesModel.Nonce.ToString()))
            .ShiftLeft(22).Add(new BigInteger((encodeLimitOrderWithoutFeesModel.ExpirationTimestamp / 3600).ToString()));

        var firstInnerHash = pedersenHash.CreateHash(
            new BigInteger(encodeLimitOrderWithoutFeesModel.AssetIdSold.RemoveHexPrefix(), 16),
            new BigInteger(encodeLimitOrderWithoutFeesModel.AssetIdBought.RemoveHexPrefix(), 16));

        return pedersenHash.CreateHash(firstInnerHash, packedMessage);
    }

    /// <inheritdoc />
    [Obsolete("Implementation obsolete, only implemented to test against Starkware Dataset")]
    public BigInteger EncodeConditionalTransferWithoutFees(EncodeTransferWithoutFeesModel encodeTransferWithoutFeesModel)
    {
        Guards.NotNullOrEmptyOrWhitespace(encodeTransferWithoutFeesModel.AssetIdSold);
        Guards.NotInvalidHex(encodeTransferWithoutFeesModel.AssetIdSold, nameof(encodeTransferWithoutFeesModel.AssetIdSold));
        Guards.NotNullOrEmptyOrWhitespace(encodeTransferWithoutFeesModel.ReceiverStarkKey);
        Guards.NotInvalidHex(encodeTransferWithoutFeesModel.ReceiverStarkKey, nameof(encodeTransferWithoutFeesModel.ReceiverStarkKey));
        Guards.NotNull(encodeTransferWithoutFeesModel.Fact);
        Guards.NotNull(encodeTransferWithoutFeesModel.FactRegistryAddress);
        Guards.NotInvalidHex(encodeTransferWithoutFeesModel.Fact, nameof(encodeTransferWithoutFeesModel.Fact));
        Guards.NotInvalidHex(encodeTransferWithoutFeesModel.FactRegistryAddress, nameof(encodeTransferWithoutFeesModel.FactRegistryAddress));

        var packedMessage = BigInteger.One
            .ShiftLeft(31).Add(encodeTransferWithoutFeesModel.VaultIdFromSender)
            .ShiftLeft(31).Add(encodeTransferWithoutFeesModel.VaultIdFromReceiver)
            .ShiftLeft(63).Add(encodeTransferWithoutFeesModel.QuantizedAmountToTransfer)
            .ShiftLeft(63).Add(BigInteger.Zero)
            .ShiftLeft(31).Add(new BigInteger(encodeTransferWithoutFeesModel.Nonce.ToString()))
            .ShiftLeft(22).Add(new BigInteger((encodeTransferWithoutFeesModel.ExpirationTimestamp / 3600).ToString()));

        var firstInnerHash = pedersenHash.CreateHash(
            new BigInteger(encodeTransferWithoutFeesModel.AssetIdSold.RemoveHexPrefix(), 16),
            new BigInteger(encodeTransferWithoutFeesModel.ReceiverStarkKey.RemoveHexPrefix(), 16));

        var secondInnerHash = pedersenHash.CreateHash(
            firstInnerHash,
            GetCondition(encodeTransferWithoutFeesModel.Fact, encodeTransferWithoutFeesModel.FactRegistryAddress));

        return pedersenHash.CreateHash(secondInnerHash, packedMessage);
    }

    /// <inheritdoc />
    [Obsolete("Implementation obsolete, only implemented to test against Starkware Dataset")]
    public BigInteger EncodeTransferWithoutFees(EncodeTransferWithoutFeesModel encodeTransferWithoutFeesModel)
    {
        Guards.NotNullOrEmptyOrWhitespace(encodeTransferWithoutFeesModel.AssetIdSold);
        Guards.NotInvalidHex(encodeTransferWithoutFeesModel.AssetIdSold, nameof(encodeTransferWithoutFeesModel.AssetIdSold));
        Guards.NotNullOrEmptyOrWhitespace(encodeTransferWithoutFeesModel.ReceiverStarkKey);
        Guards.NotInvalidHex(encodeTransferWithoutFeesModel.ReceiverStarkKey, nameof(encodeTransferWithoutFeesModel.ReceiverStarkKey));

        var packedMessage = BigInteger.One
            .ShiftLeft(31).Add(encodeTransferWithoutFeesModel.VaultIdFromSender)
            .ShiftLeft(31).Add(encodeTransferWithoutFeesModel.VaultIdFromReceiver)
            .ShiftLeft(63).Add(encodeTransferWithoutFeesModel.QuantizedAmountToTransfer)
            .ShiftLeft(63).Add(BigInteger.Zero)
            .ShiftLeft(31).Add(new BigInteger(encodeTransferWithoutFeesModel.Nonce.ToString()))
            .ShiftLeft(22).Add(new BigInteger((encodeTransferWithoutFeesModel.ExpirationTimestamp / 3600).ToString()));

        var firstInnerHash = pedersenHash.CreateHash(
            new BigInteger(encodeTransferWithoutFeesModel.AssetIdSold.RemoveHexPrefix(), 16),
            new BigInteger(encodeTransferWithoutFeesModel.ReceiverStarkKey.RemoveHexPrefix(), 16));

        return pedersenHash.CreateHash(firstInnerHash, packedMessage);
    }

    private static BigInteger CalculateFourthWeight(
        BigInteger paramB,
        BigInteger paramC,
        BigInteger paramD,
        int paramE)
    {
        return BigInteger.Zero
            .ShiftLeft(27).Add(BigInteger.Zero)
            .ShiftLeft(64).Add(paramB)
            .ShiftLeft(64).Add(paramC)
            .ShiftLeft(64).Add(paramD)
            .ShiftLeft(32).Add(new BigInteger(paramE.ToString()));
    }

    private static BigInteger CalculateFifthWeightForLimitOrderWithFees(
        OrderType orderType,
        BigInteger paramB,
        BigInteger paramC,
        BigInteger paramD,
        long paramE)
    {
        return BigInteger.Zero
            .ShiftLeft(10).Add(new BigInteger(orderType.ToIntegerString()))
            .ShiftLeft(64).Add(paramB)
            .ShiftLeft(64).Add(paramC)
            .ShiftLeft(64).Add(paramD)
            .ShiftLeft(32).Add(new BigInteger((paramE / 3600).ToString()))
            .ShiftLeft(17).Add(BigInteger.Zero);
    }

    private static BigInteger CalculateFifthWeightForTransferWithFees(
        OrderType orderType,
        BigInteger paramB,
        BigInteger paramC,
        long paramD)
    {
        return BigInteger.Zero
            .ShiftLeft(10).Add(new BigInteger(orderType.ToIntegerString()))
            .ShiftLeft(64).Add(paramB)
            .ShiftLeft(64).Add(paramC)
            .ShiftLeft(32).Add(new BigInteger((paramD / 3600).ToString()))
            .ShiftLeft(81).Add(BigInteger.Zero);
    }

    private BigInteger GetCondition(string fact, string factRegistryAddress)
    {
        var condition = pedersenHash.CreateHash(
            new BigInteger(fact.RemoveHexPrefix(), 16),
            new BigInteger(factRegistryAddress.RemoveHexPrefix(), 16));
        return condition;
    }
}
