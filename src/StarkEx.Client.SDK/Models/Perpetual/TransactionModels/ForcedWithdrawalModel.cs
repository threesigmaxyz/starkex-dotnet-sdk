namespace StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

using System.Numerics;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.JSON.Converter;

public class ForcedWithdrawalModel : TransactionModel
{
    [JsonPropertyName("amount")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger Amount { get; set; }

    [JsonPropertyName("is_valid")]
    public bool IsValid { get; set; }

    [JsonPropertyName("position_id")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger PositionId { get; set; }

    [JsonPropertyName("public_key")]
    public string PublicKey { get; set; }

    [JsonPropertyName("type")]
    public override string Type => "FORCED_WITHDRAWAL";
}