namespace StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

using System.Text.Json.Serialization;

public class MultiTransactionModel : TransactionModel
{
    [JsonPropertyName("txs")]
    public IEnumerable<TransactionModel> Transactions { get; set; }

    [JsonPropertyName("type")]
    public override string Type => "MULTI_TRANSACTION";
}