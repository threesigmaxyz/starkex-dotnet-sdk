namespace StarkEx.Client.SDK.Clients.Perpetual;

using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Interfaces.Perpetual;
using StarkEx.Client.SDK.Models.Perpetual.RequestModels;
using StarkEx.Client.SDK.Models.Perpetual.ResponseModels;
using StarkEx.Client.SDK.Settings;

/// <inheritdoc />
public class PerpetualGatewayClient : IPerpetualGatewayClient
{
    private readonly IHttpClientFactory httpClientFactory;

    private readonly JsonSerializerOptions requestSerializerOptions = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    };

    private readonly StarkExApiSettings settings;

    public PerpetualGatewayClient(
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

        const string endpoint = "/get_first_unused_tx_id";
        var response = await client.GetAsync(endpoint);

        response.EnsureSuccessStatusCode();

        return int.Parse(await response.Content.ReadAsStringAsync());
    }

    /// <inheritdoc />
    public async Task<TransactionResponseModel> AddTransactionAsync(ConditionalTransferRequestModel conditionalTransferRequestModel)
    {
        return await SendTransactionAsync(conditionalTransferRequestModel);
    }

    /// <inheritdoc />
    public async Task<TransactionResponseModel> AddTransactionAsync(DeleverageRequestModel deleverageRequestModel)
    {
        return await SendTransactionAsync(deleverageRequestModel);
    }

    /// <inheritdoc />
    public async Task<TransactionResponseModel> AddTransactionAsync(DepositRequestModel depositRequestModel)
    {
        return await SendTransactionAsync(depositRequestModel);
    }

    /// <inheritdoc />
    public async Task<TransactionResponseModel> AddTransactionAsync(ForcedTradeRequestModel forcedTradeRequestModel)
    {
        return await SendTransactionAsync(forcedTradeRequestModel);
    }

    /// <inheritdoc />
    public async Task<TransactionResponseModel> AddTransactionAsync(ForcedWithdrawalRequestModel forcedTradeRequestModel)
    {
        return await SendTransactionAsync(forcedTradeRequestModel);
    }

    /// <inheritdoc />
    public async Task<TransactionResponseModel> AddTransactionAsync(FundingTickRequestModel fundingTickRequestModel)
    {
        return await SendTransactionAsync(fundingTickRequestModel);
    }

    /// <inheritdoc />
    public async Task<TransactionResponseModel> AddTransactionAsync(LiquidateRequestModel liquidateRequestModel)
    {
        return await SendTransactionAsync(liquidateRequestModel);
    }

    /// <inheritdoc />
    public async Task<TransactionResponseModel> AddTransactionAsync(MultiTransactionRequestModel multiTransactionRequestModel)
    {
        return await SendTransactionAsync(multiTransactionRequestModel);
    }

    /// <inheritdoc />
    public async Task<TransactionResponseModel> AddTransactionAsync(OraclePricesTickRequestModel oraclePricesTickRequestModel)
    {
        return await SendTransactionAsync(oraclePricesTickRequestModel);
    }

    /// <inheritdoc />
    public async Task<TransactionResponseModel> AddTransactionAsync(TradeRequestModel tradeRequestModel)
    {
        return await SendTransactionAsync(tradeRequestModel);
    }

    /// <inheritdoc />
    public async Task<TransactionResponseModel> AddTransactionAsync(TransferRequestModel transferRequestModel)
    {
        return await SendTransactionAsync(transferRequestModel);
    }

    /// <inheritdoc />
    public async Task<TransactionResponseModel> AddTransactionAsync(WithdrawalRequestModel withdrawalRequestModel)
    {
        return await SendTransactionAsync(withdrawalRequestModel);
    }

    /// <inheritdoc />
    public async Task<TransactionResponseModel> AddTransactionAsync(WithdrawalToAddressRequestModel withdrawalToAddressRequestModel)
    {
        return await SendTransactionAsync(withdrawalToAddressRequestModel);
    }

    private static void ValidateRequestModel(BaseRequestModel requestModel)
    {
        if (requestModel is null)
        {
            throw new ArgumentNullException(nameof(requestModel));
        }
    }

    private async Task<TransactionResponseModel> SendTransactionAsync<T>(T requestModel)
        where T : BaseRequestModel
    {
        ValidateRequestModel(requestModel);

        return await SendRequestAsync(requestModel);
    }

    private async Task<TransactionResponseModel> SendRequestAsync<T>(T requestModel)
        where T : BaseRequestModel
    {
        var client = CreateClient();

        var jsonBody = new StringContent(
            JsonSerializer.Serialize(requestModel, requestSerializerOptions),
            Encoding.UTF8,
            MediaTypeNames.Application.Json);
        var response = await client.PostAsync("/add_transaction", jsonBody);

        response.EnsureSuccessStatusCode();

        return await JsonSerializer.DeserializeAsync<TransactionResponseModel>(await response.Content.ReadAsStreamAsync());
    }

    private HttpClient CreateClient()
    {
        var client = httpClientFactory.CreateClient();

        client.BaseAddress = settings.BaseAddress;

        return client;
    }
}