namespace StarkEx.Client.SDK.Models.Perpetual.RequestModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

/// <summary>
/// Represents a request model for a forced trade transaction in the StarkEx Perpetual API.
/// </summary>
public class ForcedTradeRequestModel : BaseRequestModel
{
    /// <summary>
    /// Gets or sets the transaction model for the forced trade.
    /// </summary>
    /// <value>
    /// The transaction model for the forced trade.
    /// </value>
    /// <seealso cref="ForcedTradeModel"/>
    [JsonPropertyName("tx")]
    public ForcedTradeModel Transaction { get; set; }
}