namespace StarkEx.Client.SDK.Models.Spot.AvailabilityGateway;

using System.Text.Json.Serialization;

/// <summary>
///     The information describing a state update.
/// </summary>
public class StateUpdateModel
{
    /// <summary>
    ///     Gets or sets iD of the previous batch in chronological order.
    /// </summary>
    [JsonPropertyName("prev_batch_id")]
    public int PrevBatchId { get; set; }

    /// <summary>
    ///     Gets or sets expected order tree root after update.
    /// </summary>
    [JsonPropertyName("order_root")]
    public string OrderRoot { get; set; }

    /// <summary>
    ///     Gets or sets orders that were included in the requested batch.
    /// </summary>
    [JsonPropertyName("orders")]
    public IDictionary<string, OrderStateModel> Orders { get; set; }

    /// <summary>
    ///     Gets or sets expected rollup vault root after update.
    /// </summary>
    [JsonPropertyName("rollup_vault_root")]
    public string RollupVaultRoot { get; set; }

    /// <summary>
    ///     Gets or sets dictionary mapping vault IDs to vault state.
    /// </summary>
    [JsonPropertyName("rollup_vaults")]
    public IDictionary<string, VaultStateModel> RollupVaults { get; set; }

    /// <summary>
    ///     Gets or sets expected validium/volution vault root after update.
    /// </summary>
    [JsonPropertyName("vault_root")]
    public string VaultRoot { get; set; }

    /// <summary>
    ///     Gets or sets dictionary mapping vault IDs to vault state.
    /// </summary>
    [JsonPropertyName("vaults")]
    public IDictionary<string, VaultStateModel> Vaults { get; set; }
}