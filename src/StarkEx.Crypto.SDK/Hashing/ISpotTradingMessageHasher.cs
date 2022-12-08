namespace StarkEx.Crypto.SDK.Hashing;

using Org.BouncyCastle.Math;
using StarkEx.Crypto.SDK.Models;

/// <summary>
/// The <see cref="SpotTradingMessageHasher"/> class is a cryptographic utility that can be used to encode trading messages.
/// It relies on the <see cref="IPedersenHash"/> interface to perform cryptographic hashes.
/// </summary>
public interface ISpotTradingMessageHasher
{
    /// <summary>
    /// Encodes a limit order with fees using the specified <see cref="EncodeLimitOrderWithFeesModel"/> object.
    /// </summary>
    /// <param name="encodeLimitOrderWithFeesModel">The <see cref="EncodeLimitOrderWithFeesModel"/> object containing the values to use for encoding.</param>
    /// <returns>An integer representing the encoded message.</returns>
    BigInteger EncodeLimitOrderWithFees(EncodeLimitOrderWithFeesModel encodeLimitOrderWithFeesModel);

    /// <summary>
    /// Encodes a transfer with fees using the specified <see cref="EncodeTransferWithFeesModel"/> object.
    /// </summary>
    /// <param name="encodeTransferWithFeesModel">The <see cref="EncodeTransferWithFeesModel"/> object containing the values to use for encoding.</param>
    /// <returns>An integer representing the encoded message.</returns>
    BigInteger EncodeTransferWithFees(EncodeTransferWithFeesModel encodeTransferWithFeesModel);

    /// <summary>
    /// Encodes a conditional transfer with fees using the specified <see cref="EncodeTransferWithFeesModel"/> and condition values.
    /// The condition value is calculated using the fact and fact registry address provided in the model object.
    /// </summary>
    /// <param name="encodeTransferWithFeesModel">The <see cref="EncodeTransferWithFeesModel"/> object containing the values to use for encoding.</param>
    /// <returns>An integer representing the encoded message.</returns>
    BigInteger EncodeConditionalTransferWithFees(EncodeTransferWithFeesModel encodeTransferWithFeesModel);

    /// <summary>
    /// Encodes a conditional transfer with fees using the specified <see cref="EncodeTransferWithFeesModel"/> and condition values.
    /// </summary>
    /// <param name="encodeTransferWithFeesModel">The <see cref="EncodeTransferWithFeesModel"/> object containing the values to use for encoding.</param>
    /// <param name="condition">The condition value to use.</param>
    /// <returns>An integer representing the encoded message.</returns>
    public BigInteger EncodeConditionalTransferWithFees(
         EncodeTransferWithFeesModel encodeTransferWithFeesModel,
         string condition);

    /// <summary>
    /// Encodes a deprecated hash limit order using the specified values.
    /// </summary>
    /// <param name="assetIdSold">The ID of the asset that is being sold.</param>
    /// <param name="assetIdBought">The ID of the asset that is being bought.</param>
    /// <param name="quantizedAmountSold">The quantized amount of the asset that is being sold.</param>
    /// <param name="quantizedAmountBought">The quantized amount of the asset that is being bought.</param>
    /// <param name="nonce">The nonce value.</param>
    /// <param name="vaultIdUsedForSelling">The ID of the vault from which the asset is being sold.</param>
    /// <param name="vaultIdUsedForBuying">The ID of the vault from which the asset is being bought.</param>
    /// <param name="expirationTimestamp">The expiration timestamp of the order.</param>
    /// <returns>An integer representing the encoded message.</returns>
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

    /// <summary>
    /// Encodes a deprecated hash transfer order using the specified values.
    /// </summary>
    /// <param name="assetIdSold">The ID of the asset that is being sold.</param>
    /// <param name="receiverStarkKey">The Stark key of the receiver.</param>
    /// <param name="quantizedAmountSold">The quantized amount of the asset that is being sold.</param>
    /// <param name="nonce">The nonce value.</param>
    /// <param name="vaultIdUsedOfReceiver">The ID of the vault from which the asset is being received.</param>
    /// <param name="vaultIdUsedForBuying">The ID of the vault that is being used to buy the asset.</param>
    /// <param name="expirationTimestamp">The expiration timestamp of the order.</param>
    /// <returns>An integer representing the encoded message.</returns>
    [Obsolete("Implementation obsolete, only implemented to test against Starkware Dataset")]
    BigInteger DeprecatedHashTransferOrder(
        string assetIdSold,
        string receiverStarkKey,
        BigInteger quantizedAmountSold,
        int nonce,
        BigInteger vaultIdUsedOfReceiver,
        BigInteger vaultIdUsedForBuying,
        long expirationTimestamp);

    /// <summary>
    /// Encodes a deprecated hash conditional transfer using the specified values.
    /// </summary>
    /// <param name="assetIdSold">The ID of the asset that is being sold.</param>
    /// <param name="receiverStarkKey">The Stark key of the receiver.</param>
    /// <param name="quantizedAmountSold">The quantized amount of the asset that is being sold.</param>
    /// <param name="nonce">The nonce value.</param>
    /// <param name="vaultIdUsedOfReceiver">The ID of the vault from which the asset is being received.</param>
    /// <param name="vaultIdUsedForBuying">The ID of the vault that is being used to buy the asset.</param>
    /// <param name="expirationTimestamp">The expiration timestamp of the order.</param>
    /// <param name="condition">The condition of the transfer.</param>
    /// <returns>An integer representing the encoded message.</returns>
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