namespace StarkEx.Client.SDK.Models.Spot.TransactionModels;

using System.Text.Json.Serialization;

public class MultiTransactionModel : TransactionModel
{
    [JsonPropertyName("txs")]
    public IList<TransactionModel> Transactions { get; set; }

    [JsonPropertyName("type")]
    public override string Type => "MultiTransactionRequest";
}