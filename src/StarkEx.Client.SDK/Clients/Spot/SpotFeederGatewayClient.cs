﻿namespace StarkEx.Client.SDK.Clients.Spot;

using System.Runtime.Serialization;
using System.Text.Json;
using StarkEx.Client.SDK.Enums.Spot;
using StarkEx.Client.SDK.Interfaces.Spot;
using StarkEx.Client.SDK.Models.Spot.FeederGatewayModels;
using StarkEx.Client.SDK.Settings;

/// <inheritdoc cref="StarkEx.Client.SDK.Interfaces.Spot.ISpotFeederGatewayClient" />
public class SpotFeederGatewayClient : BaseClient, ISpotFeederGatewayClient
{
    public SpotFeederGatewayClient(
        IHttpClientFactory httpClientFactory,
        StarkExApiSettings settings)
    {
        this.httpClientFactory = httpClientFactory;
        this.settings = settings;
    }

    /// <inheritdoc />
    public async Task<BatchEnclosingIdResponseModel> GetBatchEnclosingIdsAsync(
        int batchId,
        CancellationToken cancellationToken)
    {
        var path = $"/{settings.Version}/feeder_gateway/get_batch_enclosing_ids";
        var query = $"?batch_id={batchId}";

        return await SendGetRequest<BatchEnclosingIdResponseModel>(path, query, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<BatchIdsResponseModel> GetBatchIdsAsync(
        string vaultRoot,
        string orderRoot,
        int sequenceNumber,
        CancellationToken cancellationToken)
    {
        var path = $"/{settings.Version}/feeder_gateway/get_batch_ids";
        var query = $"?vault_root={vaultRoot}&order_root={orderRoot}&sequence_number={sequenceNumber}";

        return await SendGetRequest<BatchIdsResponseModel>(path, query, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<BatchInfoResponseModel> GetBatchInfoAsync(
        int batchId,
        CancellationToken cancellationToken)
    {
        var path = $"/{settings.Version}/feeder_gateway/get_batch_info";
        var query = $"?batch_id={batchId}";

        return await SendGetRequest<BatchInfoResponseModel>(path, query, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<BatchInfoV2ResponseModel> GetBatchInfoV2Async(
        int batchId,
        CancellationToken cancellationToken)
    {
        var path = $"/{settings.Version}/feeder_gateway/get_batch_info_version2";
        var query = $"?batch_id={batchId}";

        return await SendGetRequest<BatchInfoV2ResponseModel>(path, query, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<int> GetChainIdAsync(CancellationToken cancellationToken)
    {
        var path = $"/{settings.Version}/feeder_gateway/get_l1_blockchain_id";
        var query = string.Empty;

        return await SendGetRequest<int>(path, query, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<int> GetLastBatchIdAsync(CancellationToken cancellationToken)
    {
        var path = $"/{settings.Version}/feeder_gateway/get_last_batch_id";
        var query = string.Empty;

        return await SendGetRequest<int>(path, query, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<int> GetPrevBatchIdRequestAsync(
        int batchId,
        CancellationToken cancellationToken)
    {
        var path = $"/{settings.Version}/feeder_gateway/get_prev_batch_id";
        var query = $"?batch_id={batchId}";

        return await SendGetRequest<int>(path, query, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<bool> GetIsAliveAsync(CancellationToken cancellationToken)
    {
        var path = $"/{settings.Version}/feeder_gateway/is_alive";

        var client = CreateClient();
        var response = await client.GetAsync(path, cancellationToken);
        response.EnsureSuccessStatusCode();

        var responseValue = await response.Content.ReadAsStringAsync(cancellationToken);

        var successMessage = GetEnumMemberAttrValue(typeof(FeederGatewayResponseMessages), FeederGatewayResponseMessages.FeederGatewayIsAliveMessage);

        return responseValue.Equals(successMessage);
    }

    /// <inheritdoc />
    public async Task<bool> GetIsReadyAsync(CancellationToken cancellationToken)
    {
        var path = $"/{settings.Version}/feeder_gateway/is_ready";

        var client = CreateClient();
        var response = await client.GetAsync(path, cancellationToken);
        response.EnsureSuccessStatusCode();

        var responseValue = await response.Content.ReadAsStringAsync(cancellationToken);

        var successMessage = GetEnumMemberAttrValue(typeof(FeederGatewayResponseMessages), FeederGatewayResponseMessages.FeederGatewayIsReadyMessage);

        return responseValue.Equals(successMessage);
    }

    private static string GetEnumMemberAttrValue(Type enumType, object enumVal)
    {
        var memInfo = enumType.GetMember(enumVal.ToString() ?? string.Empty);
        var attr = memInfo[0].GetCustomAttributes(false).OfType<EnumMemberAttribute>().FirstOrDefault();

        return attr?.Value ?? string.Empty;
    }

    private HttpClient CreateClient()
    {
        var client = httpClientFactory.CreateClient();

        client.BaseAddress = settings.BaseAddress;

        return client;
    }

    private async Task<T> SendGetRequest<T>(
        string path,
        string query,
        CancellationToken cancellationToken)
    {
        var client = CreateClient();
        var response = await client.GetAsync(path + query, cancellationToken);
        response.EnsureSuccessStatusCode();

        return await JsonSerializer.DeserializeAsync<T>(
            await response.Content.ReadAsStreamAsync(cancellationToken), cancellationToken: cancellationToken);
    }
}
