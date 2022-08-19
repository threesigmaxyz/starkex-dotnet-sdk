namespace StarkEx.Client.SDK.Models.Perpetual.ResponseModels;

using System.Numerics;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.JSON.Converter;
using StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

public class TransactionInfoModel
{
    [JsonPropertyName("alt_txs")]
    public IEnumerable<TransactionModel> AltTxs { get; set; }

    [JsonPropertyName("original_tx")]
    public TransactionModel OriginalTx { get; set; }

    [JsonPropertyName("original_tx_id")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger OriginalTxId { get; set; }

    [JsonPropertyName("was_replaced")]
    public bool WasReplaced { get; set; }
}