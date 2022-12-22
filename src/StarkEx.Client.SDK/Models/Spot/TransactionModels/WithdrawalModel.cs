namespace StarkEx.Client.SDK.Models.Spot.TransactionModels;

using System.Numerics;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.JSON.Converter;

/// <summary>
///     Information on a Withdrawal Transaction.
/// </summary>
public class WithdrawalModel : TransactionModel
{
    /// <summary>
    ///     Gets or sets the amount of token to be withdrawn; required to be >= 0.
    /// </summary>
    [JsonPropertyName("amount")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger Amount { get; set; }

    /// <summary>
    ///     Gets or sets the public key of the party as registered on the StarkEx contract.
    /// </summary>
    [JsonPropertyName("stark_key")]
    public string StarkKey { get; set; }

    /// <summary>
    ///     Gets or sets the unique token ID as registered on the StarkEx contract.
    /// </summary>
    [JsonPropertyName("token_id")]
    public string TokenId { get; set; }

    /// <summary>
    ///     Gets the Transaction Type.
    /// </summary>
    [JsonPropertyName("type")]
    public override string Type => "WithdrawalRequest";

    /// <summary>
    ///     Gets or sets the Vault ID in the StarkEx system.
    /// </summary>
    [JsonPropertyName("vault_id")]
    [JsonConverter(typeof(BigIntegerConverter))]
    public BigInteger VaultId { get; set; }
}
