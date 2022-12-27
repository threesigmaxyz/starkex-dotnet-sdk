namespace StarkEx.Client.SDK.Models.Spot.RequestModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Models.Spot.TransactionModels;

/// <summary>
/// Represents a request model for a settlement transaction in the StarkEx Spot API.
/// </summary>
public class SettlementRequestModel : BaseRequestModel
{
    /// <summary>
    /// Gets or sets the transaction model for the settlement.
    /// </summary>
    /// <value>
    /// The transaction model for the settlement.
    /// </value>
    /// <seealso cref="SettlementModel"/>
    [JsonPropertyName("tx")]
    public SettlementModel Transaction { get; set; }
}
