namespace StarkEx.Client.SDK.Models.Perpetual.RequestModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

/// <summary>
/// Represents a request model for a withdrawal to address transaction in the StarkEx Perpetual API.
/// </summary>
public class WithdrawalToAddressRequestModel : BaseRequestModel
{
    /// <summary>
    /// Gets or sets the transaction model for the withdrawal to address.
    /// </summary>
    /// <value>
    /// The transaction model for the withdrawal to address.
    /// </value>
    /// <seealso cref="WithdrawalToAddressModel"/>
    [JsonPropertyName("tx")]
    public WithdrawalToAddressModel Transaction { get; set; }
}