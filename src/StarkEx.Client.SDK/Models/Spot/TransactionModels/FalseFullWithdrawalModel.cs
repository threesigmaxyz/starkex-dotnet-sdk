namespace StarkEx.Client.SDK.Models.Spot.TransactionModels;

using System.Numerics;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.JSON.Converter;

/// <summary>
///     Information on a FalseFullWithdrawal Transaction.
/// </summary>
public class FalseFullWithdrawalModel : TransactionModel
{
    /// <summary>
    ///     Gets or sets the stark_key of the (malicious) user that requested the withdrawal.
    /// </summary>
    [JsonPropertyName("requester_stark_key")]
    public string RequesterStarkKey { get; set; }

    /// <summary>
    ///     Gets the Transaction Type.
    /// </summary>
    [JsonPropertyName("type")]
    public override string Type => "FalseFullWithdrawalRequest";

    /// <summary>
    ///     Gets or sets the Vault ID in the StarkEx system.
    /// </summary>
    [JsonPropertyName("vault_id")]
    [JsonConverter(typeof(BigIntegerConverter))]
    public BigInteger VaultId { get; set; }
}
