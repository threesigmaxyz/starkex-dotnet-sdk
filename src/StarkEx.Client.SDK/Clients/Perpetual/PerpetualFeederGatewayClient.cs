namespace StarkEx.Client.SDK.Clients.Perpetual;

using System.Text.Json;
using StarkEx.Client.SDK.Interfaces.Perpetual;
using StarkEx.Client.SDK.Models.Perpetual.ResponseModels;
using StarkEx.Client.SDK.Settings;

/// <inheritdoc cref="StarkEx.Client.SDK.Interfaces.Perpetual.IPerpetualFeederGatewayClient" />
public class PerpetualFeederGatewayClient : BaseClient, IPerpetualFeederGatewayClient
{
    public PerpetualFeederGatewayClient(
        IHttpClientFactory httpClientFactory,
        StarkExApiSettings settings)
    {
        this.httpClientFactory = httpClientFactory;
        this.settings = settings;
    }

    /// <inheritdoc />
    public async Task<BatchInfoResponseModel> GetBatchInfoAsync(
        int batchId,
        CancellationToken cancellationToken)
    {
        const string path = "/feeder_gateway/get_batch_info";
        var query = $"?batch_id={batchId}";

        var client = CreateClient();
        var response = await client.GetAsync(path + query, cancellationToken);
        response.EnsureSuccessStatusCode();

        return await JsonSerializer.DeserializeAsync<BatchInfoResponseModel>(
            await response.Content.ReadAsStreamAsync(cancellationToken), cancellationToken: cancellationToken);
    }

    private HttpClient CreateClient()
    {
        var client = httpClientFactory.CreateClient();

        client.BaseAddress = settings.BaseAddress;

        return client;
    }
}