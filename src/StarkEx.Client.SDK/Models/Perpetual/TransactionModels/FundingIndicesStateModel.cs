namespace StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

using System.Numerics;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.JSON.Converter;

/// <summary>
///     Represents a collection of timestamped global funding indices for all assets.
/// </summary>
public class FundingIndicesStateModel
{
    /// <summary>
    ///     Gets or sets map of synthetic asset to its global funding index.
    /// </summary>
    [JsonPropertyName("indices")]
    [JsonConverter(typeof(DictionaryStringBigIntegerAsTextConverter))]
    public IDictionary<string, BigInteger> Indices { get; set; }

    /// <summary>
    ///     Gets or sets the timestamp for which the funding indices are valid for.
    /// </summary>
    [JsonPropertyName("timestamp")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger Timestamp { get; set; }
}