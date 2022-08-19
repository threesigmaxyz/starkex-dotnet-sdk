namespace StarkEx.Client.SDK.Models.Perpetual.RequestModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

public class MultiTransactionRequestModel : BaseRequestModel
{
    [JsonPropertyName("tx")]
    public MultiTransactionModel Transaction { get; set; }
}