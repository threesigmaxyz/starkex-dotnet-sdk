namespace StarkEx.Client.SDK.Models.Spot.FeederGatewayModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.JSON.Converter;

/// <summary>
///     Batch IDs matching the input vaults root, order root and sequence number.
/// </summary>
[JsonConverter(typeof(BatchIdsConverter))]
public class BatchIdsResponseModel
{
    /// <summary>
    ///     Gets or sets list of batch IDs.
    /// </summary>
    public IEnumerable<int> BatchIds { get; set; }
}