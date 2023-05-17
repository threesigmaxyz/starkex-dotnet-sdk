namespace StarkEx.Crypto.SDK.Models;

using Org.BouncyCastle.Math;

public class EncodeTransferWithoutFeesModel
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EncodeTransferWithoutFeesModel"/> class.
    /// </summary>
    public EncodeTransferWithoutFeesModel()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="EncodeTransferWithoutFeesModel"/> class.
    /// </summary>
    /// <param name="assetIdSold">The id of the Asset sold.</param>
    /// <param name="receiverStarkKey">The Stark Key of the transfer receiver.</param>
    /// <param name="vaultIdFromSender">The id of the vault used from the transfer sender.</param>
    /// <param name="vaultIdFromReceiver">The id of the vault used from the transfer receiver.</param>
    /// <param name="nonce">The nonce used.</param>
    /// <param name="quantizedAmountToTransfer">The id of the Quantized amount to transfer.</param>
    /// <param name="expirationTimestamp">The id of the Expiration timestamp in seconds since the Unix epoch.</param>
    public EncodeTransferWithoutFeesModel(
        string assetIdSold,
        string receiverStarkKey,
        BigInteger vaultIdFromSender,
        BigInteger vaultIdFromReceiver,
        uint nonce,
        BigInteger quantizedAmountToTransfer,
        long expirationTimestamp)
    {
        AssetIdSold = assetIdSold;
        ReceiverStarkKey = receiverStarkKey;
        VaultIdFromSender = vaultIdFromSender;
        VaultIdFromReceiver = vaultIdFromReceiver;
        Nonce = nonce;
        QuantizedAmountToTransfer = quantizedAmountToTransfer;
        ExpirationTimestamp = expirationTimestamp;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="EncodeTransferWithoutFeesModel"/> class.
    /// </summary>
    /// <param name="assetIdSold">The id of the Asset sold.</param>
    /// <param name="receiverStarkKey">The Stark Key of the transfer receiver.</param>
    /// <param name="vaultIdFromSender">The id of the vault used from the transfer sender.</param>
    /// <param name="vaultIdFromReceiver">The id of the vault used from the transfer receiver.</param>
    /// <param name="nonce">The nonce used.</param>
    /// <param name="quantizedAmountToTransfer">The id of the Quantized amount to transfer.</param>
    /// <param name="expirationTimestamp">The id of the Expiration timestamp in seconds since the Unix epoch.</param>
    /// <param name="fact">The fact to be proven.</param>
    /// <param name="factRegistryAddress">The address of the fact registry contract.</param>
    public EncodeTransferWithoutFeesModel(
        string assetIdSold,
        string receiverStarkKey,
        BigInteger vaultIdFromSender,
        BigInteger vaultIdFromReceiver,
        uint nonce,
        BigInteger quantizedAmountToTransfer,
        long expirationTimestamp,
        string fact,
        string factRegistryAddress)
    {
        AssetIdSold = assetIdSold;
        ReceiverStarkKey = receiverStarkKey;
        VaultIdFromSender = vaultIdFromSender;
        VaultIdFromReceiver = vaultIdFromReceiver;
        Nonce = nonce;
        QuantizedAmountToTransfer = quantizedAmountToTransfer;
        ExpirationTimestamp = expirationTimestamp;
        Fact = fact;
        FactRegistryAddress = factRegistryAddress;
    }

    /// <summary>
    /// Gets or sets the id of the Asset sold.
    /// </summary>
    public string AssetIdSold { get; set; }

    /// <summary>
    /// Gets or sets the Stark Key of the transfer receiver.
    /// </summary>
    public string ReceiverStarkKey { get; set; }

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
    public uint Nonce { get; set; }

    /// <summary>
    /// Gets or sets the id of the Quantized amount to transfer.
    /// </summary>
    public BigInteger QuantizedAmountToTransfer { get; set; }

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
