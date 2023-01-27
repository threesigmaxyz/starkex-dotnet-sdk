namespace StarkEx.Client.SDK.Models.Spot.RequestModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Models.Spot.TransactionModels;

/// <summary>
/// Represents a base class for request models used in the StarkEx Spot API.
/// </summary>
public class RequestModel
{
    /// <summary>
    /// Gets or sets the transaction model for the request.
    /// </summary>
    [JsonPropertyName("tx")]
    public TransactionModel Transaction { get; set; }

    /// <summary>
    /// Gets or sets the transaction ID for the request.
    /// </summary>
    [JsonPropertyName("tx_id")]
    public long TransactionId { get; set; }
}
