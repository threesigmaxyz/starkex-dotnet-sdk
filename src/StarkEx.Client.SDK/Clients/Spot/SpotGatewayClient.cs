// TODO THIS SDK CANT GO PUBLIC WITHOUT A LICENSE FIRST!

namespace StarkEx.Client.SDK.Clients.Spot;

using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
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

    /// <inheritdoc />
    public async Task<int> GetFirstUnusedTxAsync()
    {
        var client = CreateClient();

        var endpoint = $"/{settings.Version}/gateway/testing/get_first_unused_tx_id";
        var response = await client.GetAsync(endpoint);

        response.EnsureSuccessStatusCode();

        return int.Parse(await response.Content.ReadAsStringAsync());
    }

    /// <inheritdoc />
    public async Task<string> GetStarkDexAddress()
    {
        var client = CreateClient();

        var endpoint = $"/{settings.Version}/gateway/testing/get_stark_dex_address";
        var response = await client.GetAsync(endpoint);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }

    /// <inheritdoc />
    public async Task<int> GetTimeSpentByOldestUnacceptedTxInSystem()
    {
        var client = CreateClient();

        var endpoint = $"/{settings.Version}/gateway/get_time_spent_by_oldest_unaccepted_tx_in_system";
        var response = await client.GetAsync(endpoint);

        response.EnsureSuccessStatusCode();

        return int.Parse(await response.Content.ReadAsStringAsync());
    }

    /// <inheritdoc />
    public async Task<TransactionModel> GetTransactionAsync(int txId)
    {
        var client = CreateClient();

        var endpoint = $"/{settings.Version}/gateway/get_transaction?tx_id={txId}";
        var response = await client.GetAsync(endpoint);

        response.EnsureSuccessStatusCode();

        return await JsonSerializer.DeserializeAsync<TransactionModel>(await response.Content.ReadAsStreamAsync());
    }

    public async Task<ResponseModel> AddTransactionAsync(MintRequestModel mintRequestModel)
    {
        return await SendTransactionAsync(mintRequestModel);
    }

    public async Task<ResponseModel> AddTransactionAsync(SettlementRequestModel settlementRequestModel)
    {
        return await SendTransactionAsync(settlementRequestModel);
    }

    public async Task<ResponseModel> AddTransactionAsync(TransferRequestModel transferRequestModel)
    {
        return await SendTransactionAsync(transferRequestModel);
    }

    public async Task<ResponseModel> AddTransactionAsync(DepositRequestModel depositRequestModel)
    {
        return await SendTransactionAsync(depositRequestModel);
    }

    public async Task<ResponseModel> AddTransactionAsync(WithdrawalRequestModel withdrawalRequestModel)
    {
        return await SendTransactionAsync(withdrawalRequestModel);
    }

    public async Task<ResponseModel> AddTransactionAsync(FullWithdrawalRequestModel fullWithdrawalRequestModel)
    {
        return await SendTransactionAsync(fullWithdrawalRequestModel);
    }

    public async Task<ResponseModel> AddTransactionAsync(FalseFullWithdrawalRequestModel falseFullWithdrawalRequestModel)
    {
        return await SendTransactionAsync(falseFullWithdrawalRequestModel);
    }

    public async Task<ResponseModel> AddTransactionAsync(MultiTransactionRequestModel multiTransactionRequestModel)
    {
        return await SendTransactionAsync(multiTransactionRequestModel);
    }

    private static void ValidateRequestModel(BaseRequestModel requestModel)
    {
        if (requestModel is null)
        {
            throw new ArgumentNullException(nameof(requestModel));
        }
    }

    private async Task<ResponseModel> SendTransactionAsync<T>(T requestModel)
        where T : BaseRequestModel
    {
        ValidateRequestModel(requestModel);

        return await SendRequestAsync(requestModel);
    }

    private async Task<ResponseModel> SendRequestAsync<T>(T requestModel)
        where T : BaseRequestModel
    {
        var client = CreateClient();

        var jsonBody = new StringContent(
            JsonSerializer.Serialize(requestModel, requestSerializerOptions),
            Encoding.UTF8,
            MediaTypeNames.Application.Json);

        var response = await client.PostAsync($"/{settings.Version}/gateway/add_transaction", jsonBody);

        response.EnsureSuccessStatusCode();

        return await JsonSerializer.DeserializeAsync<ResponseModel>(await response.Content.ReadAsStreamAsync());
    }

    private HttpClient CreateClient()
    {
        var client = httpClientFactory.CreateClient();

        client.BaseAddress = settings.BaseAddress;

        return client;
    }
}