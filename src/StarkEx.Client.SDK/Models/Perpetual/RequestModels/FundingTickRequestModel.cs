namespace StarkEx.Client.SDK.Models.Perpetual.RequestModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

public class FundingTickRequestModel : BaseRequestModel
{
    [JsonPropertyName("tx")]
    public FundingTickModel Transaction { get; set; }
}