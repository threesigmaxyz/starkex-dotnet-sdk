namespace StarkEx.Commons.SDK.Models;

using System.Text.Json.Serialization;

public class SignatureModel
{
    [JsonPropertyName("r")]
    public string R { get; set; }

    [JsonPropertyName("s")]
    public string S { get; set; }
}