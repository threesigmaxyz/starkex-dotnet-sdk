namespace StarkEx.Client.SDK.Models.Spot.TransactionModels;

using System.Numerics;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.JSON.Converter;

/// <summary>
///     Representation for the Fee Info.
/// </summary>
public class FeeInfoModel
{
    /// <summary>
    ///     Gets or sets the fee limit.
    /// </summary>
    [JsonPropertyName("fee_limit")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger FeeLimit { get; set; }

    /// <summary>
    ///     Gets or sets the source Vault ID.
    /// </summary>
    [JsonPropertyName("source_vault_id")]
    [JsonConverter(typeof(BigIntegerConverter))]
    public BigInteger SourceVaultId { get; set; }

    /// <summary>
    ///     Gets or sets the token ID.
    /// </summary>
    [JsonPropertyName("token_id")]
    public string TokenId { get; set; }
}