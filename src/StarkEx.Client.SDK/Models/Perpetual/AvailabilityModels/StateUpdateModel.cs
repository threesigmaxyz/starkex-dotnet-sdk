namespace StarkEx.Client.SDK.Models.Perpetual.AvailabilityModels;

using System.Numerics;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.JSON.Converter;

/// <summary>
///     The information describing a state update.
/// </summary>
public class StateUpdateModel
{
    /// <summary>
    ///     Gets or sets expected order root after update (hex str without prefix).
    /// </summary>
    [JsonPropertyName("order_root")]
    public string OrderRoot { get; set; }

    /// <summary>
    ///     Gets or sets dictionary mapping order_id to order state.
    /// </summary>
    [JsonPropertyName("orders")]
    public IDictionary<string, OrderStateModel> Orders { get; set; }

    /// <summary>
    ///     Gets or sets expected position root after update (hex str without prefix).
    /// </summary>
    [JsonPropertyName("position_root")]
    public string PositionRoot { get; set; }

    /// <summary>
    ///     Gets or sets dictionary mapping position_id to position state.
    /// </summary>
    [JsonPropertyName("positions")]
    public IDictionary<string, PositionStateModel> Positions { get; set; }

    /// <summary>
    ///     Gets or sets previous batch ID.
    /// </summary>
    [JsonPropertyName("prev_batch_id")]
    [JsonConverter(typeof(BigIntegerConverter))]
    public BigInteger PrevBatchId { get; set; }
}