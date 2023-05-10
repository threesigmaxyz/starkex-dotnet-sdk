namespace StarkEx.Client.SDK.Models.Spot.TransactionModels;

using System.Numerics;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.JSON.Converter;
using StarkEx.Commons.SDK.Models;

/// <summary>
///     Information on a Transfer Transaction.
/// </summary>
public class TransferModel : TransactionModel
{
    /// <summary>
    ///     Gets or sets the amount to transfer.
    /// </summary>
    [JsonPropertyName("amount")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger Amount { get; set; }

    /// <summary>
    ///     Gets or sets the expiration timestamp for the transfer, in hours since the Unix epoch (Unix timestamp / 3600).
    /// </summary>
    [JsonPropertyName("expiration_timestamp")]
    public long ExpirationTimestamp { get; set; }

    /// <summary>
    ///     Gets or sets the fee information given by the exchange.
    /// </summary>
    [JsonPropertyName("fee_info_exchange")]
    public FeeInfoExchangeModel FeeInfoExchange { get; set; }

    /// <summary>
    ///     Gets or sets the fee information given and signed by the user.
    /// </summary>
    [JsonPropertyName("fee_info_user")]
    public FeeInfoModel FeeInfo { get; set; }

    /// <summary>
    ///     Gets or sets the (single) nonce involved in the transfer.
    /// </summary>
    [JsonPropertyName("nonce")]
    public uint Nonce { get; set; }

    /// <summary>
    ///     Gets or sets the receiver’s public key.
    /// </summary>
    [JsonPropertyName("receiver_public_key")]
    public string ReceiverPublicKey { get; set; }

    /// <summary>
    ///     Gets or sets the receiver’s vault ID.
    /// </summary>
    [JsonPropertyName("receiver_vault_id")]
    [JsonConverter(typeof(BigIntegerConverter))]
    public BigInteger ReceiverVaultId { get; set; }

    /// <summary>
    ///     Gets or sets the sender’s public key.
    /// </summary>
    [JsonPropertyName("sender_public_key")]
    public string SenderPublicKey { get; set; }

    /// <summary>
    ///     Gets or sets the sender’s vault ID.
    /// </summary>
    [JsonPropertyName("sender_vault_id")]
    [JsonConverter(typeof(BigIntegerConverter))]
    public BigInteger SenderVaultId { get; set; }

    /// <summary>
    ///     Gets or sets the Signature of the party on the transfer.
    /// </summary>
    [JsonPropertyName("signature")]
    public SignatureModel Signature { get; set; }

    /// <summary>
    ///     Gets or sets the token to be transferred.
    /// </summary>
    [JsonPropertyName("token")]
    public string Token { get; set; }

    /// <summary>
    ///     Gets the Transaction Type.
    /// </summary>
    [JsonPropertyName("type")]
    public override string Type => "TransferRequest";
}
