namespace StarkEx.Client.SDK.Models.Spot.FeederGatewayModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Models.Spot.TransactionModels;

/// <summary>
///     Information for Transaction Info.
/// </summary>
public class TransactionInfoModel
{
    /// <summary>
    ///     Gets or sets the list of alternative transactions which replaced the original transaction.
    /// </summary>
    [JsonPropertyName("alt_txs")]
    public IEnumerable<TransactionModel> AltTxs { get; set; }

    /// <summary>
    ///     Gets or sets the transaction ID.
    /// </summary>
    [JsonPropertyName("tx_id")]
    public int TxId { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether a flag to indicate if the original transaction was replaced by alternative.
    /// </summary>
    [JsonPropertyName("was_replaced")]
    public bool WasReplaced { get; set; }

    /// <summary>
    ///     Gets or sets the original transaction.
    /// </summary>
    [JsonPropertyName("original_tx")]
    public TransactionModel OriginalTransaction { get; set; }
}
