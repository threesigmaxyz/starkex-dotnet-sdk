namespace StarkEx.Client.SDK.Models.Perpetual.ResponseModels;

using System.Numerics;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.JSON.Converter;

/// <summary>
///     Information on a Batch.
/// </summary>
public class BatchInfoResponseModel
{
    /// <summary>
    ///     Gets or sets the order root of the batch.
    /// </summary>
    [JsonPropertyName("order_root")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger OrderRoot { get; set; }

    /// <summary>
    ///     Gets or sets the position root of the batch.
    /// </summary>
    [JsonPropertyName("position_root")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger PositionRoot { get; set; }

    /// <summary>
    ///     Gets or sets the batch ID of the previous batch.
    /// </summary>
    [JsonPropertyName("previous_batch_id")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger PreviousBatchId { get; set; }

    /// <summary>
    ///     Gets or sets the order root of the previous batch.
    /// </summary>
    [JsonPropertyName("previous_order_root")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger PreviousOrderRoot { get; set; }

    /// <summary>
    ///     Gets or sets the position root of the previous batch.
    /// </summary>
    [JsonPropertyName("previous_position_root")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger PreviousPositionRoot { get; set; }

    /// <summary>
    ///     Gets or sets the sequence number of the previous batch.
    /// </summary>
    [JsonPropertyName("sequence_number")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger SequenceNumber { get; set; }

    /// <summary>
    ///     Gets or sets the time when the batch was created.
    /// </summary>
    [JsonPropertyName("time_created")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger TimeCreated { get; set; }

    /// <summary>
    ///     Gets or sets the list of the transactions included in the batch.
    /// </summary>
    [JsonPropertyName("txs_info")]
    public IEnumerable<TransactionInfoModel> TxsInfo { get; set; }
}