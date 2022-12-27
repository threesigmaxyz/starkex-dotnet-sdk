namespace StarkEx.Client.SDK.Models.Spot.AvailabilityGateway;

using System.Numerics;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.JSON.Converter;

/// <summary>
///     A leaf of the orders tree.
///     May represent either the fulfillment state of an order or the minted state of a mintable asset.
/// </summary>
public class OrderStateModel
{
    /// <summary>
    ///     Gets or sets if the leaf represents an order, this is the amount fulfilled.
    ///     If the leaf represents a mintable asset, this is the amount minted.
    /// </summary>
    [JsonPropertyName("fulfilled_amount")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger FulfilledAmount { get; set; }
}
