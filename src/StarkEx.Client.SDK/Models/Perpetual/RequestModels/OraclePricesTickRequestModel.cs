namespace StarkEx.Client.SDK.Models.Perpetual.RequestModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

/// <summary>
/// Represents a request model for an oracle prices tick transaction in the StarkEx Perpetual API.
/// </summary>
public class OraclePricesTickRequestModel : BaseRequestModel
{
    /// <summary>
    /// Gets or sets the transaction model for the oracle prices tick.
    /// </summary>
    /// <value>
    /// The transaction model for the oracle prices tick.
    /// </value>
    /// <seealso cref="OraclePricesTickModel"/>
    [JsonPropertyName("tx")]
    public OraclePricesTickModel Transaction { get; set; }
}
