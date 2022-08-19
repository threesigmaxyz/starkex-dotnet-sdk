namespace StarkEx.Client.SDK.Models.Perpetual.AvailabilityModels;

using System.Numerics;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.JSON.Converter;

/// <summary>
///     Information describing position asset state.
/// </summary>
public class PositionAssetModel
{
    /// <summary>
    ///     Gets or sets quantized asset amount in the position.
    /// </summary>
    [JsonPropertyName("balance")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger Balance { get; set; }

    /// <summary>
    ///     Gets or sets a snapshot of the funding index at the last time that funding was applied on the position.
    /// </summary>
    [JsonPropertyName("cached_funding_index")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger CachedFundingIndex { get; set; }
}