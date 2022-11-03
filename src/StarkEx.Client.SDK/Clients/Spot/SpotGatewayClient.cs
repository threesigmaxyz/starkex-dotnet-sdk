// TODO THIS SDK CANT GO PUBLIC WITHOUT A LICENSE FIRST!
// TODO Only publish relevant assemblies, no need to publish helpers classes like converters

namespace StarkEx.Client.SDK.Clients.Spot;

using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Commons;
using StarkEx.Client.SDK.Interfaces.Spot;
using StarkEx.Client.SDK.Models.Spot.RequestModels;
using StarkEx.Client.SDK.Models.Spot.ResponseModels;
using StarkEx.Client.SDK.Models.Spot.TransactionModels;
using StarkEx.Client.SDK.Settings;

/// <inheritdoc />
public class SpotGatewayClient : ISpotGatewayClient
{
    private readonly IHttpClientFactory httpClientFactory;

    private readonly JsonSerializerOptions requestSerializerOptions = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    };

    private readonly StarkExApiSettings settings;

    public SpotGatewayClient(
        IHttpClientFactory httpClientFactory,
        StarkExApiSettings settings)
    {
        this.httpClientFactory = httpClientFactory;
        this.settings = settings;
    }

    /// <param name="cancellationToken"></param>
    /// <inheritdoc />
    public async Task<int> GetFirstUnusedTxAsync(CancellationToken cancellationToken)
    {
        var client = CreateClient();

        var endpoint = $"/{settings.Version}/gateway/testing/get_first_unused_tx_id";
        var response = await client.GetAsync(endpoint, cancellationToken);

        response.EnsureSuccessStatusCode();

        return int.Parse(await response.Content.ReadAsStringAsync(cancellationToken));
    }

    /// <inheritdoc />
    public async Task<string> GetStarkDexAddress(CancellationToken cancellationToken)
    {
        var client = CreateClient();

        var endpoint = $"/{settings.Version}/gateway/testing/get_stark_dex_address";
        var response = await client.GetAsync(endpoint, cancellationToken);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<int> GetTimeSpentByOldestUnacceptedTxInSystem(CancellationToken cancellationToken)
    {
        var client = CreateClient();

        var endpoint = $"/{settings.Version}/gateway/get_time_spent_by_oldest_unaccepted_tx_in_system";
        var response = await client.GetAsync(endpoint, cancellationToken);

        response.EnsureSuccessStatusCode();

        return int.Parse(await response.Content.ReadAsStringAsync(cancellationToken));
    }

    public async Task<ResponseModel> AddTransactionAsync<T>(
        T requestModel,
        CancellationToken cancellationToken)
        where T : BaseRequestModel
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

        response.EnsureSuccessStatusCode();

        return await JsonSerializer.DeserializeAsync<TransactionModel>(
            await response.Content.ReadAsStreamAsync(cancellationToken), cancellationToken: cancellationToken);
    }

    private static void ValidateRequestModel(BaseRequestModel requestModel)
    {
        if (requestModel is null)
        {
            throw new ArgumentNullException(nameof(requestModel));
        }
    }

    private async Task<ResponseModel> SendRequestAsync<T>(
        T requestModel,
        CancellationToken cancellationToken)
        where T : BaseRequestModel
    {
        var client = CreateClient();

        var jsonBody = new StringContent(
            JsonSerializer.Serialize(requestModel, requestSerializerOptions),
            Encoding.UTF8,
            MediaTypeNames.Application.Json);

        var response =
            await client.PostAsync($"/{settings.Version}/gateway/add_transaction", jsonBody, cancellationToken);

        await ClientResponseValidation.ValidateSuccessStatusCode(response, cancellationToken);

        return await JsonSerializer.DeserializeAsync<ResponseModel>(
            await response.Content.ReadAsStreamAsync(cancellationToken), cancellationToken: cancellationToken);
    }

    private HttpClient CreateClient()
    {
        var client = httpClientFactory.CreateClient();

        client.BaseAddress = settings.BaseAddress;

        return client;
    }
}