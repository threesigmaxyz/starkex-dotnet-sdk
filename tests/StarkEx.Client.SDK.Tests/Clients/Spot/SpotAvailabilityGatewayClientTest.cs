namespace StarkEx.Client.SDK.Tests.Clients.Spot;

using System.Net;
using System.Numerics;
using FluentAssertions;
using Moq;
using Moq.Protected;
using StarkEx.Client.SDK.Clients.Spot;
using StarkEx.Client.SDK.Interfaces.Spot;
using StarkEx.Client.SDK.Models.Spot.AvailabilityGateway;
using StarkEx.Client.SDK.Settings;
using StarkEx.Client.SDK.Tests.Mocks.Helpers;
using StarkEx.Client.SDK.Tests.Mocks.Helpers.Spot;
using Xunit;

public class SpotAvailabilityGatewayClientTest
{
    private const string BaseAddress = "https://localhost";
    private const string Version = "v2";

    private readonly Mock<IHttpClientFactory> httpClientFactory;
    private readonly Mock<HttpMessageHandler> httpMessageHandler;
    private readonly StarkExApiSettings settings;

    public SpotAvailabilityGatewayClientTest()
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
    public async Task ApproveNewRootsAsync_CommitteeSignatureIsValid_PostRequestIsSentWithCorrectRequestBody()
    {
        // Arrange
        MockHttpClient("signature accepted");
        var committeeSignature = new CommitteeSignatureModel
        {
            BatchId = 5678,
            Signature = "0x1256a4d7d152a0aafa2b75eb06eddbd0abb5621572fd4292",
            MemberKey = "0xb2849CBc25853685bfc4815Ab51d28E810606A48",
            ClaimHash = "0x476a9f237758279caadaa21ecadd0126fe7ae99eb5c41b7cfdf1f42fd63db577",
        };

        // Act
        var target = CreateService();
        var result = await target.ApproveNewRootsAsync(committeeSignature);

        // Assert
        result.Should().BeTrue();
        AssertHttpRequestMessage(
            "/availability_gateway/approve_new_roots",
            SpotStarkExApiRequests.GetExpectedCommitteeSignatureModel());
    }

    [Fact]
    public async Task GetBatchDataAsync_RequestIsValid_ResponseIsCorrectlyParsed()
    {
        // Arrange
        MockHttpClient(SpotStarkExApiResponses.GetBatchDataMock());

        // Act
        var target = CreateService();
        var result = await target.GetBatchDataAsync(1234, true);

        // Assert
        var expectedResult = new BatchModel
        {
            Update = new StateUpdateModel
            {
                PrevBatchId = 5677,
                OrderRoot = "000AB5B4CE84EB13D24D4DC89BC96BA10756A91CF180BE92E015F7941D7E",
                Orders = new Dictionary<string, OrderStateModel>
                {
                    ["54850"] = new() { FulfilledAmount = new BigInteger(845) },
                    ["54851"] = new() { FulfilledAmount = new BigInteger(1975) },
                },
                RollupVaultRoot = "DEADBEEF",
                RollupVaults = new Dictionary<string, VaultStateModel>
                {
                    ["9223372037023444327"] = new() { StarkKey = "0x1234", TokenId = "0x5678", Balance = new BigInteger(9) },
                },
                VaultRoot = "037912467B7B3CC02DEEC7B56829E3AE494B8D96F4E79D6CA7CC766C64D1",
                Vaults = new Dictionary<string, VaultStateModel>
                {
                    ["168668519"] = new()
                    {
                        StarkKey = "0xc35327b2be68ae537e02f0d16dd81cf6baac5e02ba28d0342ec8e",
                        TokenId = "0x31e95e8dc9447dfb706f0dfa2d8243c832de7d8da4edd87aa8f3f0008",
                        Balance = 300,
                    },
                    ["694774812"] = new()
                    {
                        StarkKey = "0x7c5a4b3c65e46bc7b7b1e5dce60b5b5c56d9429f27acf53ec45b9",
                        TokenId = "0x31e95e8dc9447dfb706f0dfa2d8243c832de7d8da4edd87aa8f3f0008",
                        Balance = 1000,
                    },
                },
            },
        };
        result.Should().BeEquivalentTo(expectedResult); // TODO is this correct?
    }

    private ISpotAvailabilityGatewayClient CreateService()
    {
        return new SpotAvailabilityGatewayClient(httpClientFactory.Object, settings);
    }

    private void MockHttpClient(string response)
    {
        httpMessageHandler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(response),
            })
            .Verifiable();

        var httpClient = new HttpClient(httpMessageHandler.Object);

        httpClientFactory
            .Setup(cf => cf.CreateClient(It.IsAny<string>()))
            .Returns(httpClient);
    }

    private void AssertHttpRequestMessage(string expectedEndpoint, string expectedRequestModel)
    {
        httpMessageHandler.Protected()
            .Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(x =>
                    x.RequestUri!.AbsolutePath.Equals(expectedEndpoint) &&
                    x.Content!.ReadAsStringAsync().Result.RemoveNewLineCharsAndSpacesAndTrim().Equals(expectedRequestModel.RemoveNewLineCharsAndSpacesAndTrim())),
                ItExpr.IsAny<CancellationToken>());
    }
}