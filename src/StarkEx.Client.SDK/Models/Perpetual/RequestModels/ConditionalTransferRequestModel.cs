namespace StarkEx.Client.SDK.Models.Perpetual.RequestModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

/// <summary>
/// Represents a request model for a conditional transfer transaction in the StarkEx Perpetual API.
/// </summary>
public class ConditionalTransferRequestModel : BaseRequestModel
{
    /// <summary>
    /// Gets or sets the transaction model for the conditional transfer.
    /// </summary>
    /// <value>
    /// The transaction model for the conditional transfer.
    /// </value>
    /// <seealso cref="ConditionalTransferModel"/>
    [JsonPropertyName("tx")]
    public ConditionalTransferModel Transaction { get; set; }
}