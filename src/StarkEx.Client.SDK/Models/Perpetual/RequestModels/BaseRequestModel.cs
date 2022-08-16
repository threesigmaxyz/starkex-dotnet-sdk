namespace StarkEx.Client.SDK.Models.Perpetual.RequestModels;

using System.Numerics;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.JSON.Converter;

public abstract class BaseRequestModel
{
    [JsonPropertyName("tx_id")]
    [JsonConverter(typeof(BigIntegerConverter))]
    public BigInteger TransactionId { get; set; }
}