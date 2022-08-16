namespace StarkEx.Client.SDK.Models.Spot.RequestModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Models.Spot.TransactionModels;

public class WithdrawalRequestModel : BaseRequestModel
{
    [JsonPropertyName("tx")]
    public WithdrawalModel Transaction { get; set; }
}