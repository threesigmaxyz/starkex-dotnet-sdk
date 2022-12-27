namespace StarkEx.Client.SDK.Models.Spot.RequestModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Models.Spot.TransactionModels;

/// <summary>
/// Represents a request model for a false-full withdrawal transaction in the StarkEx Spot API.
/// </summary>
public class FalseFullWithdrawalRequestModel : BaseRequestModel
{
    /// <summary>
    /// Gets or sets the transaction model for the false-full withdrawal.
    /// </summary>
    /// <value>
    /// The transaction model for the false-full withdrawal.
    /// </value>
    /// <seealso cref="FalseFullWithdrawalModel"/>
    [JsonPropertyName("tx")]
    public FalseFullWithdrawalModel Transaction { get; set; }
}
