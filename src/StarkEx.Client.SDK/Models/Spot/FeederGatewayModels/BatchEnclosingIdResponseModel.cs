namespace StarkEx.Client.SDK.Models.Spot.FeederGatewayModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.JSON.Converter;

/// <summary>
///     Information for the enclosing IDs of a batch.
/// </summary>
[JsonConverter(typeof(BatchEnclosingIdConverter))]
public class BatchEnclosingIdResponseModel
{
    /// <summary>
    ///     Gets or sets the first ID of the batch.
    /// </summary>
    public int FirstId { get; set; }

    /// <summary>
    ///     Gets or sets the last ID of the batch.
    /// </summary>
    public int LastId { get; set; }
}
