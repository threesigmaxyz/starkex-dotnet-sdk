namespace StarkEx.Client.SDK.Tests.Clients.Spot;

using System.Net;
using System.Numerics;
using FluentAssertions;
using Moq;
using Moq.Protected;
using StarkEx.Client.SDK.Clients.Spot;
using StarkEx.Client.SDK.Interfaces.Spot;
using StarkEx.Client.SDK.Models.Spot.FeederGatewayModels;
using StarkEx.Client.SDK.Models.Spot.TransactionModels;
using StarkEx.Client.SDK.Settings;
using StarkEx.Client.SDK.Tests.Mocks.Helpers.Spot;
using Xunit;

public class SpotFeederGatewayClientTests
{
    private const string BaseAddress = "https://localhost";
    private const string Version = "v2";

    private readonly Mock<IHttpClientFactory> httpClientFactory;
    private readonly Mock<HttpMessageHandler> httpMessageHandler;
    private readonly StarkExApiSettings settings;

    public SpotFeederGatewayClientTests()
    {
        httpClientFactory = new Mock<IHttpClientFactory>();
        httpMessageHandler = new Mock<HttpMessageHandler>();
        settings = new StarkExApiSettings
        {
            BaseAddress = new Uri(BaseAddress),
            Version = Version,
        };
    }

    [Fact]
    public async Task GetBatchEnclosingIdsRequest_BatchEnclosingIdsRequestIsValid_GetRequestIsSentWithCorrectParameters()
    {
        // Arrange
        MockHttpClient(SpotStarkExApiResponses.GetExpectedBatchEnclosingIdsResponseModel());
        var expectedBatchEnclosingIdResponseModel = new BatchEnclosingIdResponseModel { FirstId = 10000, LastId = 12345 };

        var path = $"/{settings.Version}/feeder_gateway/get_batch_enclosing_ids";
        var query = "?batch_id=1";
        var batchId = 1;
        var target = CreateService();

        // Act
        var responseModel = await target.GetBatchEnclosingIdsAsync(batchId, CancellationToken.None);

        // Assert
        AssertHttpRequestMessage(path, query);
        responseModel.Should().BeEquivalentTo(expectedBatchEnclosingIdResponseModel);
    }

    [Fact]
    public async Task GetIdsRequest_BatchIdsRequestIsValid_GetRequestIsSentWithCorrectParameters()
    {
        // Arrange
        MockHttpClient(SpotStarkExApiResponses.GetExpectedBatchIdsResponseModel());
        var expectedBatchIdResponseModel = new BatchIdsResponseModel { BatchIds = new List<int> { 123, 456 } };

        var path = $"/{settings.Version}/feeder_gateway/get_batch_ids";
        var vaultRoot = "0x123";
        var orderRoot = "0x567";
        var sequenceNumber = 3;

        var query = $"?vault_root={vaultRoot}&order_root={orderRoot}&sequence_number={sequenceNumber}";

        var target = CreateService();

        // Act
        var responseModel = await target.GetBatchIdsAsync(vaultRoot, orderRoot, sequenceNumber, CancellationToken.None);

        // Assert
        AssertHttpRequestMessage(path, query);
        responseModel.Should().BeEquivalentTo(expectedBatchIdResponseModel);
    }

    [Fact]
    public async Task GetBatchInfo_BatchInfoRequestIsValid_GetRequestIsSentWithCorrectParameters()
    {
        // Arrange
        MockHttpClient(SpotStarkExApiResponses.GetExpectedBatchInfoResponseModel());

        var expectedBatchInfoResponseModel = new BatchInfoResponseModel
        {
            OrderRoot = new RootModel
            {
                Height = 31,
                Root = "04695d9d13ec0eeafc07b7d0c5da3f30e42e468bc69413c2b77e62cd8cdeb9a8",
            },
            PrevBatchId = 5677,
            PrevOrderRoot = new RootModel
            {
                Height = 31,
                Root = "04695d9d13ec0eeafc07b7d0c5da3f30e42e468bc69413c2b77e62cd8cdeb9a8",
            },
            PrevVaultRoot = new RootModel
            {
                Height = 31,
                Root = "0075364111a7a336756626d19fc8ec8df6328a5e63681c68ffaa312f6bf98c5c",
            },
            SequenceNumber = 1234,
            TimeCreated = 1614665098,
            Transactions = new List<TransactionInfoModel>
            {
                new()
                {
                    AltTxs = new List<TransactionModel>(),
                    TxId = 123456,
                    WasReplaced = false,
                    OriginalTransaction = new DepositModel
                    {
                        Amount = new BigInteger(1000),
                        StarkKey = "0x51ddea3f6955ab96cdbb24e2b88c7ce6e7d1afea354e41be88d9dca5c7f0651",
                        TokenId = "0x2dc6cb834b9f656f3366c0c263e75458a814074b165bc1661b7460e7c972759",
                        VaultId = 931081472,
                    },
                },
            },
            VaultRoot = new RootModel
            {
                Height = 31,
                Root = "00bc9d7b7716bc33b1db5b7509c0a076ab9424ba5e16dd26de8097a62f1ef1d1",
            },
        };

        var path = $"/{settings.Version}/feeder_gateway/get_batch_info";
        const string query = "?batch_id=1";
        const int batchId = 1;
        var target = CreateService();

        // Act
        var responseModel = await target.GetBatchInfoAsync(batchId, CancellationToken.None);

        // Assert
        AssertHttpRequestMessage(path, query);
        responseModel.Should().BeEquivalentTo(expectedBatchInfoResponseModel);
    }

    [Fact]
    public async Task GetBatchInfoV2_BatchInfoRequestIsValid_GetRequestIsSentWithCorrectParameters()
    {
        // Arrange
        MockHttpClient(SpotStarkExApiResponses.GetExpectedBatchInfoV2ResponseModel());
        var expectedBatchInfoV2ResponseModel = new BatchInfoV2ResponseModel
        {
            SequenceNumber = 1234,
            TimeCreated = 1614665098,
            Transactions = new List<TransactionInfoModel>
            {
                new()
                {
                    AltTxs = new List<TransactionModel>(),
                    TxId = 123456,
                    WasReplaced = false,
                    OriginalTransaction = new DepositModel
                    {
                        Amount = new BigInteger(1000),
                        StarkKey = "0x51ddea3f6955ab96cdbb24e2b88c7ce6e7d1afea354e41be88d9dca5c7f0651",
                        TokenId = "0x2dc6cb834b9f656f3366c0c263e75458a814074b165bc1661b7460e7c972759",
                        VaultId = 931081472,
                    },
                },
            },
            PrevBatchId = 5677,
        };

        var path = $"/{settings.Version}/feeder_gateway/get_batch_info_version2";
        var query = "?batch_id=1";
        var batchId = 1;
        var target = CreateService();

        // Act
        var responseModel = await target.GetBatchInfoV2Async(batchId, CancellationToken.None);

        // Assert
        AssertHttpRequestMessage(path, query);
        responseModel.Should().BeEquivalentTo(expectedBatchInfoV2ResponseModel);
    }

    [Fact]
    public async Task GetChainId_GetRequestIsSentCorrectly()
    {
        // Arrange
        MockHttpClient("1");
        var expectedResponse = 1;

        var path = $"/{settings.Version}/feeder_gateway/get_l1_blockchain_id";
        var query = string.Empty;
        var target = CreateService();

        // Act
        var response = await target.GetChainIdAsync(CancellationToken.None);

        // Assert
        AssertHttpRequestMessage(path, query);
        response.Should().Be(expectedResponse);
    }

    [Fact]
    public async Task GetLastBatchId_LastBatchRequestIsValid_GetRequestIsSentWithCorrectParameters()
    {
        // Arrange
        MockHttpClient("1");
        var expectedResponse = 1;

        var path = $"/{settings.Version}/feeder_gateway/get_last_batch_id";
        var query = string.Empty;
        var target = CreateService();

        // Act
        var responseModel = await target.GetLastBatchIdAsync(CancellationToken.None);

        // Assert
        AssertHttpRequestMessage(path, query);
        responseModel.Should().Be(expectedResponse);
    }

    [Fact]
    public async Task GetPrevBatchIdRequest_PrevBatchIdRequestIsValid_GetRequestIsSentWithCorrectParameters()
    {
        // Arrange
        MockHttpClient("1");
        var expectedResponse = 1;

        var path = $"/{settings.Version}/feeder_gateway/get_prev_batch_id";
        var query = "?batch_id=1";
        var batchId = 1;
        var target = CreateService();

        // Act
        var responseModel = await target.GetPrevBatchIdRequestAsync(batchId, CancellationToken.None);

        // Assert
        AssertHttpRequestMessage(path, query);
        responseModel.Should().Be(expectedResponse);
    }

    [Fact]
    public async Task GetIsAlive_GetRequestIsSentCorrectly()
    {
        // Arrange
        var mockedResponse = "FeederGateway is alive!";
        MockHttpClient(mockedResponse);
        var expectedResponse = true;

        var path = $"/{settings.Version}/feeder_gateway/is_alive";
        var query = string.Empty;
        var target = CreateService();

        // Act
        var responseModel = await target.GetIsAliveAsync(CancellationToken.None);

        // Assert
        AssertHttpRequestMessage(path, query);
        responseModel.Should().Be(expectedResponse);
    }

    [Fact]
    public async Task GetIsReady_GetRequestIsSentCorrectly()
    {
        // Arrange
        var mockedResponse = "FeederGateway is ready!";
        MockHttpClient(mockedResponse);

        var expectedResponse = true;

        var path = $"/{settings.Version}/feeder_gateway/is_ready";
        var query = string.Empty;
        var target = CreateService();

        // Act
        var responseModel = await target.GetIsReadyAsync(CancellationToken.None);

        // Assert
        AssertHttpRequestMessage(path, query);
        responseModel.Should().Be(expectedResponse);
    }

    private ISpotFeederGatewayClient CreateService()
    {
        return new SpotFeederGatewayClient(httpClientFactory.Object, settings);
    }

    private void AssertHttpRequestMessage(string path, string query)
    {
        httpMessageHandler.Protected()
            .Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(
                    x =>
                        x.RequestUri!.AbsolutePath.Equals(path) && x.RequestUri!.Query.Equals(query)),
                ItExpr.IsAny<CancellationToken>());
    }

    private void MockHttpClient(string expectedCode)
    {
        httpMessageHandler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(expectedCode),
                })
            .Verifiable();

        var httpClient = new HttpClient(httpMessageHandler.Object);

        httpClientFactory
            .Setup(cf => cf.CreateClient(It.IsAny<string>()))
            .Returns(httpClient);
    }
}
