namespace StarkEx.Crypto.SDK.Hashing;

using Org.BouncyCastle.Math;
using StarkEx.Crypto.SDK.Models;

public interface ISpotTradingMessageHasher
{
    /// <summary>
    ///     Encode Limit Order with Fees.
    /// </summary>
    /// <param name="encodeLimitOrderWithFeesModel"> Model to encode limit order with fees.</param>
    /// <returns>
    ///     Hash number.
    /// </returns>
    BigInteger EncodeLimitOrderWithFees(EncodeLimitOrderWithFeesModel encodeLimitOrderWithFeesModel);

    /// <summary>
    ///     Encode Transfer transaction with Fees.
    /// </summary>
    /// <param name="encodeTransferWithFeesModel"> Model to encode transfer with fees.</param>
    /// <returns>
    ///     Hash number.
    /// </returns>
    BigInteger EncodeTransferWithFees(EncodeTransferWithFeesModel encodeTransferWithFeesModel);

    /// <summary>
    ///     Encode Conditional Transfer transaction with Fees.
    /// </summary>
    /// <param name="encodeTransferWithFeesModel"> Model to encode transfer with fees.</param>
    /// <returns>
    ///     Hash number.
    /// </returns>
    BigInteger EncodeConditionalTransferWithFees(EncodeTransferWithFeesModel encodeTransferWithFeesModel);

     /// <summary>
    ///     Encode Conditional Transfer transaction with Fees.
    /// </summary>
    /// <param name="encodeTransferWithFeesModel"> Model to encode transfer with fees.</param>
    /// <param name="condition">Perdersen hash of the contract address and fact.</param>
    /// <returns>
    ///     Hash number.
    /// </returns>
    public BigInteger EncodeConditionalTransferWithFees(
         EncodeTransferWithFeesModel encodeTransferWithFeesModel,
         string condition);

    [Obsolete("Implementation obsolete, only implemented to test against Starkware Dataset")]
    BigInteger DeprecatedHashLimitOrder(
        string assetIdSold,
        string assetIdBought,
        BigInteger quantizedAmountSold,
        BigInteger quantizedAmountBought,
        int nonce,
        BigInteger vaultIdUsedForSelling,
        BigInteger vaultIdUsedForBuying,
        long expirationTimestamp);

    [Obsolete("Implementation obsolete, only implemented to test against Starkware Dataset")]
    BigInteger DeprecatedHashTransferOrder(
        string assetIdSold,
        string receiverStarkKey,
        BigInteger quantizedAmountSold,
        int nonce,
        BigInteger vaultIdUsedOfReceiver,
        BigInteger vaultIdUsedForBuying,
        long expirationTimestamp);

    [Obsolete("Implementation obsolete, only implemented to test against Starkware Dataset")]
    BigInteger DeprecatedHashConditionalTransfer(
        string assetIdSold,
        string receiverStarkKey,
        BigInteger quantizedAmountSold,
        int nonce,
        BigInteger vaultIdUsedOfReceiver,
        BigInteger vaultIdUsedForBuying,
        long expirationTimestamp,
        string condition);
}