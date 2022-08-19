namespace StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

using System.Numerics;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.JSON.Converter;

/// <summary>
///     Represents a single signed Oracle Price per unit.
/// </summary>
public class SignedOraclePrice
{
    /// <summary>
    ///     Gets or sets concatenation of the asset name and the oracle name (both in hex encoding).
    /// </summary>
    [JsonPropertyName("external_asset_id")]
    public string ExternalAssetId { get; set; }

    /// <summary>
    ///     Gets or sets the signed price.
    /// </summary>
    [JsonPropertyName("price")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger Price { get; set; }

    /// <summary>
    ///     Gets or sets represents a timestamped STARK-friendly ECDSA signature.
    /// </summary>
    [JsonPropertyName("timestamped_signature")]
    public TimestampedSignatureModel TimestampedSignature { get; set; }
}