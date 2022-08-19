namespace StarkEx.Client.SDK.Models.Spot.RequestModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Models.Spot.TransactionModels;

public class MultiTransactionRequestModel : BaseRequestModel
{
    [JsonPropertyName("tx")]
    public MultiTransactionModel Transaction { get; set; }
}