namespace StarkEx.Crypto.SDK.Hashing;

using Nethereum.Hex.HexConvertors.Extensions;
using Org.BouncyCastle.Math;
using StarkEx.Crypto.SDK.Enums;
using StarkEx.Crypto.SDK.Extensions;

public class SpotTradingMessageHasher : ISpotTradingMessageHasher
{
    private readonly IPedersenHash pedersenHash;

    public SpotTradingMessageHasher(IPedersenHash pedersenHash)
    {
        this.pedersenHash = pedersenHash;
    }

    public BigInteger EncodeLimitOrderWithFees(
        string assetIdSold,
        string assetIdBought,
        string assetIdUsedForFees,
        BigInteger quantizedAmountSold,
        BigInteger quantizedAmountBought,
        BigInteger quantizedAmountUsedForFees,
        int nonce,
        BigInteger vaultIdUsedForFees,
        BigInteger vaultIdUsedForSelling,
        BigInteger vaultIdUsedForBuying,
        int expirationTimestamp)
    {
        var fourthWeight = CalculateFourthWeight(
            quantizedAmountSold,
            quantizedAmountBought,
            quantizedAmountUsedForFees,
            nonce);

        var fifthWeight = CalculateFifthWeightForLimitOrderWithFees(
            OrderType.LimitOrderWithFees,
            vaultIdUsedForFees,
            vaultIdUsedForSelling,
            vaultIdUsedForBuying,
            expirationTimestamp);

        var firstInnerHash = pedersenHash.CreateHash(new BigInteger(assetIdSold.RemoveHexPrefix(), 16), new BigInteger(assetIdBought.RemoveHexPrefix(), 16));
        var secondInnerHash = pedersenHash.CreateHash(firstInnerHash, new BigInteger(assetIdUsedForFees.RemoveHexPrefix(), 16));
        var thirdInnerHash = pedersenHash.CreateHash(secondInnerHash, fourthWeight);

        return pedersenHash.CreateHash(thirdInnerHash, fifthWeight);
    }

    public BigInteger EncodeTransferWithFees(
        string assetIdSold,
        string assetIdUsedForFees,
        string receiverStarkKey,
        BigInteger vaultIdFromSender,
        BigInteger vaultIdFromReceiver,
        BigInteger vaultIdUsedForFees,
        int nonce,
        BigInteger quantizedAmountToTransfer,
        BigInteger quantizedAmountToLimitMaxFee,
        int expirationTimestamp)
    {
        var fourthWeight = CalculateFourthWeight(
            vaultIdFromSender,
            vaultIdFromReceiver,
            vaultIdUsedForFees,
            nonce);

        var fifthWeight = CalculateFifthWeightForTransferWithFees(
            OrderType.TransferWithFees,
            quantizedAmountToTransfer,
            quantizedAmountToLimitMaxFee,
            expirationTimestamp);

        var firstInnerHash = pedersenHash.CreateHash(new BigInteger(assetIdSold.RemoveHexPrefix(), 16), new BigInteger(assetIdUsedForFees.RemoveHexPrefix(), 16));
        var secondInnerHash = pedersenHash.CreateHash(firstInnerHash, new BigInteger(receiverStarkKey.RemoveHexPrefix(), 16));
        var thirdInnerHash = pedersenHash.CreateHash(secondInnerHash, fourthWeight);

        return pedersenHash.CreateHash(thirdInnerHash, fifthWeight);
    }

    public BigInteger EncodeConditionalTransferWithFees(
        string assetIdSold,
        string assetIdUsedForFees,
        string receiverStarkKey,
        BigInteger vaultIdFromSender,
        BigInteger vaultIdFromReceiver,
        BigInteger vaultIdUsedForFees,
        int nonce,
        BigInteger quantizedAmountToTransfer,
        BigInteger quantizedAmountToLimitMaxFee,
        int expirationTimestamp,
        string fact,
        string factRegistryAddress)
    {
        var condition = pedersenHash.CreateHash(new BigInteger(fact.RemoveHexPrefix(), 16), new BigInteger(factRegistryAddress.RemoveHexPrefix(), 16));

        return EncodeConditionalTransferWithFees(
            assetIdSold,
            assetIdUsedForFees,
            receiverStarkKey,
            vaultIdFromSender,
            vaultIdFromReceiver,
            vaultIdUsedForFees,
            nonce,
            quantizedAmountToTransfer,
            quantizedAmountToLimitMaxFee,
            expirationTimestamp,
            condition.ToByteArray().ToHex());
    }

    public BigInteger EncodeConditionalTransferWithFees(
        string assetIdSold,
        string assetIdUsedForFees,
        string receiverStarkKey,
        BigInteger vaultIdFromSender,
        BigInteger vaultIdFromReceiver,
        BigInteger vaultIdUsedForFees,
        int nonce,
        BigInteger quantizedAmountToTransfer,
        BigInteger quantizedAmountToLimitMaxFee,
        int expirationTimestamp,
        string condition)
    {
        var fourthWeight = CalculateFourthWeight(
            vaultIdFromSender,
            vaultIdFromReceiver,
            vaultIdUsedForFees,
            nonce);

        var fifthWeight = CalculateFifthWeightForTransferWithFees(
            OrderType.ConditionalTransferWithFees,
            quantizedAmountToTransfer,
            quantizedAmountToLimitMaxFee,
            expirationTimestamp);

        var firstInnerHash = pedersenHash.CreateHash(new BigInteger(assetIdSold.RemoveHexPrefix(), 16), new BigInteger(assetIdUsedForFees.RemoveHexPrefix(), 16));
        var secondInnerHash = pedersenHash.CreateHash(firstInnerHash, new BigInteger(receiverStarkKey.RemoveHexPrefix(), 16));
        var thirdInnerHash = pedersenHash.CreateHash(secondInnerHash, new BigInteger(condition.RemoveHexPrefix(), 16));
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
        int expirationTimestamp)
    {
        var thirdWeight = CalculateThirdWeight(
            OrderType.LimitOrder,
            vaultIdUsedForSelling,
            vaultIdUsedForBuying,
            quantizedAmountSold,
            quantizedAmountBought,
            nonce,
            expirationTimestamp / 3600);

        var firstInnerHash = pedersenHash.CreateHash(new BigInteger(assetIdSold.RemoveHexPrefix(), 16), new BigInteger(assetIdBought.RemoveHexPrefix(), 16));

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
        int expirationTimestamp)
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
        int expirationTimestamp,
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
        int paramG)
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
        int paramE)
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
        int paramD)
    {
        return BigInteger.Zero
            .ShiftLeft(10).Add(new BigInteger(orderType.ToIntegerString()))
            .ShiftLeft(64).Add(paramB)
            .ShiftLeft(64).Add(paramC)
            .ShiftLeft(32).Add(new BigInteger((paramD / 3600).ToString()))
            .ShiftLeft(81).Add(BigInteger.Zero);
    }
}