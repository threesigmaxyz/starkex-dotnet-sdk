namespace StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

using System.Numerics;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.JSON.Converter;

/// <summary>
///     Information on a Liquidate Transaction.
/// </summary>
public class LiquidateModel : TransactionModel
{
    /// <summary>
    ///     Gets or sets the collateral amount sold in the liquidation.
    /// </summary>
    [JsonPropertyName("actual_collateral")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger ActualCollateral { get; set; }

    /// <summary>
    ///     Gets or sets the fee the liquidator paid out of the maximal amount they were willing to pay.
    /// </summary>
    [JsonPropertyName("actual_liquidator_fee")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger ActualLiquidatorFee { get; set; }

    /// <summary>
    ///     Gets or sets the synthetic amount sold in the liquidation.
    /// </summary>
    [JsonPropertyName("actual_synthetic")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger ActualSynthetic { get; set; }

    /// <summary>
    ///     Gets or sets the liquidated position ID.
    /// </summary>
    [JsonPropertyName("liquidated_position_id")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger LiquidatedPositionId { get; set; }

    /// <summary>
    ///     Gets or sets represents the liquidator order.
    /// </summary>
    [JsonPropertyName("liquidator_order")]
    public OrderModel LiquidatorOrder { get; set; }

    /// <summary>
    ///     Gets the Transaction Type.
    /// </summary>
    [JsonPropertyName("type")]
    public override string Type => "LIQUIDATE";
}