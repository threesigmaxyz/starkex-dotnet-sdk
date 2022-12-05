namespace StarkEx.Client.SDK.Extensions;

using System.Text.Json;
using StarkEx.Client.SDK.Exceptions;

/// <summary>
/// Provides extension methods for validating HTTP request responses.
/// </summary>
public static class ValidateHttpRequestExtensions
{
    /// <summary>
    /// Validates the specified HTTP response to ensure that it has a successful status code.
    /// If the status code is not successful, an exception is thrown.
    /// </summary>
    /// <param name="response">The HTTP response to validate.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <exception cref="StarkExErrorException">
    /// Thrown if the HTTP response has a non-success status code and the response body
    /// cannot be deserialized as a <see cref="StarkExErrorException"/>.
    /// </exception>
    public static async Task ValidateSuccessStatusCode(
        this HttpResponseMessage response,
        CancellationToken cancellationToken)
    {
        if (response.IsSuccessStatusCode)
        {
            return;
        }

        var responseBody = await response.Content.ReadAsStringAsync(cancellationToken);
        try
        {
            throw JsonSerializer.Deserialize<StarkExErrorException>(responseBody)!;
        }
        catch (Exception ex) when (ex is JsonException or NotSupportedException or ArgumentNullException)
        {
            throw new StarkExErrorException(responseBody);
        }
    }
}