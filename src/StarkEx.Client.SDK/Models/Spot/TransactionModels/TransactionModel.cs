namespace StarkEx.Client.SDK.Models.Spot.TransactionModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.JSON.Converter;

/// <summary>
/// Represents a model for a transaction in the StarkEx Spot API.
/// </summary>
[JsonConverter(typeof(SpotTransactionModelConverter))]
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
