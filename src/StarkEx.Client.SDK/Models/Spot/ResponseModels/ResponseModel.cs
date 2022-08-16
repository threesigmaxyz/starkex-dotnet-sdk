namespace StarkEx.Client.SDK.Models.Spot.ResponseModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Enums.Spot;

/// <summary>
///     The Response Model for requests.
/// </summary>
public class ResponseModel
{
    /// <summary>
    ///     Gets or sets the API Code returned with the response.
    /// </summary>
    [JsonPropertyName("code")]
    public SpotApiCodes Code { get; set; }
}