namespace StarkEx.Client.SDK.Models.Spot.AvailabilityGateway;

using System.Text.Json.Serialization;

/// <summary>
///     Information for a specific batch.
/// </summary>
public class BatchModel
{
    /// <summary>
    ///     Gets or sets state update.
    /// </summary>
    [JsonPropertyName("update")]
    public StateUpdateModel Update { get; set; }
}
