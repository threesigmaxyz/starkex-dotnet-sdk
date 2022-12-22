namespace StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

using System.Numerics;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.JSON.Converter;

/// <summary>
/// Represents a transaction that updates the oracle prices in the StarkEx Perpetual API.
/// </summary>
public class OraclePricesTickModel : TransactionModel
{
    /// <summary>
    /// Gets or sets the updated oracle prices.
    /// </summary>
    /// <value>
    /// The updated oracle prices.
    /// </value>
    /// <seealso cref="AssetOraclePriceModel"/>
    [JsonPropertyName("oracle_prices")]
    public IDictionary<string, AssetOraclePriceModel> OraclePrices { get; set; }

    /// <summary>
    /// Gets or sets the timestamp of the oracle prices update.
    /// </summary>
    /// <value>
    /// The timestamp of the oracle prices update.
    /// </value>
    [JsonPropertyName("timestamp")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger Timestamp { get; set; }

    /// <summary>
    /// Gets the type of the transaction.
    /// </summary>
    /// <value>
    /// The type of the transaction.
    /// </value>
    [JsonPropertyName("type")]
    public override string Type => "ORACLE_PRICES_TICK";
}
