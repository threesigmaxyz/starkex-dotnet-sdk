namespace StarkEx.Client.SDK.Commons;

using System.Text.Json;
using StarkEx.Client.SDK.Exceptions;

public static class ClientResponseValidation
{
    public static async Task ValidateSuccessStatusCode(
        HttpResponseMessage response,
        CancellationToken cancellationToken)
    {
        if (!response.IsSuccessStatusCode)
        {
            throw await JsonSerializer.DeserializeAsync<InternalServerErrorException>(
                await response.Content.ReadAsStreamAsync(cancellationToken), cancellationToken: cancellationToken);
        }

        await Task.CompletedTask;
    }
}