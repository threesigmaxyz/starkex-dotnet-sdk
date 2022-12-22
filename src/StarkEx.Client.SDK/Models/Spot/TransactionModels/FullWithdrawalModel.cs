namespace StarkEx.Client.SDK.Models.Spot.TransactionModels;

using System.Numerics;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.JSON.Converter;

/// <summary>
///     Information on a FullWithdrawal Transaction.
/// </summary>
public class FullWithdrawalModel : TransactionModel
{
    /// <summary>
    ///     Gets or sets public key of the party as registered on the StarkEx contract.
    /// </summary>
    [JsonPropertyName("stark_key")]
    public string StarkKey { get; set; }

    /// <summary>
    ///     Gets the Transaction Type.
    /// </summary>
    [JsonPropertyName("type")]
    public override string Type => "FullWithdrawalRequest";

    /// <summary>
    ///     Gets or sets the Vault ID in the StarkEx system.
    /// </summary>
    [JsonPropertyName("vault_id")]
    [JsonConverter(typeof(BigIntegerConverter))]
    public BigInteger VaultId { get; set; }
}
