namespace StarkEx.Crypto.SDK.Models;

using Org.BouncyCastle.Math;

/// <summary>
/// A model representing a limit order that includes fees.
/// </summary>
public class EncodeLimitOrderWithFeesModel
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EncodeLimitOrderWithFeesModel"/> class.
    /// </summary>
    public EncodeLimitOrderWithFeesModel()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="EncodeLimitOrderWithFeesModel"/> class.
    /// </summary>
    /// <param name="assetIdSold">The id of the Asset sold.</param>
    /// <param name="assetIdBought">The id of the Asset bought.</param>
    /// <param name="assetIdUsedForFees">The id of the Asset used to pay for fees.</param>
    /// <param name="quantizedAmountSold">The quantized amount of the asset sold.</param>
    /// <param name="quantizedAmountBought">The quantized amount of the asset bought.</param>
    /// <param name="quantizedAmountUsedForFees">The quantized amount of the asset used to pay for fees.</param>
    /// <param name="nonce">The nonce used.</param>
    /// <param name="vaultIdUsedForFees">The Id of the vault used for fees.</param>
    /// <param name="vaultIdUsedForSelling">The Id of the vault used for selling.</param>
    /// <param name="vaultIdUsedForBuying">The Id of the vault used for buying.</param>
    /// <param name="expirationTimestamp">The expiration timestamp of the order.</param>
    public EncodeLimitOrderWithFeesModel(
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
        long expirationTimestamp)
    {
        AssetIdSold = assetIdSold;
        AssetIdBought = assetIdBought;
        AssetIdUsedForFees = assetIdUsedForFees;
        QuantizedAmountSold = quantizedAmountSold;
        QuantizedAmountBought = quantizedAmountBought;
        QuantizedAmountUsedForFees = quantizedAmountUsedForFees;
        Nonce = nonce;
        VaultIdUsedForFees = vaultIdUsedForFees;
        VaultIdUsedForSelling = vaultIdUsedForSelling;
        VaultIdUsedForBuying = vaultIdUsedForBuying;
        ExpirationTimestamp = expirationTimestamp;
    }

    /// <summary>
    /// Gets or sets the id of the Asset sold.
    /// </summary>
    public string AssetIdSold { get; set; }

    /// <summary>
    /// Gets or sets the id of the Asset bought.
    /// </summary>
    public string AssetIdBought { get; set; }

    /// <summary>
    /// Gets or sets the id of the Asset used to pay for fees.
    /// </summary>
    public string AssetIdUsedForFees { get; set; }

    /// <summary>
    /// Gets or sets the quantized amount of the asset sold.
    /// </summary>
    public BigInteger QuantizedAmountSold { get; set; }

    /// <summary>
    /// Gets or sets the quantized amount of the asset bought.
    /// </summary>
    public BigInteger QuantizedAmountBought { get; set; }

    /// <summary>
    /// Gets or sets the quantized amount of the asset used to pay for fees.
    /// </summary>
    public BigInteger QuantizedAmountUsedForFees { get; set; }

    /// <summary>
    /// Gets or sets the nonce used.
    /// </summary>
    public int Nonce { get; set; }

    /// <summary>
    /// Gets or sets the Id of the vault used for fees.
    /// </summary>
    public BigInteger VaultIdUsedForFees { get; set; }

    /// <summary>
    /// Gets or sets the Id of the vault used for selling.
    /// </summary>
    public BigInteger VaultIdUsedForSelling { get; set; }

    /// <summary>
    /// Gets or sets the Id of the vault used for buying.
    /// </summary>
    public BigInteger VaultIdUsedForBuying { get; set; }

    /// <summary>
    /// Gets or sets the Expiration timestamp in seconds since the Unix epoch.
    /// </summary>
    public long ExpirationTimestamp { get; set; }
}