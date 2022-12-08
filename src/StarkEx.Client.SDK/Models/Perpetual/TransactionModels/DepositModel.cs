namespace StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

using System.Numerics;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.JSON.Converter;

/// <summary>
/// Represents a model for a deposit transaction in the StarkEx Perpetual API.
/// </summary>
public class DepositModel : TransactionModel
{
    /// <summary>
    /// Gets or sets the amount of the deposit.
    /// </summary>
    /// <value>
    /// The amount of the deposit.
    /// </value>
    [JsonPropertyName("amount")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger Amount { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the position associated with the deposit.
    /// </summary>
    /// <value>
    /// The identifier of the position associated with the deposit.
    /// </value>
    [JsonPropertyName("position_id")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger PositionId { get; set; }

    /// <summary>
    /// Gets or sets the public key of the user who made the deposit.
    /// </summary>
    /// <value>
    /// The public key of the user who made the deposit.
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
    public override string Type => "DEPOSIT";
}