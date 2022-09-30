namespace StarkEx.Crypto.SDK.Hashing;

using Org.BouncyCastle.Math;

public interface ISpotTradingMessageHasher
{
    /// <summary>
    ///     Encode Limit Order with Fees
    /// </summary>
    /// <param name="assetIdSold">Id of the Asset sold.</param>
    /// <param name="assetIdBought">Id of the Asset bought.</param>
    /// <param name="assetIdUsedForFees">Id of the Asset used to pay for fees.</param>
    /// <param name="quantizedAmountSold">Quantized amount of the asset sold.</param>
    /// <param name="quantizedAmountBought">Quantized amount of the asset bought.</param>
    /// <param name="quantizedAmountUsedForFees">Quantized amount of the asset used to pay for fees.</param>
    /// <param name="nonce">Nonce used.</param>
    /// <param name="vaultIdUsedForFees">Id of the vault used for fees.</param>
    /// <param name="vaultIdUsedForSelling">Id of the vault used for selling.</param>
    /// <param name="vaultIdUsedForBuying">Id of the vault used for buying.</param>
    /// <param name="expirationTimestamp">Expiration timestamp in seconds since the Unix epoch</param>
    /// <returns>
    ///     Hash number
    /// </returns>
    BigInteger EncodeLimitOrderWithFees(
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
        int expirationTimestamp);

    /// <summary>
    ///     Encode Transfer transaction with Fees
    /// </summary>
    /// <param name="assetIdSold">Id of the Asset sold.</param>
    /// <param name="assetIdUsedForFees">Id of the Asset used to pay for fees.</param>
    /// <param name="receiverStarkKey">Stark Key of the transfer receiver.</param>
    /// <param name="vaultIdFromSender">Id of the vault used from the transfer sender.</param>
    /// <param name="vaultIdFromReceiver">Id of the vault used from the transfer receiver.</param>
    /// <param name="vaultIdUsedForFees">Id of the vault used to pay the fees.</param>
    /// <param name="nonce">Nonce used.</param>
    /// <param name="quantizedAmountToTransfer">Quantized amount to transfer.</param>
    /// <param name="quantizedAmountToLimitMaxFee">Quantized amount to limit max fee.</param>
    /// <param name="expirationTimestamp">Expiration timestamp in seconds since the Unix epoch.</param>
    /// <returns>
    ///     Hash number
    /// </returns>
    BigInteger EncodeTransferWithFees(
        string assetIdSold,
        string assetIdUsedForFees,
        string receiverStarkKey,
        BigInteger vaultIdFromSender,
        BigInteger vaultIdFromReceiver,
        BigInteger vaultIdUsedForFees,
        int nonce,
        BigInteger quantizedAmountToTransfer,
        BigInteger quantizedAmountToLimitMaxFee,
        int expirationTimestamp);

    /// <summary>
    ///     Encode Conditional Transfer transaction with Fees
    /// </summary>
    /// <param name="assetIdSold">Id of the Asset sold.</param>
    /// <param name="assetIdUsedForFees">Id of the Asset used to pay for fees.</param>
    /// <param name="receiverStarkKey">Stark Key of the transfer receiver.</param>
    /// <param name="vaultIdFromSender">Id of the vault used from the transfer sender.</param>
    /// <param name="vaultIdFromReceiver">Id of the vault used from the transfer receiver.</param>
    /// <param name="vaultIdUsedForFees">Id of the vault used to pay the fees.</param>
    /// <param name="nonce">Nonce used.</param>
    /// <param name="quantizedAmountToTransfer">Quantized amount to transfer.</param>
    /// <param name="quantizedAmountToLimitMaxFee">Quantized amount to limit max fee.</param>
    /// <param name="expirationTimestamp">Expiration timestamp in seconds since the Unix epoch.</param>
    /// <param name="fact">Transfer condition hex encoded.</param>
    /// //
    /// <param name="factRegistryAddress">Contract address to validate the fact hex encoded.</param>
    /// <returns>
    ///     Hash number
    /// </returns>
    BigInteger EncodeConditionalTransferWithFees(
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
        string factRegistryAddress);

    /// <summary>
    ///     Encode Conditional Transfer transaction with Fees.
    /// </summary>
    /// <param name="assetIdSold">Id of the Asset sold.</param>
    /// <param name="assetIdUsedForFees">Id of the Asset used to pay for fees.</param>
    /// <param name="receiverStarkKey">Stark Key of the transfer receiver.</param>
    /// <param name="vaultIdFromSender">Id of the vault used from the transfer sender.</param>
    /// <param name="vaultIdFromReceiver">Id of the vault used from the transfer receiver.</param>
    /// <param name="vaultIdUsedForFees">Id of the vault used to pay the fees.</param>
    /// <param name="nonce">Nonce used.</param>
    /// <param name="quantizedAmountToTransfer">Quantized amount to transfer.</param>
    /// <param name="quantizedAmountToLimitMaxFee">Quantized amount to limit max fee.</param>
    /// <param name="expirationTimestamp">Expiration timestamp in seconds since the Unix epoch.</param>
    /// <param name="condition">Perdersen hash of the contract address and fact.</param>
    /// //
    /// <returns>
    ///     Hash number.
    /// </returns>
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
        int expirationTimestamp);

    [Obsolete("Implementation obsolete, only implemented to test against Starkware Dataset")]
    BigInteger DeprecatedHashTransferOrder(
        string assetIdSold,
        string receiverStarkKey,
        BigInteger quantizedAmountSold,
        int nonce,
        BigInteger vaultIdUsedOfReceiver,
        BigInteger vaultIdUsedForBuying,
        int expirationTimestamp);

    [Obsolete("Implementation obsolete, only implemented to test against Starkware Dataset")]
    BigInteger DeprecatedHashConditionalTransfer(
        string assetIdSold,
        string receiverStarkKey,
        BigInteger quantizedAmountSold,
        int nonce,
        BigInteger vaultIdUsedOfReceiver,
        BigInteger vaultIdUsedForBuying,
        int expirationTimestamp,
        string condition);
}