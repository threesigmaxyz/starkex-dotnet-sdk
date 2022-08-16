namespace StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

using System.Numerics;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.JSON.Converter;
using StarkEx.Commons.SDK.Models;

public class TimestampedSignatureModel
{
    [JsonPropertyName("signature")]
    public SignatureModel Signature { get; set; }

    [JsonPropertyName("timestamp")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger Timestamp { get; set; }
}