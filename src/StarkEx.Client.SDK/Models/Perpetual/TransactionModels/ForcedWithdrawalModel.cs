namespace StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

using System.Numerics;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.JSON.Converter;

/// <summary>
/// Represents a model for a forced withdrawal transaction in the StarkEx Perpetual API.
/// </summary>
public class ForcedWithdrawalModel : TransactionModel
{
    /// <summary>
    /// Gets or sets the amount of the forced withdrawal.
    /// </summary>
    /// <value>
    /// The amount of the forced withdrawal.
    /// </value>
    [JsonPropertyName("amount")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger Amount { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the forced withdrawal is valid.
    /// </summary>
    /// <value>
    /// <c>true</c> if the forced withdrawal is valid; otherwise, <c>false</c>.
    /// </value>
    [JsonPropertyName("is_valid")]
    public bool IsValid { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the position associated with the forced withdrawal.
    /// </summary>
    /// <value>
    /// The identifier of the position associated with the forced withdrawal.
    /// </value>
    [JsonPropertyName("position_id")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger PositionId { get; set; }

    /// <summary>
    /// Gets or sets the public key of the user who made the forced withdrawal.
    /// </summary>
    /// <value>
    /// The public key of the user who made the forced withdrawal.
    /// </value>
    [JsonPropertyName("public_key")]
    public string PublicKey { get; set; }

    /// <summary>
    /// Gets the type of the transaction.
    /// </summary>
    /// <value>
    /// The type of the transaction.
    /// </value>
    [JsonPropertyName("type")]
    public override string Type => "FORCED_WITHDRAWAL";
}