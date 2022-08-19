namespace StarkEx.Client.SDK.Clients.Perpetual;

using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Interfaces.Perpetual;
using StarkEx.Client.SDK.Models.Perpetual.AvailabilityModels;
using StarkEx.Client.SDK.Settings;

/// <inheritdoc />
public class PerpetualAvailabilityGatewayClient : IPerpetualAvailabilityGatewayClient
{
    private readonly IHttpClientFactory httpClientFactory;

    private readonly JsonSerializerOptions requestSerializerOptions = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    };

    private readonly StarkExApiSettings settings;

    public PerpetualAvailabilityGatewayClient(
        IHttpClientFactory httpClientFactory,
        StarkExApiSettings settings)
    {
        this.httpClientFactory = httpClientFactory;
        this.settings = settings;
    }

    /// <inheritdoc />
    public async Task<string> ApproveNewRootsAsync(CommitteeSignatureModel committeeSignatureModel)
    {
        var client = CreateClient();

        var jsonBody = new StringContent(
            JsonSerializer.Serialize(committeeSignatureModel, requestSerializerOptions),
            Encoding.UTF8,
            MediaTypeNames.Application.Json);

        var response = await client.PostAsync("/availability_gateway/approve_new_roots", jsonBody);

        return await response.Content.ReadAsStringAsync();
    }

    /// <inheritdoc />
    public async Task<PerpetualBatchModel> GetBatchData(int batchId)
    {
        var client = CreateClient();

        const string path = "/availability_gateway/get_batch_data";
        var query = $"?batch_id={batchId}";

        var response = await client.GetAsync(path + query);

        return await JsonSerializer.DeserializeAsync<PerpetualBatchModel>(await response.Content.ReadAsStreamAsync());
    }

    private HttpClient CreateClient()
    {
        var client = httpClientFactory.CreateClient();

        client.BaseAddress = settings.BaseAddress;

        return client;
    }
}