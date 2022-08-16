namespace StarkEx.Client.SDK.Models.Perpetual.RequestModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

public class OraclePricesTickRequestModel : BaseRequestModel
{
    [JsonPropertyName("tx")]
    public OraclePricesTickModel Transaction { get; set; }
}