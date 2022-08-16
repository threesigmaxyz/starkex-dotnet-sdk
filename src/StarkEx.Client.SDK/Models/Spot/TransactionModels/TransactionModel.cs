namespace StarkEx.Client.SDK.Models.Spot.TransactionModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.JSON.Converter;

[JsonConverter(typeof(SpotTransactionModelConverter))]
public abstract class TransactionModel
{
    [JsonPropertyName("type")]
    public abstract string Type { get; }
}