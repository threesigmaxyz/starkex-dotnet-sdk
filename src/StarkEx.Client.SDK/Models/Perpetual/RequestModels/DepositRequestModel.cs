namespace StarkEx.Client.SDK.Models.Perpetual.RequestModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

public class DepositRequestModel : BaseRequestModel
{
    [JsonPropertyName("tx")]
    public DepositModel Transaction { get; set; }
}