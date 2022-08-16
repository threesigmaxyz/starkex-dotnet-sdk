namespace StarkEx.Client.SDK.Models.Perpetual.RequestModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

public class ForcedTradeRequestModel : BaseRequestModel
{
    [JsonPropertyName("tx")]
    public ForcedTradeModel Transaction { get; set; }
}