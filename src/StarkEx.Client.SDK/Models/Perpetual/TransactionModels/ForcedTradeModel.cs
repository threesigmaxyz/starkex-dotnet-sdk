namespace StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

using System.Numerics;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.JSON.Converter;

/// <summary>
///     Information on a Forced Trade Transaction.
/// </summary>
public class ForcedTradeModel : TransactionModel
{
    /// <summary>
    ///     Gets or sets the amount of collateral asset traded.
    /// </summary>
    [JsonPropertyName("amount_collateral")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger AmountCollateral { get; set; }

    /// <summary>
    ///     Gets or sets the amount of synthetic asset traded.
    /// </summary>
    [JsonPropertyName("amount_synthetic")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger AmountSynthetic { get; set; }

    /// <summary>
    ///     Gets or sets the collateral unique asset ID (as registered on the contract).
    /// </summary>
    [JsonPropertyName("collateral_asset_id")]
    public string CollateralAssetId { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether specifies if party A is buying the synthetic asset.
    /// </summary>
    [JsonPropertyName("is_party_a_buying_synthetic")]
    public bool IsPartyABuyingSynthetic { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether a flag that specifies the validity of the forced action.
    /// </summary>
    [JsonPropertyName("is_valid")]
    public bool IsValid { get; set; }

    /// <summary>
    ///     Gets or sets unique nonce issued by the caller.
    /// </summary>
    [JsonPropertyName("nonce")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger Nonce { get; set; }

    /// <summary>
    ///     Gets or sets the position ID of party a.
    /// </summary>
    [JsonPropertyName("position_id_party_a")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger PositionIdPartyA { get; set; }

    /// <summary>
    ///     Gets or sets the position ID of party b.
    /// </summary>
    [JsonPropertyName("position_id_party_b")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger PositionIdPartyB { get; set; }

    /// <summary>
    ///     Gets or sets party a’s public key.
    /// </summary>
    [JsonPropertyName("public_key_party_a")]
    public string PublicKeyPartyA { get; set; }

    /// <summary>
    ///     Gets or sets party b’s public key.
    /// </summary>
    [JsonPropertyName("public_key_party_b")]
    public string PublicKeyPartyB { get; set; }

    /// <summary>
    ///     Gets or sets the unique asset ID of the synthetic asset that is traded.
    /// </summary>
    [JsonPropertyName("synthetic_asset_id")]
    public string SyntheticAssetId { get; set; }

    /// <summary>
    ///     Gets the Transaction Type.
    /// </summary>
    [JsonPropertyName("type")]
    public override string Type => "FORCED_TRADE";
}