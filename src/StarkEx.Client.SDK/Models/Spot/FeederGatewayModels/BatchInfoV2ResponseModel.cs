namespace StarkEx.Client.SDK.Models.Spot.FeederGatewayModels;

using System.Text.Json.Serialization;

/// <summary>
///     Alternative version for information of a batch.
/// </summary>
public class BatchInfoV2ResponseModel
{
    /// <summary>
    ///     Gets or sets previous batch id.
    /// </summary>
    [JsonPropertyName("prev_batch_id")]
    public int PrevBatchId { get; set; }

    /// <summary>
    ///     Gets or sets the sequence number.
    /// </summary>
    [JsonPropertyName("sequence_number")]
    public int SequenceNumber { get; set; }

    /// <summary>
    ///     Gets or sets the time when the batch was created.
    /// </summary>
    [JsonPropertyName("time_created")]
    public int TimeCreated { get; set; }

    /// <summary>
    ///     Gets or sets the information of the transactions in the batch.
    /// </summary>
    [JsonPropertyName("txs_info")]
    public IEnumerable<TransactionInfoModel> Transactions { get; set; }
}