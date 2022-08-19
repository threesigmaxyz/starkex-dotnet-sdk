namespace StarkEx.Client.SDK.Models.Spot.TransactionModels;

using System.Numerics;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.JSON.Converter;

public class MintModel : TransactionModel
{
    [JsonPropertyName("amount")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger Amount { get; set; }

    [JsonPropertyName("stark_key")]
    public string StarkKey { get; set; }

    [JsonPropertyName("token_id")]
    public string TokenId { get; set; }

    [JsonPropertyName("type")]
    public override string Type => "MintRequest";

    [JsonPropertyName("vault_id")]
    [JsonConverter(typeof(BigIntegerConverter))]
    public BigInteger VaultId { get; set; }
}