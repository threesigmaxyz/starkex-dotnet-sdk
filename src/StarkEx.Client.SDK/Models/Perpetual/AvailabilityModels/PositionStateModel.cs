namespace StarkEx.Client.SDK.Models.Perpetual.AvailabilityModels;

using System.Numerics;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.JSON.Converter;

/// <summary>
/// The information describing a position state.
/// </summary>
public class PositionStateModel
{
    /// <summary>
    /// Gets or sets information on each synthetic asset in the position.
    /// </summary>
    [JsonPropertyName("assets")]
    public IDictionary<string, PositionAssetModel> Assets { get; set; }

    /// <summary>
    /// Gets or sets the amount of the collateral asset in the position.
    /// </summary>
    [JsonPropertyName("collateral_balance")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger CollateralBalance { get; set; }

    /// <summary>
    /// Gets or sets public key of the position’s owner.
    /// </summary>
    [JsonPropertyName("public_key")]
    public string PublicKey { get; set; }
}
