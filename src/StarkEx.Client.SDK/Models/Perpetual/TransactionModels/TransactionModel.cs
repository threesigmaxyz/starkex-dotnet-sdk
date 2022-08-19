namespace StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.JSON.Converter;

[JsonConverter(typeof(PerpetualTransactionModelConverter))]
public abstract class TransactionModel
{
    [JsonPropertyName("type")]
    public abstract string Type { get; }
}