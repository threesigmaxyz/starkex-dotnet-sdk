namespace StarkEx.Crypto.SDK.Models;

using Org.BouncyCastle.Math;

/// <summary>
/// A model representing a limit order without fees.
/// </summary>
public class EncodeLimitOrderWithoutFeesModel
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EncodeLimitOrderWithoutFeesModel"/> class.
    /// </summary>
    public EncodeLimitOrderWithoutFeesModel()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="EncodeLimitOrderWithoutFeesModel"/> class.
    /// </summary>
    /// <param name="assetIdSold">The id of the Asset sold.</param>
    /// <param name="assetIdBought">The id of the Asset bought.</param>
    /// <param name="quantizedAmountSold">The quantized amount of the asset sold.</param>
    /// <param name="quantizedAmountBought">The quantized amount of the asset bought.</param>
    /// <param name="nonce">The nonce used.</param>
    /// <param name="vaultIdUsedForSelling">The Id of the vault used for selling.</param>
    /// <param name="vaultIdUsedForBuying">The Id of the vault used for buying.</param>
    /// <param name="expirationTimestamp">The expiration timestamp of the order.</param>
    public EncodeLimitOrderWithoutFeesModel(
        string assetIdSold,
        string assetIdBought,
        BigInteger quantizedAmountSold,
        BigInteger quantizedAmountBought,
        uint nonce,
        BigInteger vaultIdUsedForSelling,
        BigInteger vaultIdUsedForBuying,
        long expirationTimestamp)
    {
        AssetIdSold = assetIdSold;
        AssetIdBought = assetIdBought;
        QuantizedAmountSold = quantizedAmountSold;
        QuantizedAmountBought = quantizedAmountBought;
        Nonce = nonce;
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
    /// Gets or sets the quantized amount of the asset sold.
    /// </summary>
    public BigInteger QuantizedAmountSold { get; set; }

    /// <summary>
    /// Gets or sets the quantized amount of the asset bought.
    /// </summary>
    public BigInteger QuantizedAmountBought { get; set; }

    /// <summary>
    /// Gets or sets the nonce used.
    /// </summary>
    public uint Nonce { get; set; }

    public BigInteger VaultIdUsedForSelling { get; set; }

    public BigInteger VaultIdUsedForBuying { get; set; }

    /// <summary>
    /// Gets or sets the Expiration timestamp in seconds since the Unix epoch.
    /// </summary>
    public long ExpirationTimestamp { get; set; }
}
