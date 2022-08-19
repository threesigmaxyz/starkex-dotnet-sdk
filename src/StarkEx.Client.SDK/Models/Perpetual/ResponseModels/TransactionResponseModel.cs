namespace StarkEx.Client.SDK.Models.Perpetual.ResponseModels;

using System.Numerics;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Enums.Perpetual;
using StarkEx.Client.SDK.JSON.Converter;

/// <summary>
///     Response Model for a Transaction.
/// </summary>
public class TransactionResponseModel
{
    /// <summary>
    ///     Gets or sets the code for a transaction response.
    /// </summary>
    [JsonPropertyName("code")]
    public PerpetualApiCodes Code { get; set; }

    /// <summary>
    ///     Gets or sets the Transaction ID.
    /// </summary>
    [JsonPropertyName("tx_id")]
    [JsonConverter(typeof(BigIntegerConverter))]
    public BigInteger TxId { get; set; }
}