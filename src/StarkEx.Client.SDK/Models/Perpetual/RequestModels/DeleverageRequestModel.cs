namespace StarkEx.Client.SDK.Models.Perpetual.RequestModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

/// <summary>
/// Represents a request model for a deleverage transaction in the StarkEx Perpetual API.
/// </summary>
public class DeleverageRequestModel : BaseRequestModel
{
    /// <summary>
    /// Gets or sets the transaction model for the deleverage.
    /// </summary>
    /// <value>
    /// The transaction model for the deleverage.
    /// </value>
    /// <seealso cref="DeleverageModel"/>
    [JsonPropertyName("tx")]
    public DeleverageModel Transaction { get; set; }
}