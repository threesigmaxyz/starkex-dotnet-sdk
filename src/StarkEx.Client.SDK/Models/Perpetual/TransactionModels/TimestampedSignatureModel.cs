namespace StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

using System.Numerics;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.JSON.Converter;
using StarkEx.Commons.SDK.Models;

/// <summary>
/// Represents a signature with a timestamp in the StarkEx Perpetual API.
/// </summary>
public class TimestampedSignatureModel
{
    /// <summary>
    /// Gets or sets the signature.
    /// </summary>
    /// <value>
    /// The signature.
    /// </value>
    /// <seealso cref="SignatureModel"/>
    [JsonPropertyName("signature")]
    public SignatureModel Signature { get; set; }

    /// <summary>
    /// Gets or sets the timestamp of the signature.
    /// </summary>
    /// <value>
    /// The timestamp of the signature.
    /// </value>
    [JsonPropertyName("timestamp")]
    [JsonConverter(typeof(BigIntegerAsTextConverter))]
    public BigInteger Timestamp { get; set; }
}