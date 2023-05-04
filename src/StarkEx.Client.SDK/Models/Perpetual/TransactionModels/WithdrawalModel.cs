namespace StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

using System.Numerics;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.JSON.Converter;
using StarkEx.Commons.SDK.Models;

/// <summary>
///     Information on a Withdrawal Transaction.
/// </summary>
public class WithdrawalModel : TransactionModel
{
    /// <summary>
    ///     Gets or sets the amount to withdraw.
    /// </summary>
    [JsonPropertyName("amount")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger Amount { get; set; }

    /// <summary>
    ///     Gets or sets the timestamp after which this request is no longer valid.
    /// </summary>
    [JsonPropertyName("expiration_timestamp")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger ExpirationTimestamp { get; set; }

    /// <summary>
    ///     Gets or sets unique nonce issued by the caller.
    /// </summary>
    [JsonPropertyName("nonce")]
    public uint Nonce { get; set; }

    /// <summary>
    ///     Gets or sets the position ID to withdraw from.
    /// </summary>
    [JsonPropertyName("position_id")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger PositionId { get; set; }

    /// <summary>
    ///     Gets or sets the position ID owner’s public key.
    /// </summary>
    [JsonPropertyName("public_key")]
    public string PublicKey { get; set; }

    /// <summary>
    ///     Gets or sets the position owner’s signature.
    /// </summary>
    [JsonPropertyName("signature")]
    public SignatureModel Signature { get; set; }

    /// <summary>
    ///     Gets the Transaction Type.
    /// </summary>
    [JsonPropertyName("type")]
    public override string Type => "WITHDRAWAL";
}
