namespace StarkEx.Client.SDK.Exceptions;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Enums.Spot;

[Serializable]
public class InternalServerErrorException : Exception
{
    [JsonPropertyName("code")]
    public SpotApiCodes Code { get; set; }

    [JsonPropertyName("message")]
    public new string Message { get; set; }

    [JsonPropertyName("problems")]
    public object Problems { get; set; }
}