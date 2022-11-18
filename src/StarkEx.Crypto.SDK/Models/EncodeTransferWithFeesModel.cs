namespace StarkEx.Crypto.SDK.Models;

using Org.BouncyCastle.Math;

public class EncodeTransferWithFeesModel
{
    public EncodeTransferWithFeesModel()
    {
    }

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