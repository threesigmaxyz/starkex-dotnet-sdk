namespace StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

using System.Numerics;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Enums.Perpetual;
using StarkEx.Client.SDK.JSON.Converter;
using StarkEx.Commons.SDK.Models;

/// <summary>
///     Representation of an Order.
/// </summary>
public class OrderModel
{
    /// <summary>
    ///     Gets or sets amount of collateral asset in the order.
    /// </summary>
    [JsonPropertyName("amount_collateral")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger AmountCollateral { get; set; }

    /// <summary>
    ///     Gets or sets the fee limit for this order.
    /// </summary>
    [JsonPropertyName("amount_fee")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger AmountFee { get; set; }

    /// <summary>
    ///     Gets or sets amount of synthetic asset in the order.
    /// </summary>
    [JsonPropertyName("amount_synthetic")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger AmountSynthetic { get; set; }

    /// <summary>
    ///     Gets or sets the collateral asset ID (as registered on the contract) participating in this order.
    /// </summary>
    [JsonPropertyName("asset_id_collateral")]
    public string AssetIdCollateral { get; set; }

    /// <summary>
    ///     Gets or sets the synthetic asset ID (as registered on the contract) participating in this order.
    /// </summary>
    [JsonPropertyName("asset_id_synthetic")]
    public string AssetIdSynthetic { get; set; }

    /// <summary>
    ///     Gets or sets the timestamp after which this request is no longer valid.
    /// </summary>
    [JsonPropertyName("expiration_timestamp")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger ExpirationTimestamp { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether a flag to indicate whether the order is for buying the synthetic amount or
    ///     selling the synthetic amount.
    /// </summary>
    [JsonPropertyName("is_buying_synthetic")]
    public bool IsBuyingSynthetic { get; set; }

    /// <summary>
    ///     Gets or sets unique nonce issued by the caller.
    /// </summary>
    [JsonPropertyName("nonce")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger Nonce { get; set; }

    /// <summary>
    ///     Gets or sets order Type.
    /// </summary>
    [JsonPropertyName("order_type")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public PerpetualOrderRequestType OrderType { get; set; }

    /// <summary>
    ///     Gets or sets position ID used for the trade.
    /// </summary>
    [JsonPropertyName("position_id")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger PositionId { get; set; }

    /// <summary>
    ///     Gets or sets public key of the party as registered on the StarkEx contract.
    /// </summary>
    [JsonPropertyName("public_key")]
    public string PublicKey { get; set; }

    /// <summary>
    ///     Gets or sets signature of the party which issued this order.
    /// </summary>
    [JsonPropertyName("signature")]
    public SignatureModel Signature { get; set; }
}