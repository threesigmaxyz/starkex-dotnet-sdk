namespace StarkEx.Client.SDK.Models.Spot.TransactionModels;

using System.Text.Json.Serialization;

/// <summary>
/// Represents a transaction that contains multiple sub-transactions in the StarkEx Spot API.
/// </summary>
public class MultiTransactionModel : TransactionModel
{
    /// <summary>
    /// Gets or sets the sub-transactions contained in the multi-transaction.
    /// </summary>
    /// <value>
    /// The sub-transactions contained in the multi-transaction.
    /// </value>
    /// <seealso cref="TransactionModel"/>
    [JsonPropertyName("txs")]
    public IList<TransactionModel> Transactions { get; set; }

    /// <summary>
    /// Gets the type of the transaction.
    /// </summary>
    /// <value>
    /// The type of the transaction.
    /// </value>
    [JsonPropertyName("type")]
    public override string Type => "MultiTransactionRequest";
}
