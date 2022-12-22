namespace StarkEx.Client.SDK.Models.Perpetual.RequestModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

/// <summary>
/// Represents a request model for a trade transaction in the StarkEx Perpetual API.
/// </summary>
public class TradeRequestModel : BaseRequestModel
{
    /// <summary>
    /// Gets or sets the transaction model for the trade.
    /// </summary>
    /// <value>
    /// The transaction model for the trade.
    /// </value>
    /// <seealso cref="TradeModel"/>
    [JsonPropertyName("tx")]
    public TradeModel Transaction { get; set; }
}
