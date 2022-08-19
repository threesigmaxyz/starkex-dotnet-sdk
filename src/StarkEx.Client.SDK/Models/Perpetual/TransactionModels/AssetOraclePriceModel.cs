namespace StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

using System.Numerics;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.JSON.Converter;

public class AssetOraclePriceModel
{
    [JsonPropertyName("price")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger Price { get; set; }

    [JsonPropertyName("signed_prices")]
    public IDictionary<string, SignedOraclePrice> SignedPrices { get; set; }
}