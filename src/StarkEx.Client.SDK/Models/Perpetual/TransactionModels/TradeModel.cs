namespace StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

using System.Numerics;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.JSON.Converter;

/// <summary>
///     Information on a Trade Transaction.
/// </summary>
public class TradeModel : TransactionModel
{
    /// <summary>
    ///     Gets or sets the amount party a paid for fees out of the maximal amount they were willing to pay.
    /// </summary>
    [JsonPropertyName("actual_a_fee")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger ActualAFee { get; set; }

    /// <summary>
    ///     Gets or sets the amount party b paid for fees of the maximal amount they were willing to pay.
    /// </summary>
    [JsonPropertyName("actual_b_fee")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger ActualBFee { get; set; }

    /// <summary>
    ///     Gets or sets the collateral amount sold in the trade.
    /// </summary>
    [JsonPropertyName("actual_collateral")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger ActualCollateral { get; set; }

    /// <summary>
    ///     Gets or sets the synthetic amount sold in the trade.
    /// </summary>
    [JsonPropertyName("actual_synthetic")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger ActualSynthetic { get; set; }

    /// <summary>
    ///     Gets or sets represents party a’s order.
    /// </summary>
    [JsonPropertyName("party_a_order")]
    public OrderModel PartyAOrder { get; set; }

    /// <summary>
    ///     Gets or sets represents party b’s order.
    /// </summary>
    [JsonPropertyName("party_b_order")]
    public OrderModel PartyBOrder { get; set; }

    /// <summary>
    ///     Gets the Transaction Type.
    /// </summary>
    [JsonPropertyName("type")]
    public override string Type => "TRADE";
}
