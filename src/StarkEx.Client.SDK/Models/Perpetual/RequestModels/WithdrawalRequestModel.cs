namespace StarkEx.Client.SDK.Models.Perpetual.RequestModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

public class WithdrawalRequestModel : BaseRequestModel
{
    [JsonPropertyName("tx")]
    public WithdrawalModel Transaction { get; set; }
}