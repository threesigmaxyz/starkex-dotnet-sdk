namespace StarkEx.Client.SDK.Models.Spot.TransactionModels;

using System.Text.Json.Serialization;

/// <summary>
/// Represents a model for a settlement transaction in the StarkEx Spot API.
/// </summary>
public class SettlementModel : TransactionModel
{
    /// <summary>
    /// Gets or sets the order request information for Party A.
    /// </summary>
    /// <value>
    /// The order request information for Party A.
    /// </value>
    /// <seealso cref="OrderRequestModel"/>
    [JsonPropertyName("party_a_order")]
    public OrderRequestModel PartyA { get; set; }

    /// <summary>
    /// Gets or sets the order request information for Party B.
    /// </summary>
    /// <value>
    /// The order request information for Party B.
    /// </value>
    /// <seealso cref="OrderRequestModel"/>
    [JsonPropertyName("party_b_order")]
    public OrderRequestModel PartyB { get; set; }

    /// <summary>
    /// Gets or sets the settlement information for the transaction.
    /// </summary>
    /// <value>
    /// The settlement information for the transaction.
    /// </value>
    /// <seealso cref="SettlementInfoModel"/>
    [JsonPropertyName("settlement_info")]
    public SettlementInfoModel SettlementInfo { get; set; }

    /// <summary>
    /// Gets the type of the transaction.
    /// </summary>
    /// <value>
    /// The type of the transaction.
    /// </value>
    [JsonPropertyName("type")]
    public override string Type => "SettlementRequest";
}