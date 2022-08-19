namespace StarkEx.Client.SDK.Models.Spot.RequestModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Models.Spot.TransactionModels;

public class TransferRequestModel : BaseRequestModel
{
    [JsonPropertyName("tx")]
    public TransferModel Transaction { get; set; }
}