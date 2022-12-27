namespace StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

using System.Numerics;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.JSON.Converter;

/// <summary>
/// Represents a model for an oracle price of an asset in the StarkEx Perpetual API.
/// </summary>
public class AssetOraclePriceModel
{
    /// <summary>
    /// Gets or sets the price of the asset.
    /// </summary>
    /// <value>
    /// The price of the asset.
    /// </value>
    [JsonPropertyName("price")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger Price { get; set; }

    /// <summary>
    /// Gets or sets the signed prices of the asset.
    /// </summary>
    /// <value>
    /// The signed prices of the asset.
    /// </value>
    /// <seealso cref="SignedOraclePrice"/>
    [JsonPropertyName("signed_prices")]
    public IDictionary<string, SignedOraclePrice> SignedPrices { get; set; }
}
