#nullable enable
namespace StarkEx.Client.SDK.Models.Spot.TransactionModels;

using System.Numerics;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.JSON.Converter;

/// <summary>
///     Representation for Settlement Info.
/// </summary>
public class SettlementInfoModel
{
    /// <summary>
    ///     Gets or sets the amount sold by party a.
    /// </summary>
    [JsonPropertyName("party_a_sold")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger PartyASold { get; set; }

    /// <summary>
    ///     Gets or sets party b fee information.
    /// </summary>
    [JsonPropertyName("party_b_fee_info")]
    public FeeInfoExchangeModel? PartyBInfo { get; set; }

    /// <summary>
    ///     Gets or sets the amount sold by party b.
    /// </summary>
    [JsonPropertyName("party_b_sold")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger PartyBSold { get; set; }

    /// <summary>
    ///     Gets or sets party a fee information.
    /// </summary>
    [JsonPropertyName("party_a_fee_info")]
    public FeeInfoExchangeModel? PartyAInfo { get; set; }
}
