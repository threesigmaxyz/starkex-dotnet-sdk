namespace StarkEx.Client.SDK.Models.Spot.RequestModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Models.Spot.TransactionModels;

/// <summary>
/// Represents a request model for a mint transaction in the StarkEx Spot API.
/// </summary>
public class MintRequestModel : BaseRequestModel
{
    /// <summary>
    /// Gets or sets the transaction model for the mint.
    /// </summary>
    /// <value>
    /// The transaction model for the mint.
    /// </value>
    /// <seealso cref="MintModel"/>
    [JsonPropertyName("tx")]
    public MintModel Transaction { get; set; }
}
