namespace StarkEx.Client.SDK.Models.Perpetual.RequestModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

/// <summary>
/// Represents a request model for a transfer transaction in the StarkEx Perpetual API.
/// </summary>
public class TransferRequestModel : BaseRequestModel
{
    /// <summary>
    /// Gets or sets the transaction model for the transfer.
    /// </summary>
    /// <value>
    /// The transaction model for the transfer.
    /// </value>
    /// <seealso cref="TransferModel"/>
    [JsonPropertyName("tx")]
    public TransferModel Transaction { get; set; }
}