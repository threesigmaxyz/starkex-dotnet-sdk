namespace StarkEx.Client.SDK.Models.Perpetual.RequestModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

/// <summary>
/// Represents a request model for a forced withdrawal transaction in the StarkEx Perpetual API.
/// </summary>
public class ForcedWithdrawalRequestModel : BaseRequestModel
{
    /// <summary>
    /// Gets or sets the transaction model for the forced withdrawal.
    /// </summary>
    /// <value>
    /// The transaction model for the forced withdrawal.
    /// </value>
    /// <seealso cref="ForcedWithdrawalModel"/>
    [JsonPropertyName("tx")]
    public ForcedWithdrawalModel Transaction { get; set; }
}
