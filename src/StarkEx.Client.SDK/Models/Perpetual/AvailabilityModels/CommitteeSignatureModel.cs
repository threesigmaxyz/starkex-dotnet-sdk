namespace StarkEx.Client.SDK.Models.Perpetual.AvailabilityModels;

using System.Text.Json.Serialization;

/// <summary>
///     The information describing a committee signature.
/// </summary>
public class CommitteeSignatureModel
{
    /// <summary>
    ///     Gets or sets iD of signed batch.
    /// </summary>
    [JsonPropertyName("batch_id")]
    public int BatchId { get; set; }

    /// <summary>
    ///     Gets or sets claim hash being signed used for validating the expected claim.
    /// </summary>
    [JsonPropertyName("claim_hash")]
    public string ClaimHash { get; set; }

    /// <summary>
    ///     Gets or sets committee member public key used for identification.
    /// </summary>
    [JsonPropertyName("member_key")]
    public string MemberKey { get; set; }

    /// <summary>
    ///     Gets or sets committee signature for batch.
    /// </summary>
    [JsonPropertyName("signature")]
    public string Signature { get; set; }
}