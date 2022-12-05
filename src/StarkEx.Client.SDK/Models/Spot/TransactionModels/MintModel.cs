namespace StarkEx.Client.SDK.Models.Spot.TransactionModels;

using System.Numerics;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.JSON.Converter;

/// <summary>
/// Represents a model for a mint transaction in the StarkEx Spot API.
/// </summary>
public class MintModel : TransactionModel
{
    /// <summary>
    /// Gets or sets the amount of the mint.
    /// </summary>
    /// <value>
    /// The amount of the mint.
    /// </value>
    [JsonPropertyName("amount")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger Amount { get; set; }

    /// <summary>
    /// Gets or sets the Stark key used for the mint.
    /// </summary>
    /// <value>
    /// The Stark key used for the mint.
    /// </value>
    [JsonPropertyName("stark_key")]
    public string StarkKey { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the token being minted.
    /// </summary>
    /// <value>
    /// The identifier of the token being minted.
    /// </value>
    [JsonPropertyName("token_id")]
    public string TokenId { get; set; }

    /// <summary>
    /// Gets the type of the transaction.
    /// </summary>
    /// <value>
    /// The type of the transaction.
    /// </value>
    [JsonPropertyName("type")]
    public override string Type => "MintRequest";

    /// <summary>
    /// Gets or sets the identifier of the vault associated with the mint.
    /// </summary>
    /// <value>
    /// The identifier of the vault associated with the mint.
    /// </value>
    [JsonPropertyName("vault_id")]
    [JsonConverter(typeof(BigIntegerConverter))]
    public BigInteger VaultId { get; set; }
}