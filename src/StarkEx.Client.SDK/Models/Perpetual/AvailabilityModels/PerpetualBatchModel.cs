namespace StarkEx.Client.SDK.Models.Perpetual.AvailabilityModels;

using System.Text.Json.Serialization;

/// <summary>
/// Information for a specific batch.
/// </summary>
public class PerpetualBatchModel
{
    /// <summary>
    /// Gets or sets state update.
    /// </summary>
    [JsonPropertyName("update")]
    public StateUpdateModel Update { get; set; }
}
