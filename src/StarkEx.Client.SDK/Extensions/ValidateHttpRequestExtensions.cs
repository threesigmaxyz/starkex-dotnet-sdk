namespace StarkEx.Client.SDK.Extensions;

using System.Text.Json;
using StarkEx.Client.SDK.Exceptions;

public static class ValidateHttpRequestExtensions
{
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