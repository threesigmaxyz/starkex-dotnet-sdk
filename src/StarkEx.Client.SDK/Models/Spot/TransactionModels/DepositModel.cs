namespace StarkEx.Client.SDK.Models.Spot.TransactionModels;

using System.Numerics;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.JSON.Converter;

/// <summary>
///     Information on a Deposit Transaction.
/// </summary>
public class DepositModel : TransactionModel
{
    /// <summary>
    ///     Gets or sets amount of token to be deposited; required to be >= 0.
    /// </summary>
    [JsonPropertyName("amount")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger Amount { get; set; }

    /// <summary>
    ///     Gets or sets public key of the party as registered on the StarkEx contract.
    /// </summary>
    [JsonPropertyName("stark_key")]
    public string StarkKey { get; set; }

    /// <summary>
    ///     Gets or sets unique token ID as registered on the StarkEx contract.
    /// </summary>
    [JsonPropertyName("token_id")]
    public string TokenId { get; set; }

    /// <summary>
    ///     Gets the Transaction Type.
    /// </summary>
    [JsonPropertyName("type")]
    public override string Type => "DepositRequest";

    /// <summary>
    ///     Gets or sets vault ID in the StarkEx system.
    /// </summary>
    [JsonPropertyName("vault_id")]
    [JsonConverter(typeof(BigIntegerConverter))]
    public BigInteger VaultId { get; set; }
}