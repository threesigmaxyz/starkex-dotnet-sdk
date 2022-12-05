namespace StarkEx.Crypto.SDK.Models;

using Org.BouncyCastle.Math;

public class EncodeTransferWithFeesModel
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EncodeTransferWithFeesModel"/> class.
    /// </summary>
    public EncodeTransferWithFeesModel()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="EncodeTransferWithFeesModel"/> class.
    /// </summary>
    /// <param name="assetIdSold">The id of the Asset sold.</param>
    /// <param name="assetIdUsedForFees">The id of the Asset used to pay for fees.</param>
    /// <param name="receiverStarkKey">The Stark Key of the transfer receiver.</param>
    /// <param name="vaultIdFromSender">The id of the vault used from the transfer sender.</param>
    /// <param name="vaultIdFromReceiver">The id of the vault used from the transfer receiver.</param>
    /// <param name="vaultIdUsedForFees">The id of the vault used to pay the fees.</param>
    /// <param name="nonce">The nonce used.</param>
    /// <param name="quantizedAmountToTransfer">The id of the Quantized amount to transfer.</param>
    /// <param name="quantizedAmountToLimitMaxFee">The id of the Quantized amount to limit max fee.</param>
    /// <param name="expirationTimestamp">The id of the Expiration timestamp in seconds since the Unix epoch.</param>
    public EncodeTransferWithFeesModel(
        string assetIdSold,
        string assetIdUsedForFees,
        string receiverStarkKey,
        BigInteger vaultIdFromSender,
        BigInteger vaultIdFromReceiver,
        BigInteger vaultIdUsedForFees,
        int nonce,
        BigInteger quantizedAmountToTransfer,
        BigInteger quantizedAmountToLimitMaxFee,
        long expirationTimestamp)
    {
        AssetIdSold = assetIdSold;
        AssetIdUsedForFees = assetIdUsedForFees;
        ReceiverStarkKey = receiverStarkKey;
        VaultIdFromSender = vaultIdFromSender;
        VaultIdFromReceiver = vaultIdFromReceiver;
        Nonce = nonce;
        QuantizedAmountToTransfer = quantizedAmountToTransfer;
        QuantizedAmountToLimitMaxFee = quantizedAmountToLimitMaxFee;
        VaultIdUsedForFees = vaultIdUsedForFees;
        ExpirationTimestamp = expirationTimestamp;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="EncodeTransferWithFeesModel"/> class.
    /// </summary>
    /// <param name="assetIdSold">The id of the Asset sold.</param>
    /// <param name="assetIdUsedForFees">The id of the Asset used to pay for fees.</param>
    /// <param name="receiverStarkKey">The Stark Key of the transfer receiver.</param>
    /// <param name="vaultIdFromSender">The id of the vault used from the transfer sender.</param>
    /// <param name="vaultIdFromReceiver">The id of the vault used from the transfer receiver.</param>
    /// <param name="vaultIdUsedForFees">The id of the vault used to pay the fees.</param>
    /// <param name="nonce">The nonce used.</param>
    /// <param name="quantizedAmountToTransfer">The id of the Quantized amount to transfer.</param>
    /// <param name="quantizedAmountToLimitMaxFee">The id of the Quantized amount to limit max fee.</param>
    /// <param name="expirationTimestamp">The id of the Expiration timestamp in seconds since the Unix epoch.</param>
    /// <param name="fact">The fact to be proven.</param>
    /// <param name="factRegistryAddress">The address of the fact registry contract.</param>
    public EncodeTransferWithFeesModel(
        string assetIdSold,
        string assetIdUsedForFees,
        string receiverStarkKey,
        BigInteger vaultIdFromSender,
        BigInteger vaultIdFromReceiver,
        BigInteger vaultIdUsedForFees,
        int nonce,
        BigInteger quantizedAmountToTransfer,
        BigInteger quantizedAmountToLimitMaxFee,
        long expirationTimestamp,
        string fact,
        string factRegistryAddress)
    {
        AssetIdSold = assetIdSold;
        AssetIdUsedForFees = assetIdUsedForFees;
        ReceiverStarkKey = receiverStarkKey;
        VaultIdFromSender = vaultIdFromSender;
        VaultIdFromReceiver = vaultIdFromReceiver;
        Nonce = nonce;
        QuantizedAmountToTransfer = quantizedAmountToTransfer;
        QuantizedAmountToLimitMaxFee = quantizedAmountToLimitMaxFee;
        VaultIdUsedForFees = vaultIdUsedForFees;
        ExpirationTimestamp = expirationTimestamp;
        Fact = fact;
        FactRegistryAddress = factRegistryAddress;
    }

    /// <summary>
    /// Gets or sets the id of the Asset sold.
    /// </summary>
    public string AssetIdSold { get; set; }

    /// <summary>
    /// Gets or sets the id of the Asset used to pay for fees.
    /// </summary>
    public string AssetIdUsedForFees { get; set; }

    /// <summary>
    /// Gets or sets the Stark Key of the transfer receiver.
    /// </summary>
    public string ReceiverStarkKey { get; set; }

    /// <summary>
    /// Gets or sets the id of the vault used to pay the fees.
    /// </summary>
    public BigInteger VaultIdUsedForFees { get; set; }

    /// <summary>
    /// Gets or sets the id of the vault used from the transfer sender.
    /// </summary>
    public BigInteger VaultIdFromSender { get; set; }

    /// <summary>
    /// Gets or sets the id of the vault used from the transfer receiver.
    /// </summary>
    public BigInteger VaultIdFromReceiver { get; set; }

    /// <summary>
    /// Gets or sets the nonce used.
    /// </summary>
    public int Nonce { get; set; }

    /// <summary>
    /// Gets or sets the id of the Quantized amount to transfer.
    /// </summary>
    public BigInteger QuantizedAmountToTransfer { get; set; }

    /// <summary>
    /// Gets or sets the id of the Quantized amount to limit max fee.
    /// </summary>
    public BigInteger QuantizedAmountToLimitMaxFee { get; set; }

    /// <summary>
    /// Gets or sets the id of the Expiration timestamp in seconds since the Unix epoch.
    /// </summary>
    public long ExpirationTimestamp { get; set; }

    /// <summary>
    /// Gets or sets the Transfer condition hex encoded.
    /// </summary>
    public string Fact { get; set; }

    /// <summary>
    /// Gets or sets the Contract address to validate the fact hex encoded.
    /// </summary>
    public string FactRegistryAddress { get; set; }
}