namespace StarkEx.Client.SDK.Models.Spot.RequestModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Models.Spot.TransactionModels;

public class DepositRequestModel : BaseRequestModel
{
    [JsonPropertyName("tx")]
    public DepositModel Transaction { get; set; }
}