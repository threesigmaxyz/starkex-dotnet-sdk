namespace StarkEx.Client.SDK.Models.Spot.TransactionModels;

using System.Numerics;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.JSON.Converter;

/// <summary>
///     Representation for a Fee Info Exchange.
/// </summary>
public class FeeInfoExchangeModel
{
    /// <summary>
    ///     Gets or sets the Stark Key for the destination.
    /// </summary>
    [JsonPropertyName("destination_stark_key")]
    public string DestinationStarkKey { get; set; }

    /// <summary>
    ///     Gets or sets the Vault ID for the destination.
    /// </summary>
    [JsonPropertyName("destination_vault_id")]
    [JsonConverter(typeof(BigIntegerConverter))]
    public BigInteger DestinationVaultId { get; set; }

    /// <summary>
    ///     Gets or sets the fee taken.
    /// </summary>
    [JsonPropertyName("fee_taken")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger FeeTaken { get; set; }
}