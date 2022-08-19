namespace StarkEx.Client.SDK.Models.Perpetual.RequestModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

public class ConditionalTransferRequestModel : BaseRequestModel
{
    [JsonPropertyName("tx")]
    public ConditionalTransferModel Transaction { get; set; }
}