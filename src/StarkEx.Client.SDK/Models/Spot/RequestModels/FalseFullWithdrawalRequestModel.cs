namespace StarkEx.Client.SDK.Models.Spot.RequestModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Models.Spot.TransactionModels;

public class FalseFullWithdrawalRequestModel : BaseRequestModel
{
    [JsonPropertyName("tx")]
    public FalseFullWithdrawalModel Transaction { get; set; }
}