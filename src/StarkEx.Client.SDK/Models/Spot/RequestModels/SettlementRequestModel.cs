namespace StarkEx.Client.SDK.Models.Spot.RequestModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Models.Spot.TransactionModels;

public class SettlementRequestModel : BaseRequestModel
{
    [JsonPropertyName("tx")]
    public SettlementModel Transaction { get; set; }
}