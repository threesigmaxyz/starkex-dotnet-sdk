namespace StarkEx.Client.SDK.Models.Spot.RequestModels;

using System.Text.Json.Serialization;

/// <summary>
/// Represents a base class for request models used in the StarkEx Spot API.
/// </summary>
public abstract class BaseRequestModel
{
    /// <summary>
    /// Gets or sets the transaction ID for the request.
    /// </summary>
    /// <value>The transaction ID for the request.</value>
    [JsonPropertyName("tx_id")]
    public long TransactionId { get; set; }
}