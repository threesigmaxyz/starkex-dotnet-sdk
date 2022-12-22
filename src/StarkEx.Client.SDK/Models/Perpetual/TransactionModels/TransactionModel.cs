namespace StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.JSON.Converter;

/// <summary>
/// Represents a transaction in the StarkEx Perpetual API.
/// </summary>
[JsonConverter(typeof(PerpetualTransactionModelConverter))]
public abstract class TransactionModel
{
    /// <summary>
    /// Gets the type of the transaction.
    /// </summary>
    /// <value>
    /// The type of the transaction.
    /// </value>
    [JsonPropertyName("type")]
    public abstract string Type { get; }
}
