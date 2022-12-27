namespace StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

using System.Text.Json.Serialization;

/// <summary>
/// Represents a transaction that updates the global funding indices state in the StarkEx Perpetual API.
/// </summary>
public class FundingTickModel : TransactionModel
{
    /// <summary>
    /// Gets or sets the updated state of the global funding indices.
    /// </summary>
    /// <value>
    /// The updated state of the global funding indices.
    /// </value>
    /// <seealso cref="FundingIndicesStateModel"/>
    [JsonPropertyName("global_funding_indices")]
    public FundingIndicesStateModel GlobalFundingIndices { get; set; }

    /// <summary>
    /// Gets the type of the transaction.
    /// </summary>
    /// <value>
    /// The type of the transaction.
    /// </value>
    [JsonPropertyName("type")]
    public override string Type => "FUNDING_TICK";
}
