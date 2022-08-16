namespace StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

using System.Numerics;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.JSON.Converter;

/// <summary>
///     Information on a Deleverage Transaction.
/// </summary>
public class DeleverageModel : TransactionModel
{
    /// <summary>
    ///     Gets or sets the deleveraged’s collateral amount.
    /// </summary>
    [JsonPropertyName("amount_collateral")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger AmountCollateral { get; set; }

    /// <summary>
    ///     Gets or sets the deleveraged’s synthetic amount.
    /// </summary>
    [JsonPropertyName("amount_synthetic")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger AmountSynthetic { get; set; }

    /// <summary>
    ///     Gets or sets the deleveraged position ID.
    /// </summary>
    [JsonPropertyName("deleveraged_position_id")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger DeleveragedPositionId { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether a flag which indicates if the deleverager is buying synthetic.
    /// </summary>
    [JsonPropertyName("deleverager_is_buying_synthetic")]
    public bool DeleveragerIsBuyingSynthetic { get; set; }

    /// <summary>
    ///     Gets or sets the position ID to which the deleveraged position is attached.
    /// </summary>
    [JsonPropertyName("deleverager_position_id")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger DeleveragerPositionId { get; set; }

    /// <summary>
    ///     Gets or sets the unique asset ID (as registered on the contract) being deleveraged.
    /// </summary>
    [JsonPropertyName("synthetic_asset_id")]
    public string SyntheticAssetId { get; set; }

    /// <summary>
    ///     Gets the Transaction Type.
    /// </summary>
    [JsonPropertyName("type")]
    public override string Type => "DELEVERAGE";
}