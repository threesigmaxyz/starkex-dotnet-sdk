namespace StarkEx.Client.SDK.Models.Spot.RequestModels;

using System.Numerics;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.JSON.Converter;

public abstract class BaseRequestModel
{
    [JsonPropertyName("tx_id")]
    public long TransactionId { get; set; }
}