namespace StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

using System.Text.Json.Serialization;

public class FundingTickModel : TransactionModel
{
    [JsonPropertyName("global_funding_indices")]
    public FundingIndicesStateModel GlobalFundingIndices { get; set; }

    [JsonPropertyName("type")]
    public override string Type => "FUNDING_TICK";
}