namespace StarkEx.Client.SDK.Models.Perpetual.RequestModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

public class LiquidateRequestModel : BaseRequestModel
{
    [JsonPropertyName("tx")]
    public LiquidateModel Transaction { get; set; }
}