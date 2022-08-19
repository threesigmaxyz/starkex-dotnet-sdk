﻿namespace StarkEx.Client.SDK.Clients.Spot;

using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Interfaces.Spot;
using StarkEx.Client.SDK.Models.Spot.AvailabilityGateway;
using StarkEx.Client.SDK.Settings;

/// <inheritdoc />
public class SpotAvailabilityGatewayClient : ISpotAvailabilityGatewayClient
{
    private readonly IHttpClientFactory httpClientFactory;

    private readonly JsonSerializerOptions requestSerializerOptions = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    };

    private readonly StarkExApiSettings settings;

    public SpotAvailabilityGatewayClient(
        IHttpClientFactory httpClientFactory,
        StarkExApiSettings settings)
    {
        this.httpClientFactory = httpClientFactory;
        this.settings = settings;
    }

    /// <inheritdoc />
    public async Task<bool> ApproveNewRootsAsync(CommitteeSignatureModel committeeSignature)
    {
        var client = CreateClient();

        var jsonBody = new StringContent(
            JsonSerializer.Serialize(committeeSignature, requestSerializerOptions),
            Encoding.UTF8,
            MediaTypeNames.Application.Json);
        var response = await client.PostAsync("/availability_gateway/approve_new_roots", jsonBody);

        response.EnsureSuccessStatusCode();

        return (await response.Content.ReadAsStringAsync()).Equals("signature accepted");
    }

    /// <inheritdoc />
    public async Task<BatchModel> GetBatchDataAsync(int batchId, bool validateRollup)
    {
        var client = CreateClient();

        var endpoint = $"/availability_gateway/get_batch_data?batch_id={batchId}&validate_rollup={validateRollup}";
        var response = await client.GetAsync(endpoint);

        response.EnsureSuccessStatusCode();

        return await JsonSerializer.DeserializeAsync<BatchModel>(await response.Content.ReadAsStreamAsync());
    }

    /// <inheritdoc />
    public Task<int> GetOrderTreeHeightAsync()
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