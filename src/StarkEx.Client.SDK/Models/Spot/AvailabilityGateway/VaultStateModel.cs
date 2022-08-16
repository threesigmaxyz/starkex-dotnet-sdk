namespace StarkEx.Client.SDK.Models.Spot.AvailabilityGateway;

using System.Numerics;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.JSON.Converter;

/// <summary>
///     Vault state.
/// </summary>
public class VaultStateModel
{
    /// <summary>
    ///     Gets or sets public key of the party as registered on the StarkEx contract.
    /// </summary>
    [JsonPropertyName("stark_key")]
    public string StarkKey { get; set; }

    /// <summary>
    ///     Gets or sets unique token ID as registered on the StarkEx contract.
    /// </summary>
    [JsonPropertyName("token")]
    public string TokenId { get; set; }

    /// <summary>
    ///     Gets or sets vault balance.
    /// </summary>
    [JsonPropertyName("balance")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger Balance { get; set; }
}