namespace StarkEx.Crypto.SDK.Hashing;

using Nethereum.Hex.HexConvertors.Extensions;
using Org.BouncyCastle.Math;
using StarkEx.Crypto.SDK.Enums;
using StarkEx.Crypto.SDK.Extensions;
using StarkEx.Crypto.SDK.Guards;
using StarkEx.Crypto.SDK.Models;

public class SpotTradingMessageHasher : ISpotTradingMessageHasher
{
    private readonly IPedersenHash pedersenHash;

    public SpotTradingMessageHasher(IPedersenHash pedersenHash)
    {
        this.pedersenHash = pedersenHash;
    }

    public BigInteger EncodeLimitOrderWithFees(EncodeLimitOrderWithFeesModel encodeLimitOrderWithFeesModel)
    {
        Guards.NotNullOrEmptyOrWhitespace(encodeLimitOrderWithFeesModel.AssetIdSold);
        Guards.NotInvalidHex(encodeLimitOrderWithFeesModel.AssetIdSold, nameof(encodeLimitOrderWithFeesModel.AssetIdSold));
        Guards.NotNullOrEmptyOrWhitespace(encodeLimitOrderWithFeesModel.AssetIdBought);
        Guards.NotInvalidHex(encodeLimitOrderWithFeesModel.AssetIdBought, nameof(encodeLimitOrderWithFeesModel.AssetIdBought));
        Guards.NotNullOrEmptyOrWhitespace(encodeLimitOrderWithFeesModel.AssetIdUsedForFees);
        Guards.NotInvalidHex(encodeLimitOrderWithFeesModel.AssetIdUsedForFees, nameof(encodeLimitOrderWithFeesModel.AssetIdUsedForFees));

        var fourthWeight = CalculateFourthWeight(
            encodeLimitOrderWithFeesModel.QuantizedAmountSold,
            encodeLimitOrderWithFeesModel.QuantizedAmountBought,
            encodeLimitOrderWithFeesModel.QuantizedAmountUsedForFees,
            encodeLimitOrderWithFeesModel.Nonce);

        var fifthWeight = CalculateFifthWeightForLimitOrderWithFees(
            OrderType.LimitOrderWithFees,
            encodeLimitOrderWithFeesModel.VaultIdUsedForFees,
            encodeLimitOrderWithFeesModel.VaultIdUsedForSelling,
            encodeLimitOrderWithFeesModel.VaultIdUsedForBuying,
            encodeLimitOrderWithFeesModel.ExpirationTimestamp);

        var firstInnerHash = pedersenHash.CreateHash(
            new BigInteger(encodeLimitOrderWithFeesModel.AssetIdSold.RemoveHexPrefix(), 16),
            new BigInteger(encodeLimitOrderWithFeesModel.AssetIdBought.RemoveHexPrefix(), 16));
        var secondInnerHash = pedersenHash.CreateHash(
            firstInnerHash,
            new BigInteger(encodeLimitOrderWithFeesModel.AssetIdUsedForFees.RemoveHexPrefix(), 16));
        var thirdInnerHash = pedersenHash.CreateHash(secondInnerHash, fourthWeight);

        return pedersenHash.CreateHash(thirdInnerHash, fifthWeight);
    }

    public BigInteger EncodeTransferWithFees(EncodeTransferWithFeesModel encodeTransferWithFeesModel)
    {
        Guards.NotNullOrEmptyOrWhitespace(encodeTransferWithFeesModel.AssetIdSold);
        Guards.NotInvalidHex(encodeTransferWithFeesModel.AssetIdSold, nameof(encodeTransferWithFeesModel.AssetIdSold));
        Guards.NotNullOrEmptyOrWhitespace(encodeTransferWithFeesModel.AssetIdUsedForFees);
        Guards.NotInvalidHex(encodeTransferWithFeesModel.AssetIdUsedForFees, nameof(encodeTransferWithFeesModel.AssetIdUsedForFees));
        Guards.NotNullOrEmptyOrWhitespace(encodeTransferWithFeesModel.ReceiverStarkKey);
        Guards.NotInvalidHex(encodeTransferWithFeesModel.ReceiverStarkKey, nameof(encodeTransferWithFeesModel.ReceiverStarkKey));

        var fourthWeight = CalculateFourthWeight(
            encodeTransferWithFeesModel.VaultIdFromSender,
            encodeTransferWithFeesModel.VaultIdFromReceiver,
            encodeTransferWithFeesModel.VaultIdUsedForFees,
            encodeTransferWithFeesModel.Nonce);

        var fifthWeight = CalculateFifthWeightForTransferWithFees(
            OrderType.TransferWithFees,
            encodeTransferWithFeesModel.QuantizedAmountToTransfer,
            encodeTransferWithFeesModel.QuantizedAmountToLimitMaxFee,
            encodeTransferWithFeesModel.ExpirationTimestamp);

        var firstInnerHash = pedersenHash.CreateHash(
            new BigInteger(encodeTransferWithFeesModel.AssetIdSold.RemoveHexPrefix(), 16),
            new BigInteger(encodeTransferWithFeesModel.AssetIdUsedForFees.RemoveHexPrefix(), 16));
        var secondInnerHash = pedersenHash.CreateHash(
            firstInnerHash,
            new BigInteger(encodeTransferWithFeesModel.ReceiverStarkKey.RemoveHexPrefix(), 16));
        var thirdInnerHash = pedersenHash.CreateHash(secondInnerHash, fourthWeight);

        return pedersenHash.CreateHash(thirdInnerHash, fifthWeight);
    }

    public BigInteger EncodeConditionalTransferWithFees(EncodeTransferWithFeesModel encodeTransferWithFeesModel)
    {
        Guards.NotNull(encodeTransferWithFeesModel.Fact);
        Guards.NotNull(encodeTransferWithFeesModel.FactRegistryAddress);
        Guards.NotInvalidHex(encodeTransferWithFeesModel.Fact, nameof(encodeTransferWithFeesModel.Fact));
        Guards.NotInvalidHex(encodeTransferWithFeesModel.FactRegistryAddress, nameof(encodeTransferWithFeesModel.FactRegistryAddress));

        var condition = pedersenHash.CreateHash(
            new BigInteger(encodeTransferWithFeesModel.Fact.RemoveHexPrefix(), 16),
            new BigInteger(encodeTransferWithFeesModel.FactRegistryAddress.RemoveHexPrefix(), 16));

        return EncodeConditionalTransferWithFees(encodeTransferWithFeesModel, condition.ToByteArray().ToHex());
    }

    public BigInteger EncodeConditionalTransferWithFees(
        EncodeTransferWithFeesModel encodeTransferWithFeesModel,
        string condition)
    {
        Guards.NotNullOrEmptyOrWhitespace(encodeTransferWithFeesModel.AssetIdSold);
        Guards.NotInvalidHex(encodeTransferWithFeesModel.AssetIdSold, nameof(encodeTransferWithFeesModel.AssetIdSold));
        Guards.NotNullOrEmptyOrWhitespace(encodeTransferWithFeesModel.AssetIdUsedForFees);
        Guards.NotInvalidHex(encodeTransferWithFeesModel.AssetIdUsedForFees, nameof(encodeTransferWithFeesModel.AssetIdUsedForFees));
        Guards.NotNullOrEmptyOrWhitespace(encodeTransferWithFeesModel.ReceiverStarkKey);
        Guards.NotInvalidHex(encodeTransferWithFeesModel.ReceiverStarkKey, nameof(encodeTransferWithFeesModel.ReceiverStarkKey));

        var fourthWeight = CalculateFourthWeight(
            encodeTransferWithFeesModel.VaultIdFromSender,
            encodeTransferWithFeesModel.VaultIdFromReceiver,
            encodeTransferWithFeesModel.VaultIdUsedForFees,
            encodeTransferWithFeesModel.Nonce);

        var fifthWeight = CalculateFifthWeightForTransferWithFees(
            OrderType.ConditionalTransferWithFees,
            encodeTransferWithFeesModel.QuantizedAmountToTransfer,
            encodeTransferWithFeesModel.QuantizedAmountToLimitMaxFee,
            encodeTransferWithFeesModel.ExpirationTimestamp);

        var firstInnerHash = pedersenHash.CreateHash(
            new BigInteger(encodeTransferWithFeesModel.AssetIdSold.RemoveHexPrefix(), 16),
            new BigInteger(encodeTransferWithFeesModel.AssetIdUsedForFees.RemoveHexPrefix(), 16));
        var secondInnerHash = pedersenHash.CreateHash(
            firstInnerHash,
            new BigInteger(encodeTransferWithFeesModel.ReceiverStarkKey.RemoveHexPrefix(), 16));
        var thirdInnerHash = pedersenHash.CreateHash(
            secondInnerHash,
            new BigInteger(condition.RemoveHexPrefix(), 16));
        var fourthInnerHash = pedersenHash.CreateHash(thirdInnerHash, fourthWeight);

        return pedersenHash.CreateHash(fourthInnerHash, fifthWeight);
    }

    [Obsolete("Implementation obsolete, only implemented to test against Starkware Dataset")]
    public BigInteger DeprecatedHashLimitOrder(
        string assetIdSold,
        string assetIdBought,
        BigInteger quantizedAmountSold,
        BigInteger quantizedAmountBought,
        int nonce,
        BigInteger vaultIdUsedForSelling,
        BigInteger vaultIdUsedForBuying,
        long expirationTimestamp)
    {
        var thirdWeight = CalculateThirdWeight(
            OrderType.LimitOrder,
            vaultIdUsedForSelling,
            vaultIdUsedForBuying,
            quantizedAmountSold,
            quantizedAmountBought,
            nonce,
            expirationTimestamp / 3600);

        var firstInnerHash = pedersenHash.CreateHash(
            new BigInteger(assetIdSold.RemoveHexPrefix(), 16),
            new BigInteger(assetIdBought.RemoveHexPrefix(), 16));

        return pedersenHash.CreateHash(firstInnerHash, thirdWeight);
    }

    [Obsolete("Implementation obsolete, only implemented to test against Starkware Dataset")]
    public BigInteger DeprecatedHashTransferOrder(
        string assetIdSold,
        string receiverStarkKey,
        BigInteger quantizedAmountSold,
        int nonce,
        BigInteger vaultIdUsedOfReceiver,
        BigInteger vaultIdUsedForBuying,
        long expirationTimestamp)
    {
        var thirdWeight = CalculateThirdWeight(
            OrderType.Transfer,
            vaultIdUsedForBuying,
            vaultIdUsedOfReceiver,
            quantizedAmountSold,
            BigInteger.Zero,
            nonce,
            expirationTimestamp / 3600);

        var firstInnerHash = pedersenHash.CreateHash(new BigInteger(assetIdSold.RemoveHexPrefix(), 16), new BigInteger(receiverStarkKey.RemoveHexPrefix(), 16));

        return pedersenHash.CreateHash(firstInnerHash, thirdWeight);
    }

    [Obsolete("Implementation obsolete, only implemented to test against Starkware Dataset")]
    public BigInteger DeprecatedHashConditionalTransfer(
        string assetIdSold,
        string receiverStarkKey,
        BigInteger quantizedAmountSold,
        int nonce,
        BigInteger vaultIdUsedOfReceiver,
        BigInteger vaultIdUsedForBuying,
        long expirationTimestamp,
        string condition) // Only accepting the condition here to validate against starkware dataset
    {
        var thirdWeight = CalculateThirdWeight(
            OrderType.ConditionalTransfer,
            vaultIdUsedForBuying,
            vaultIdUsedOfReceiver,
            quantizedAmountSold,
            BigInteger.Zero,
            nonce,
            expirationTimestamp / 3600);

        var firstInnerHash = pedersenHash.CreateHash(new BigInteger(assetIdSold.RemoveHexPrefix(), 16), new BigInteger(receiverStarkKey.RemoveHexPrefix(), 16));
        var secondInnerHash = pedersenHash.CreateHash(firstInnerHash, new BigInteger(condition.RemoveHexPrefix(), 16));

        return pedersenHash.CreateHash(secondInnerHash, thirdWeight);
    }

    [Obsolete("This calculation of the third weight is marked as deprecated in starkex docs")]
    private static BigInteger CalculateThirdWeight(
        OrderType orderType,
        BigInteger paramB,
        BigInteger paramC,
        BigInteger paramD,
        BigInteger paramE,
        int paramF,
        long paramG)
    {
        return BigInteger.Zero
            .ShiftLeft(4).Add(new BigInteger(orderType.ToIntegerString()))
            .ShiftLeft(31).Add(paramB)
            .ShiftLeft(31).Add(paramC)
            .ShiftLeft(63).Add(paramD)
            .ShiftLeft(63).Add(paramE)
            .ShiftLeft(31).Add(new BigInteger(paramF.ToString()))
            .ShiftLeft(22).Add(new BigInteger(paramG.ToString()));
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
}