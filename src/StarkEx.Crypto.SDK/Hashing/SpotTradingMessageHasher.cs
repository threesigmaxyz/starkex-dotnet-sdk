namespace StarkEx.Crypto.SDK.Hashing;

using Nethereum.Hex.HexConvertors.Extensions;
using Org.BouncyCastle.Math;
using StarkEx.Crypto.SDK.Enums;
using StarkEx.Crypto.SDK.Extensions;

public class SpotTradingMessageHasher : ISpotTradingMessageHasher
{
    private readonly PedersenHash pedersenHash;

    public SpotTradingMessageHasher(PedersenHash pedersenHash)
    {
        this.pedersenHash = pedersenHash;
    }

    public BigInteger EncodeLimitOrderWithFees(
        string assetIdSold,
        string assetIdBought,
        string assetIdUsedForFees,
        long quantizedAmountSold,
        long quantizedAmountBought,
        long quantizedAmountUsedForFees,
        int nonce,
        int vaultIdUsedForFees,
        int vaultIdUsedForSelling,
        int vaultIdUsedForBuying,
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

        var firstInnerHash = pedersenHash.CreateHash(new BigInteger(assetIdSold, 16), new BigInteger(assetIdBought, 16));
        var secondInnerHash = pedersenHash.CreateHash(firstInnerHash, new BigInteger(assetIdUsedForFees, 16));
        var thirdInnerHash = pedersenHash.CreateHash(secondInnerHash, fourthWeight);

        return pedersenHash.CreateHash(thirdInnerHash, fifthWeight);
    }

    public BigInteger EncodeTransferWithFees(
        string assetIdSold,
        string assetIdUsedForFees,
        string receiverStarkKey,
        int vaultIdFromSender,
        int vaultIdFromReceiver,
        int vaultIdUsedForFees,
        int nonce,
        long quantizedAmountToTransfer,
        long quantizedAmountToLimitMaxFee,
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

        var firstInnerHash = pedersenHash.CreateHash(new BigInteger(assetIdSold, 16), new BigInteger(assetIdUsedForFees, 16));
        var secondInnerHash = pedersenHash.CreateHash(firstInnerHash, new BigInteger(receiverStarkKey, 16));
        var thirdInnerHash = pedersenHash.CreateHash(secondInnerHash, fourthWeight);

        return pedersenHash.CreateHash(thirdInnerHash, fifthWeight);
    }

    public BigInteger EncodeConditionalTransferWithFees(
        string assetIdSold,
        string assetIdUsedForFees,
        string receiverStarkKey,
        int vaultIdFromSender,
        int vaultIdFromReceiver,
        int vaultIdUsedForFees,
        int nonce,
        long quantizedAmountToTransfer,
        long quantizedAmountToLimitMaxFee,
        int expirationTimestamp,
        string fact,
        string factRegistryAddress)
    {
        var condition = pedersenHash.CreateHash(new BigInteger(fact, 16), new BigInteger(factRegistryAddress, 16));

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
        int vaultIdFromSender,
        int vaultIdFromReceiver,
        int vaultIdUsedForFees,
        int nonce,
        long quantizedAmountToTransfer,
        long quantizedAmountToLimitMaxFee,
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

        var firstInnerHash = pedersenHash.CreateHash(new BigInteger(assetIdSold, 16), new BigInteger(assetIdUsedForFees, 16));
        var secondInnerHash = pedersenHash.CreateHash(firstInnerHash, new BigInteger(receiverStarkKey, 16));
        var thirdInnerHash = pedersenHash.CreateHash(secondInnerHash, new BigInteger(condition, 16));
        var fourthInnerHash = pedersenHash.CreateHash(thirdInnerHash, fourthWeight);

        return pedersenHash.CreateHash(fourthInnerHash, fifthWeight);
    }

    [Obsolete("Implementation obsolete, only implemented to test against Starkware Dataset")]
    public BigInteger DeprecatedHashLimitOrder(
        string assetIdSold,
        string assetIdBought,
        long quantizedAmountSold,
        long quantizedAmountBought,
        int nonce,
        int vaultIdUsedForSelling,
        int vaultIdUsedForBuying,
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

        var firstInnerHash = pedersenHash.CreateHash(new BigInteger(assetIdSold, 16), new BigInteger(assetIdBought, 16));
        return pedersenHash.CreateHash(firstInnerHash, thirdWeight);
    }

    [Obsolete("Implementation obsolete, only implemented to test against Starkware Dataset")]
    public BigInteger DeprecatedHashTransferOrder(
        string assetIdSold,
        string receiverStarkKey,
        long quantizedAmountSold,
        int nonce,
        int vaultIdUsedOfReceiver,
        int vaultIdUsedForBuying,
        int expirationTimestamp)
    {
        var thirdWeight = CalculateThirdWeight(
            OrderType.Transfer,
            vaultIdUsedForBuying,
            vaultIdUsedOfReceiver,
            quantizedAmountSold,
            0,
            nonce,
            expirationTimestamp / 3600);

        var firstInnerHash = pedersenHash.CreateHash(new BigInteger(assetIdSold, 16), new BigInteger(receiverStarkKey, 16));
        return pedersenHash.CreateHash(firstInnerHash, thirdWeight);
    }

    [Obsolete("Implementation obsolete, only implemented to test against Starkware Dataset")]
    public BigInteger DeprecatedHashConditionalTransfer(
        string assetIdSold,
        string receiverStarkKey,
        long quantizedAmountSold,
        int nonce,
        int vaultIdUsedOfReceiver,
        int vaultIdUsedForBuying,
        int expirationTimestamp,
        string condition) // Only accepting the condition here to validate against starkware dataset
    {
        var thirdWeight = CalculateThirdWeight(
            OrderType.ConditionalTransfer,
            vaultIdUsedForBuying,
            vaultIdUsedOfReceiver,
            quantizedAmountSold,
            0,
            nonce,
            expirationTimestamp / 3600);

        var firstInnerHash = pedersenHash.CreateHash(new BigInteger(assetIdSold, 16), new BigInteger(receiverStarkKey, 16));
        var secondInnerHash = pedersenHash.CreateHash(firstInnerHash, new BigInteger(condition, 16));

        return pedersenHash.CreateHash(secondInnerHash, thirdWeight);
    }

    [Obsolete("This calculation of the third weight is marked as deprecated in starkex docs")]
    private static BigInteger CalculateThirdWeight(
        OrderType orderType,
        int paramB,
        int paramC,
        long paramD,
        long paramE,
        int paramF,
        int paramG)
    {
        return BigInteger.Zero
            .ShiftLeft(4).Add(new BigInteger(orderType.ToIntegerString()))
            .ShiftLeft(31).Add(new BigInteger(paramB.ToString()))
            .ShiftLeft(31).Add(new BigInteger(paramC.ToString()))
            .ShiftLeft(63).Add(new BigInteger(paramD.ToString()))
            .ShiftLeft(63).Add(new BigInteger(paramE.ToString()))
            .ShiftLeft(31).Add(new BigInteger(paramF.ToString()))
            .ShiftLeft(22).Add(new BigInteger(paramG.ToString()));
    }

    private static BigInteger CalculateFourthWeight(
        long paramB,
        long paramC,
        long paramD,
        int paramE)
    {
        return BigInteger.Zero
            .ShiftLeft(27).Add(BigInteger.Zero)
            .ShiftLeft(64).Add(new BigInteger(paramB.ToString()))
            .ShiftLeft(64).Add(new BigInteger(paramC.ToString()))
            .ShiftLeft(64).Add(new BigInteger(paramD.ToString()))
            .ShiftLeft(32).Add(new BigInteger(paramE.ToString()));
    }

    private static BigInteger CalculateFifthWeightForLimitOrderWithFees(
        OrderType orderType,
        long paramB,
        long paramC,
        long paramD,
        int paramE)
    {
        return BigInteger.Zero
            .ShiftLeft(10).Add(new BigInteger(orderType.ToIntegerString()))
            .ShiftLeft(64).Add(new BigInteger(paramB.ToString()))
            .ShiftLeft(64).Add(new BigInteger(paramC.ToString()))
            .ShiftLeft(64).Add(new BigInteger(paramD.ToString()))
            .ShiftLeft(32).Add(new BigInteger((paramE / 3600).ToString()))
            .ShiftLeft(17).Add(BigInteger.Zero);
    }

    private static BigInteger CalculateFifthWeightForTransferWithFees(
        OrderType orderType,
        long paramB,
        long paramC,
        int paramD)
    {
        return BigInteger.Zero
            .ShiftLeft(10).Add(new BigInteger(orderType.ToIntegerString()))
            .ShiftLeft(64).Add(new BigInteger(paramB.ToString()))
            .ShiftLeft(64).Add(new BigInteger(paramC.ToString()))
            .ShiftLeft(32).Add(new BigInteger((paramD / 3600).ToString()))
            .ShiftLeft(81).Add(BigInteger.Zero);
    }
}