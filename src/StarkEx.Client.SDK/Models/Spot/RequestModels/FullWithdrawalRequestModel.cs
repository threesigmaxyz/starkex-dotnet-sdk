namespace StarkEx.Client.SDK.Models.Spot.RequestModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Models.Spot.TransactionModels;

public class FullWithdrawalRequestModel : BaseRequestModel
{
    [JsonPropertyName("tx")]
    public FullWithdrawalModel Transaction { get; set; }
}