namespace StarkEx.Client.SDK.Clients.Spot;

using System.Net.Mime;
using System.Text;
using System.Text.Json;
using StarkEx.Client.SDK.Interfaces.Spot;
using StarkEx.Client.SDK.Models.Spot.AvailabilityGateway;
using StarkEx.Client.SDK.Settings;

/// <inheritdoc cref="StarkEx.Client.SDK.Interfaces.Spot.ISpotAvailabilityGatewayClient" />
public class SpotAvailabilityGatewayClient : BaseClient, ISpotAvailabilityGatewayClient
{
    public SpotAvailabilityGatewayClient(
        IHttpClientFactory httpClientFactory,
        StarkExApiSettings settings)
    {
        this.httpClientFactory = httpClientFactory;
        this.settings = settings;
    }

    /// <inheritdoc />
    public async Task<bool> ApproveNewRootsAsync(
        CommitteeSignatureModel committeeSignatureModel,
        CancellationToken cancellationToken)
    {
        var client = CreateClient();

        var jsonBody = new StringContent(
            JsonSerializer.Serialize(committeeSignatureModel, requestSerializerOptions),
            Encoding.UTF8,
            MediaTypeNames.Application.Json);
        var response = await client.PostAsync("/availability_gateway/approve_new_roots", jsonBody, cancellationToken);
        response.EnsureSuccessStatusCode();

        return (await response.Content.ReadAsStringAsync(cancellationToken)).Equals("signature accepted");
    }

    /// <inheritdoc />
    public async Task<BatchModel> GetBatchDataAsync(
        int batchId,
        bool validateRollup,
        CancellationToken cancellationToken)
    {
        var client = CreateClient();

        var endpoint = $"/availability_gateway/get_batch_data?batch_id={batchId}&validate_rollup={validateRollup}";
        var response = await client.GetAsync(endpoint, cancellationToken);
        response.EnsureSuccessStatusCode();

        return await JsonSerializer.DeserializeAsync<BatchModel>(
            await response.Content.ReadAsStreamAsync(cancellationToken), cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public Task<int> GetOrderTreeHeightAsync(CancellationToken cancellationToken)
    {
        // TODO reference to this endpoint is incomplete in the docs.
        throw new NotImplementedException();
    }

    private HttpClient CreateClient()
    {
        var client = httpClientFactory.CreateClient();

        client.BaseAddress = settings.BaseAddress;

        return client;
    }
}
