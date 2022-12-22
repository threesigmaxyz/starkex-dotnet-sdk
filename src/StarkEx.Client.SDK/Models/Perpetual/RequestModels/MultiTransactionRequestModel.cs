namespace StarkEx.Client.SDK.Models.Perpetual.RequestModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

/// <summary>
/// Represents a request model for a multi-transaction request in the StarkEx Perpetual API.
/// </summary>
public class MultiTransactionRequestModel : BaseRequestModel
{
    /// <summary>
    /// Gets or sets the transaction model for the multi-transaction request.
    /// </summary>
    /// <value>
    /// The transaction model for the multi-transaction request.
    /// </value>
    /// <seealso cref="MultiTransactionModel"/>
    [JsonPropertyName("tx")]
    public MultiTransactionModel Transaction { get; set; }
}
