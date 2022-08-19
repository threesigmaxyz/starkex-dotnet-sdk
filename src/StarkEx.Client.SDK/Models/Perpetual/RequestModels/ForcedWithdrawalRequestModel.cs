namespace StarkEx.Client.SDK.Models.Perpetual.RequestModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

public class ForcedWithdrawalRequestModel : BaseRequestModel
{
    [JsonPropertyName("tx")]
    public ForcedWithdrawalModel Transaction { get; set; }
}