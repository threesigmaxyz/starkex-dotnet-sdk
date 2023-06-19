namespace StarkEx.Client.SDK.Models.Spot.TransactionModels;

#nullable enable
using System.Numerics;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Enums.Spot;
using StarkEx.Client.SDK.JSON.Converter;
using StarkEx.Commons.SDK.Models;

/// <summary>
///     Representation for the party model.
/// </summary>
public class OrderRequestModel
{
    /// <summary>
    ///     Gets or sets the amount to buy.
    /// </summary>
    [JsonPropertyName("amount_buy")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger BuyAmount { get; set; }

    /// <summary>
    ///     Gets or sets the amount to sell.
    /// </summary>
    [JsonPropertyName("amount_sell")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger SellAmount { get; set; }

    /// <summary>
    ///     Gets or sets the timestamp after which this request is no longer valid.
    /// </summary>
    [JsonPropertyName("expiration_timestamp")]
    public long ExpirationTimestamp { get; set; }

    /// <summary>
    ///     Gets or sets the information about the fee.
    /// </summary>
    [JsonPropertyName("fee_info")]
    public FeeInfoModel? FeeInfo { get; set; }

    /// <summary>
    ///     Gets or sets unique nonce issued by the caller.
    /// </summary>
    [JsonPropertyName("nonce")]
    public int Nonce { get; set; }

    /// <summary>
    ///     Gets or sets party's public key.
    /// </summary>
    [JsonPropertyName("public_key")]
    public string? PublicKey { get; set; }

    /// <summary>
    ///     Gets or sets party's signature.
    /// </summary>
    [JsonPropertyName("signature")]
    public SignatureModel? Signature { get; set; }

    /// <summary>
    ///     Gets or sets the token to buy.
    /// </summary>
    [JsonPropertyName("token_buy")]
    public string TokenBuy { get; set; } = null!;

    /// <summary>
    ///     Gets or sets the token to sell.
    /// </summary>
    [JsonPropertyName("token_sell")]
    public string TokenSell { get; set; } = null!;

    /// <summary>
    ///     Gets or sets the Transaction Type.
    /// </summary>
    [JsonPropertyName("type")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public SpotOrderRequestType Type { get; set; }

    /// <summary>
    ///     Gets or sets the Vault ID to buy.
    /// </summary>
    [JsonPropertyName("vault_id_buy")]
    [JsonConverter(typeof(BigIntegerConverter))]
    public BigInteger VaultIdBuy { get; set; }

    /// <summary>
    ///     Gets or sets the Vault ID to sell.
    /// </summary>
    [JsonPropertyName("vault_id_sell")]
    [JsonConverter(typeof(BigIntegerConverter))]
    public BigInteger VaultIdSell { get; set; }
}
