namespace StarkEx.Client.SDK.Models.Perpetual.RequestModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

public class TransferRequestModel : BaseRequestModel
{
    [JsonPropertyName("tx")]
    public TransferModel Transaction { get; set; }
}