namespace StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

using System.Numerics;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.JSON.Converter;
using StarkEx.Commons.SDK.Models;

/// <summary>
///     Information on a Conditional Transfer Transaction.
/// </summary>
public class ConditionalTransferModel : TransactionModel
{
    /// <summary>
    ///     Gets or sets the amount to transfer.
    /// </summary>
    [JsonPropertyName("amount")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger Amount { get; set; }

    /// <summary>
    ///     Gets or sets the unique asset ID (as registered on the contract) to transfer. Currently only the collateral asset
    ///     is supported.
    /// </summary>
    [JsonPropertyName("asset_id")]
    public string AssetId { get; set; }

    /// <summary>
    ///     Gets or sets the timestamp after which this request is no longer valid.
    /// </summary>
    [JsonPropertyName("expiration_timestamp")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger ExpirationTimestamp { get; set; }

    /// <summary>
    ///     Gets or sets the fact that should appear in the fact registry as a condition to the transfer. A 32 bytes blob.
    /// </summary>
    [JsonPropertyName("fact")]
    public string Fact { get; set; }

    /// <summary>
    ///     Gets or sets the address of the fact registry smart contract. Should be checksum according to
    ///     Web3.isChecksumAddress.
    /// </summary>
    [JsonPropertyName("fact_registry_address")]
    public string FactRegistryAddress { get; set; }

    /// <summary>
    ///     Gets or sets unique nonce issued by the caller.
    /// </summary>
    [JsonPropertyName("nonce")]
    public uint Nonce { get; set; }

    /// <summary>
    ///     Gets or sets the position ID to transfer to.
    /// </summary>
    [JsonPropertyName("receiver_position_id")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger ReceiverPositionId { get; set; }

    /// <summary>
    ///     Gets or sets the receiver’s public key.
    /// </summary>
    [JsonPropertyName("receiver_public_key")]
    public string ReceiverPublicKey { get; set; }

    /// <summary>
    ///     Gets or sets the position ID to transfer from.
    /// </summary>
    [JsonPropertyName("sender_position_id")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger SenderPositionId { get; set; }

    /// <summary>
    ///     Gets or sets the sender’s public key.
    /// </summary>
    [JsonPropertyName("sender_public_key")]
    public string SenderPublicKey { get; set; }

    /// <summary>
    ///     Gets or sets the sender’s signature.
    /// </summary>
    [JsonPropertyName("signature")]
    public SignatureModel Signature { get; set; }

    /// <summary>
    ///     Gets the Transaction Type.
    /// </summary>
    [JsonPropertyName("type")]
    public override string Type => "CONDITIONAL_TRANSFER";
}
