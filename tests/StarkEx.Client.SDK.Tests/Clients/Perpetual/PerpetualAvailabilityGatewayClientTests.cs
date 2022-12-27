namespace StarkEx.Client.SDK.Tests.Clients.Perpetual;

using System.Net;
using FluentAssertions;
using Moq;
using Moq.Protected;
using StarkEx.Client.SDK.Clients.Perpetual;
using StarkEx.Client.SDK.Interfaces.Perpetual;
using StarkEx.Client.SDK.Models.Perpetual.AvailabilityModels;
using StarkEx.Client.SDK.Settings;
using StarkEx.Client.SDK.Tests.Mocks.Helpers.Perpetual;
using Xunit;

public class PerpetualAvailabilityGatewayClientTests
{
    private const string BaseAddress = "https://localhost";
    private const string Version = "v2";

    private readonly Mock<IHttpClientFactory> httpClientFactory;
    private readonly Mock<HttpMessageHandler> httpMessageHandler;
    private readonly StarkExApiSettings settings;

    public PerpetualAvailabilityGatewayClientTests()
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
    public async Task ApproveNewRootsAsync_RequestIsValid_ResponseIsCorrectlyParsed()
    {
        // Arrange
        MockHttpClient("signature accepted");
        var expectedResponse = "signature accepted";

        var committeeSignatureModel = new CommitteeSignatureModel
        {
            BatchId = 5678,
            Signature = "0x1256a4d7d152a0aafa2b75eb06eddbd0abb5621572fd4292",
            MemberKey = "0xb2849CBc25853685bfc4815Ab51d28E810606A48",
            ClaimHash = "0x476a9f237758279caadaa21ecadd0126fe7ae99eb5c41b7cfdf1f42fd63db577",
        };

        var target = CreateService();

        // Act
        var response = await target.ApproveNewRootsAsync(committeeSignatureModel, CancellationToken.None);

        // Assert
        response.Should().Be(expectedResponse);
    }

    [Fact]
    public async Task GetBatchData_RequestIsValid_ResponseIsCorrectlyParsed()
    {
        // Arrange
        MockHttpClient(PerpetualStarkExApiResponses.GetExpectedStateUpdateModel());

        var expectedBatchModel = new PerpetualBatchModel
        {
            Update = new StateUpdateModel
            {
                OrderRoot = "000AB5B4CE84EB13D24D4DC89BC96BA10756A91CF180BE92E015F7941D7E",
                Orders = new Dictionary<string, OrderStateModel>
                {
                    {
                        "54850", new OrderStateModel
                        {
                            FulfilledAmount = 845,
                        }
                    },
                    {
                        "54851", new OrderStateModel
                        {
                            FulfilledAmount = 1975,
                        }
                    },
                },
                PositionRoot = "037912467B7B3CC02DEEC7B56829E3AE494B8D96F4E79D6CA7CC766C64D1",
                Positions = new Dictionary<string, PositionStateModel>
                {
                    {
                        "168668519", new PositionStateModel
                        {
                            Assets = new Dictionary<string, PositionAssetModel>
                            {
                                {
                                    "0x17", new PositionAssetModel
                                    {
                                        Balance = 64,
                                        CachedFundingIndex = 16,
                                    }
                                },
                                {
                                    "0x37", new PositionAssetModel
                                    {
                                        Balance = 26,
                                        CachedFundingIndex = 84,
                                    }
                                },
                            },
                            CollateralBalance = 88,
                            PublicKey = "0xc35327b2be68ae537e02f0d16dd81cf6baac5e02ba28d0342ec8e",
                        }
                    },
                },
                PrevBatchId = 5677,
            },
        };

        var batchId = 1024;

        // Act
        var target = CreateService();
        var response = await target.GetBatchDataAsync(batchId, CancellationToken.None);

        // Assert
        httpMessageHandler.Protected()
            .Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(x =>
                    x.RequestUri!.AbsolutePath.Equals("/availability_gateway/get_batch_data")),
                ItExpr.IsAny<CancellationToken>());

        response.Should().BeEquivalentTo(expectedBatchModel);
    }

    private IPerpetualAvailabilityGatewayClient CreateService()
    {
        return new PerpetualAvailabilityGatewayClient(httpClientFactory.Object, settings);
    }

    private void MockHttpClient(
        string expectedCode,
        HttpStatusCode expectedHttpStatusCode = HttpStatusCode.OK)
    {
        httpMessageHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage(expectedHttpStatusCode)
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
