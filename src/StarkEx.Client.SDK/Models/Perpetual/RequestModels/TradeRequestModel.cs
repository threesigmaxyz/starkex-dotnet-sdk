namespace StarkEx.Client.SDK.Models.Perpetual.RequestModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

public class TradeRequestModel : BaseRequestModel
{
    [JsonPropertyName("tx")]
    public TradeModel Transaction { get; set; }
}