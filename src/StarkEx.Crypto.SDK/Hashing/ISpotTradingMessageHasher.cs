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
    /// Encodes a limit order with fees using the specified <see cref="EncodeLimitOrderModel"/> object.
    /// </summary>
    /// <param name="encodeLimitOrderModel">The <see cref="EncodeLimitOrderModel"/> object containing the values to use for encoding.</param>
    /// <returns>An integer representing the encoded message.</returns>
    BigInteger EncodeLimitOrder(EncodeLimitOrderModel encodeLimitOrderModel);

    /// <summary>
    /// Encodes a transfer with fees using the specified <see cref="EncodeTransferModel"/> object.
    /// </summary>
    /// <param name="encodeTransferModel">The <see cref="EncodeTransferModel"/> object containing the values to use for encoding.</param>
    /// <returns>An integer representing the encoded message.</returns>
    BigInteger EncodeTransfer(EncodeTransferModel encodeTransferModel);

    /// <summary>
    /// Encodes a conditional transfer with fees using the specified <see cref="EncodeTransferModel"/> and condition values.
    /// The condition value is calculated using the fact and fact registry address provided in the model object.
    /// </summary>
    /// <param name="encodeTransferModel">The <see cref="EncodeTransferModel"/> object containing the values to use for encoding.</param>
    /// <returns>An integer representing the encoded message.</returns>
    BigInteger EncodeConditionalTransfer(EncodeTransferModel encodeTransferModel);

    /// <summary>
    /// Encodes a conditional transfer with fees using the specified <see cref="EncodeTransferModel"/> and condition values.
    /// </summary>
    /// <param name="encodeTransferModel">The <see cref="EncodeTransferModel"/> object containing the values to use for encoding.</param>
    /// <param name="condition">The condition value to use.</param>
    /// <returns>An integer representing the encoded message.</returns>
    public BigInteger EncodeConditionalTransfer(
         EncodeTransferModel encodeTransferModel,
         string condition);

    /// <summary>
    /// Encodes a conditional transfer without fees using the specified <see cref="EncodeTransferWithoutFeesModel"/> and condition values.
    /// </summary>
    /// <param name="encodeTransferWithoutFeesModel">The <see cref="EncodeTransferWithoutFeesModel"/> object containing the values to use for encoding.</param>
    /// <param name="condition">The condition value to use.</param>
    /// <returns>An integer representing the encoded message.</returns>
    [Obsolete("Implementation obsolete, only implemented to test against Starkware Dataset")]
    public BigInteger EncodeConditionalTransferWithoutFees(
        EncodeTransferWithoutFeesModel encodeTransferWithoutFeesModel,
        string condition);

    /// <summary>
    /// Encodes a conditional transfer without fees using the specified <see cref="EncodeTransferWithoutFeesModel"/> and condition values.
    /// The condition value is calculated using the fact and fact registry address provided in the model object.
    /// </summary>
    /// <param name="encodeTransferWithoutFeesModel">The <see cref="EncodeTransferWithoutFeesModel"/> object containing the values to use for encoding.</param>
    /// <returns>An integer representing the encoded message.</returns>
    [Obsolete("Implementation obsolete, only implemented to test against Starkware Dataset")]
    BigInteger EncodeConditionalTransferWithoutFees(EncodeTransferWithoutFeesModel encodeTransferWithoutFeesModel);

    /// <summary>
    /// Encodes a transfer without fees using the specified <see cref="EncodeTransferWithoutFeesModel"/> object.
    /// </summary>
    /// <param name="encodeTransferWithoutFeesModel">The <see cref="EncodeTransferWithoutFeesModel"/> object containing the values to use for encoding.</param>
    /// <returns>An integer representing the encoded message.</returns>
    [Obsolete("Implementation obsolete, only implemented to test against Starkware Dataset")]
    BigInteger EncodeTransferWithoutFees(EncodeTransferWithoutFeesModel encodeTransferWithoutFeesModel);

    /// <summary>
    /// Encodes a limit order without fees using the specified <see cref="EncodeLimitOrderWithoutFeesModel"/> object.
    /// </summary>
    /// <param name="encodeLimitOrderWithoutFeesModel">The <see cref="EncodeLimitOrderWithoutFeesModel"/> object containing the values to use for encoding.</param>
    /// <returns>An integer representing the encoded message.</returns>
    [Obsolete("Implementation obsolete, only implemented to test against Starkware Dataset")]
    BigInteger EncodeLimitOrderWithoutFees(EncodeLimitOrderWithoutFeesModel encodeLimitOrderWithoutFeesModel);
}
