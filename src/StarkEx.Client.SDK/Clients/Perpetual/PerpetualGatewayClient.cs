namespace StarkEx.Client.SDK.Clients.Perpetual;

using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Commons;
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
    public async Task<int> GetFirstUnusedTxAsync(CancellationToken cancellationToken)
    {
        var client = CreateClient();

        const string endpoint = "/get_first_unused_tx_id";
        var response = await client.GetAsync(endpoint, cancellationToken);

        response.EnsureSuccessStatusCode();

        return int.Parse(await response.Content.ReadAsStringAsync(cancellationToken));
    }

    public async Task<TransactionResponseModel> AddTransactionAsync<T>(
        T requestModel,
        CancellationToken cancellationToken)
        where T : BaseRequestModel
    {
        ValidateRequestModel(requestModel);

        return await SendRequestAsync(requestModel, cancellationToken);
    }

    private static void ValidateRequestModel(BaseRequestModel requestModel)
    {
        if (requestModel is null)
        {
            throw new ArgumentNullException(nameof(requestModel));
        }
    }

    private async Task<TransactionResponseModel> SendRequestAsync<T>(
        T requestModel,
        CancellationToken cancellationToken)
        where T : BaseRequestModel
    {
        var client = CreateClient();

        var jsonBody = new StringContent(
            JsonSerializer.Serialize(requestModel, requestSerializerOptions),
            Encoding.UTF8,
            MediaTypeNames.Application.Json);
        var response = await client.PostAsync("/add_transaction", jsonBody, cancellationToken);

        await ClientResponseValidation.ValidateSuccessStatusCode(response, cancellationToken);

        return await JsonSerializer.DeserializeAsync<TransactionResponseModel>(
            await response.Content.ReadAsStreamAsync(cancellationToken), cancellationToken: cancellationToken);
    }

    private HttpClient CreateClient()
    {
        var client = httpClientFactory.CreateClient();

        client.BaseAddress = settings.BaseAddress;

        return client;
    }
}