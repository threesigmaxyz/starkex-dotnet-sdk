namespace StarkEx.Client.SDK.Models.Spot.RequestModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Models.Spot.TransactionModels;

/// <summary>
/// Represents a request model for a full withdrawal transaction in the StarkEx Spot API.
/// </summary>
public class FullWithdrawalRequestModel : BaseRequestModel
{
    /// <summary>
    /// Gets or sets the transaction model for the full withdrawal.
    /// </summary>
    /// <value>
    /// The transaction model for the full withdrawal.
    /// </value>
    /// <seealso cref="FullWithdrawalModel"/>
    [JsonPropertyName("tx")]
    public FullWithdrawalModel Transaction { get; set; }
}