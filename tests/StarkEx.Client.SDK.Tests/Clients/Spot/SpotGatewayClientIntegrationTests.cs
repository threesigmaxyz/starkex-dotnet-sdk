namespace StarkEx.Client.SDK.Tests.Clients.Spot;

using FluentAssertions;
using StarkEx.Client.SDK.Clients.Spot;
using StarkEx.Client.SDK.Enums.Spot;
using StarkEx.Client.SDK.Interfaces.Spot;
using StarkEx.Client.SDK.Models.Spot.RequestModels;
using StarkEx.Client.SDK.Models.Spot.TransactionModels;
using StarkEx.Client.SDK.Settings;
using StarkEx.Client.SDK.Tests.Helpers;
using Xunit;

public class SpotGatewayClientIntegrationTests
{
    private const string BaseAddress = "https://gw.playground-v2.starkex.co";
    private const string Version = "v2";

    private readonly StarkExApiSettings settings;

    public SpotGatewayClientIntegrationTests()
    {
        settings = new StarkExApiSettings
        {
            BaseAddress = new Uri(BaseAddress),
            Version = Version,
        };
    }

    [Fact]
    public async Task GetFirstUnusedTxAsync_HappyPath_Success()
    {
        // Arrange
        const int expectedFirstUnusedTx = 1144; // playground value as of 2022-12-07
        var target = CreateService();

        // Act
        var firstUnusedTx = await target.GetFirstUnusedTxAsync(CancellationToken.None);

        // Assert
        firstUnusedTx.Should().BeGreaterOrEqualTo(expectedFirstUnusedTx);
    }

    [Fact]
    public async Task GetStarkDexAddress_HappyPath_Success()
    {
        // Arrange
        const string expectedStarkDexAddress = "\"0x5731aEa1809BE0454907423083fb879079FB69dF\"";
        var target = CreateService();

        // Act
        var starkDexAddress = await target.GetStarkDexAddress(CancellationToken.None);

        // Assert
        starkDexAddress.Should().Be(expectedStarkDexAddress);
    }

    [Fact]
    public async Task GetTimeSpentByOldestUnacceptedTxInSystem_HappyPath_Success()
    {
        // Arrange
        var target = CreateService();

        // Act
        var timeSpent = await target.GetTimeSpentByOldestUnacceptedTxInSystem(CancellationToken.None);

        // Assert
        timeSpent.Should().BeGreaterOrEqualTo(0);
    }

    [Fact]
    public async Task AddDepositTransaction_HappyPath_Success()
    {
        // Arrange
        var target = CreateService();

        var depositRequestModel = new RequestModel
        {
            TransactionId = await target.GetFirstUnusedTxAsync(CancellationToken.None),
            Transaction = new DepositModel
            {
                Amount = 4029557120079369747,
                StarkKey = "0x7c65c1e82e2e662f728b4fa42485e3a0a5d2f346baa9455e3e70682c2094cac",
                TokenId = "0x2dd48fd7a024204f7c1bd874da5e709d4713d60c8a70639eb1167b367a9c378",
                VaultId = 1654615998,
            },
        };

        // Act
        var response = await target.AddTransactionAsync(depositRequestModel, CancellationToken.None);

        // Assert
        response.Code.Should().Be(SpotApiCodes.TransactionPending);
    }

    private ISpotGatewayClient CreateService()
    {
        var httpClientFactory = new DefaultHttpClientFactory();
        return new SpotGatewayClient(httpClientFactory, settings);
    }
}
