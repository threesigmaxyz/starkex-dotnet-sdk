namespace StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

using System.Numerics;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.JSON.Converter;

public class OraclePricesTickModel : TransactionModel
{
    [JsonPropertyName("oracle_prices")]
    public IDictionary<string, AssetOraclePriceModel> OraclePrices { get; set; }

    [JsonPropertyName("timestamp")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger Timestamp { get; set; }

    [JsonPropertyName("type")]
    public override string Type => "ORACLE_PRICES_TICK";
}