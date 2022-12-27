namespace StarkEx.Client.SDK.Models.Spot.FeederGatewayModels;

using System.Text.Json.Serialization;

/// <summary>
///     Information for a batch.
/// </summary>
public class BatchInfoResponseModel
{
    /// <summary>
    ///     Gets or sets the order root for the batch.
    /// </summary>
    [JsonPropertyName("order_root")]
    public RootModel OrderRoot { get; set; }

    /// <summary>
    ///     Gets or sets the previous batch id.
    /// </summary>
    [JsonPropertyName("prev_batch_id")]
    public int PrevBatchId { get; set; }

    /// <summary>
    ///     Gets or sets the previous order root.
    /// </summary>
    [JsonPropertyName("prev_order_root")]
    public RootModel PrevOrderRoot { get; set; }

    /// <summary>
    ///     Gets or sets the previous vault root.
    /// </summary>
    [JsonPropertyName("prev_vault_root")]
    public RootModel PrevVaultRoot { get; set; }

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

    /// <summary>
    ///     Gets or sets the vault root.
    /// </summary>
    [JsonPropertyName("vault_root")]
    public RootModel VaultRoot { get; set; }
}
