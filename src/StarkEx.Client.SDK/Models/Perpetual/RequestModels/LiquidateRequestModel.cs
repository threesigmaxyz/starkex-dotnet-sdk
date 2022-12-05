namespace StarkEx.Client.SDK.Models.Perpetual.RequestModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

/// <summary>
/// Represents a request model for a liquidation transaction in the StarkEx Perpetual API.
/// </summary>
public class LiquidateRequestModel : BaseRequestModel
{
    /// <summary>
    /// Gets or sets the transaction model for the liquidation.
    /// </summary>
    /// <value>
    /// The transaction model for the liquidation.
    /// </value>
    /// <seealso cref="LiquidateModel"/>
    [JsonPropertyName("tx")]
    public LiquidateModel Transaction { get; set; }
}