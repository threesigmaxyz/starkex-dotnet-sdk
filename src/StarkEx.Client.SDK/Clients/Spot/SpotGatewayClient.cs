namespace StarkEx.Client.SDK.Clients.Spot;

using System.Net.Mime;
using System.Text;
using System.Text.Json;
using StarkEx.Client.SDK.Extensions;
using StarkEx.Client.SDK.Interfaces.Spot;
using StarkEx.Client.SDK.Models.Spot.RequestModels;
using StarkEx.Client.SDK.Models.Spot.ResponseModels;
using StarkEx.Client.SDK.Models.Spot.TransactionModels;
using StarkEx.Client.SDK.Settings;

/// <inheritdoc cref="StarkEx.Client.SDK.Interfaces.Spot.ISpotGatewayClient" />
public class SpotGatewayClient : BaseClient, ISpotGatewayClient
{
    public SpotGatewayClient(
        IHttpClientFactory httpClientFactory,
        StarkExApiSettings settings)
    {
        this.httpClientFactory = httpClientFactory;
        this.settings = settings;
    }

    /// <inheritdoc />
    public async Task<int> GetFirstUnusedTxAsync(CancellationToken cancellationToken)
    {
        var client = CreateClient();

        var endpoint = $"/{settings.Version}/gateway/testing/get_first_unused_tx_id";
        var response = await client.GetAsync(endpoint, cancellationToken);

        await response.ValidateSuccessStatusCode(cancellationToken);

        return int.Parse(await response.Content.ReadAsStringAsync(cancellationToken));
    }

    /// <inheritdoc />
    public async Task<string> GetStarkDexAddress(CancellationToken cancellationToken)
    {
        var client = CreateClient();

        var endpoint = $"/{settings.Version}/gateway/testing/get_stark_dex_address";
        var response = await client.GetAsync(endpoint, cancellationToken);

        await response.ValidateSuccessStatusCode(cancellationToken);

        return await response.Content.ReadAsStringAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<int> GetTimeSpentByOldestUnacceptedTxInSystem(CancellationToken cancellationToken)
    {
        var client = CreateClient();

        var endpoint = $"/{settings.Version}/gateway/get_time_spent_by_oldest_unaccepted_tx_in_system";
        var response = await client.GetAsync(endpoint, cancellationToken);

        await response.ValidateSuccessStatusCode(cancellationToken);

        return int.Parse(await response.Content.ReadAsStringAsync(cancellationToken));
    }

    public async Task<ResponseModel> AddTransactionAsync(
        RequestModel requestModel,
        CancellationToken cancellationToken)
    {
        ValidateRequestModel(requestModel);

        return await SendRequestAsync(requestModel, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<TransactionModel> GetTransactionAsync(
        int txId,
        CancellationToken cancellationToken)
    {
        var client = CreateClient();

        var endpoint = $"/{settings.Version}/gateway/get_transaction?tx_id={txId}";
        var response = await client.GetAsync(endpoint, cancellationToken);

        await response.ValidateSuccessStatusCode(cancellationToken);

        return await JsonSerializer.DeserializeAsync<TransactionModel>(
            await response.Content.ReadAsStreamAsync(cancellationToken), cancellationToken: cancellationToken);
    }

    private static void ValidateRequestModel(RequestModel requestModel)
    {
        if (requestModel is null)
        {
            throw new ArgumentNullException(nameof(requestModel));
        }
    }

    private async Task<ResponseModel> SendRequestAsync(
        RequestModel requestModel,
        CancellationToken cancellationToken)
    {
        var client = CreateClient();

        var jsonBody = new StringContent(
            JsonSerializer.Serialize(requestModel, requestSerializerOptions),
            Encoding.UTF8,
            MediaTypeNames.Application.Json);

        var response = await client.PostAsync($"/{settings.Version}/gateway/add_transaction", jsonBody, cancellationToken);

        await response.ValidateSuccessStatusCode(cancellationToken);

        return await JsonSerializer.DeserializeAsync<ResponseModel>(
            await response.Content.ReadAsStreamAsync(cancellationToken), cancellationToken: cancellationToken);
    }

    private HttpClient CreateClient()
    {
        var client = settings.HttpSpotClientName is null ?
            httpClientFactory.CreateClient() :
            httpClientFactory.CreateClient(settings.HttpSpotClientName);

        client.BaseAddress = settings.BaseAddress;

        return client;
    }
}
