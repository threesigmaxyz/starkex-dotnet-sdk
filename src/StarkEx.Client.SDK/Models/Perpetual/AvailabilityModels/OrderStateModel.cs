namespace StarkEx.Client.SDK.Models.Perpetual.AvailabilityModels;

using System.Numerics;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.JSON.Converter;

/// <summary>
/// Information describing the order state.
/// </summary>
public class OrderStateModel
{
    /// <summary>
    /// Gets or sets order fulfilled amount.
    /// </summary>
    [JsonPropertyName("fulfilled_amount")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger FulfilledAmount { get; set; }
}
