namespace StarkEx.Client.SDK.Models.Spot.RequestModels;

using System.Text.Json.Serialization;

public abstract class BaseRequestModel
{
    [JsonPropertyName("tx_id")]
    public long TransactionId { get; set; }
}