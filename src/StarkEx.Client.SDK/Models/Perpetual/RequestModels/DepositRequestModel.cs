namespace StarkEx.Client.SDK.Models.Perpetual.RequestModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

/// <summary>
/// Represents a request model for a deposit transaction in the StarkEx Perpetual API.
/// </summary>
public class DepositRequestModel : BaseRequestModel
{
    /// <summary>
    /// Gets or sets the transaction model for the deposit.
    /// </summary>
    /// <value>
    /// The transaction model for the deposit.
    /// </value>
    /// <seealso cref="DepositModel"/>
    [JsonPropertyName("tx")]
    public DepositModel Transaction { get; set; }
}
