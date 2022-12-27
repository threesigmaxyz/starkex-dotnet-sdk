namespace StarkEx.Client.SDK.Models.Perpetual.ResponseModels;

using System.Numerics;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.JSON.Converter;
using StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

/// <summary>
/// Represents a response model with information about a transaction in the StarkEx Perpetual API.
/// </summary>
public class TransactionInfoModel
{
    /// <summary>
    /// Gets or sets the alternative transactions that replaced the original transaction.
    /// </summary>
    /// <value>
    /// The alternative transactions that replaced the original transaction.
    /// </value>
    /// <seealso cref="TransactionModel"/>
    [JsonPropertyName("alt_txs")]
    public IEnumerable<TransactionModel> AltTxs { get; set; }

    /// <summary>
    /// Gets or sets the original transaction.
    /// </summary>
    /// <value>
    /// The original transaction.
    /// </value>
    [JsonPropertyName("original_tx")]
    public TransactionModel OriginalTx { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the original transaction.
    /// </summary>
    /// <value>
    /// The identifier of the original transaction.
    /// </value>
    [JsonPropertyName("original_tx_id")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger OriginalTxId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the original transaction was replaced by alternative transactions.
    /// </summary>
    /// <value>
    /// <c>true</c> if the original transaction was replaced; otherwise, <c>false</c>.
    /// </value>
    [JsonPropertyName("was_replaced")]
    public bool WasReplaced { get; set; }
}
