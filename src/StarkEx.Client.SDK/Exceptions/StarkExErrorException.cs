namespace StarkEx.Client.SDK.Exceptions;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Enums.Spot;

/// <summary>
/// Represents an error that occurred while calling the StarkEx API.
/// </summary>
[Serializable]
public class StarkExErrorException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="StarkExErrorException"/> class.
    /// </summary>
    public StarkExErrorException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="StarkExErrorException"/> class with the
    /// raw response body from the StarkEx API.
    /// </summary>
    /// <param name="body">The raw response body from the StarkEx API.</param>
    public StarkExErrorException(string body)
    {
        RawBody = body;
    }

    /// <summary>
    /// Gets or sets the error code returned by the StarkEx API.
    /// </summary>
    [JsonPropertyName("code")]
    public SpotApiCodes Code { get; set; }

    /// <summary>
    /// Gets or sets the error message returned by the StarkEx API.
    /// </summary>
    [JsonPropertyName("message")]
    public new string Message { get; set; }

    /// <summary>
    /// Gets or sets additional information about the error, if available.
    /// </summary>
    [JsonPropertyName("problems")]
    public object Problems { get; set; }

    /// <summary>
    /// Gets or sets the raw response body from the StarkEx API.
    /// </summary>
    public string RawBody { get; set; }
}