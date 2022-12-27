namespace StarkEx.Client.SDK.Models.Perpetual.RequestModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

/// <summary>
/// Represents a request model for a funding tick transaction in the StarkEx Perpetual API.
/// </summary>
public class FundingTickRequestModel : BaseRequestModel
{
    /// <summary>
    /// Gets or sets the transaction model for the funding tick.
    /// </summary>
    /// <value>
    /// The transaction model for the funding tick.
    /// </value>
    /// <seealso cref="FundingTickModel"/>
    [JsonPropertyName("tx")]
    public FundingTickModel Transaction { get; set; }
}
