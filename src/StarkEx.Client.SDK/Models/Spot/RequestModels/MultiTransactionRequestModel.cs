namespace StarkEx.Client.SDK.Models.Spot.RequestModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Models.Spot.TransactionModels;

/// <summary>
/// Represents a request model for a multi-transaction in the StarkEx Spot API.
/// </summary>
public class MultiTransactionRequestModel : BaseRequestModel
{
    /// <summary>
    /// Gets or sets the transaction model for the multi-transaction.
    /// </summary>
    /// <value>
    /// The transaction model for the multi-transaction.
    /// </value>
    /// <seealso cref="MultiTransactionModel"/>
    [JsonPropertyName("tx")]
    public MultiTransactionModel Transaction { get; set; }
}