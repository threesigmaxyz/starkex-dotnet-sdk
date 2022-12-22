namespace StarkEx.Client.SDK.Tests.Clients.Perpetual;

using System.Net;
using System.Numerics;
using FluentAssertions;
using Moq;
using Moq.Protected;
using StarkEx.Client.SDK.Clients.Perpetual;
using StarkEx.Client.SDK.Interfaces.Perpetual;
using StarkEx.Client.SDK.Models.Perpetual.ResponseModels;
using StarkEx.Client.SDK.Models.Perpetual.TransactionModels;
using StarkEx.Client.SDK.Settings;
using StarkEx.Client.SDK.Tests.Mocks.Helpers.Perpetual;
using Xunit;

public class PerpetualFeederGatewayClientTests
{
    private const string BaseAddress = "https://localhost";
    private const string Version = "v2";

    private readonly Mock<IHttpClientFactory> httpClientFactory;
    private readonly Mock<HttpMessageHandler> httpMessageHandler;
    private readonly StarkExApiSettings settings;

    public PerpetualFeederGatewayClientTests()
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
    public async Task GetFirstUnusedTxAsync_GetRequestIsSentCorrectly()
    {
        // Arrange
        MockHttpClient(PerpetualStarkExApiResponses.GetExpectedBatchResponseInfoModel());

        var expectedBatchInfoResponseModel = new BatchInfoResponseModel
        {
            OrderRoot = BigInteger.Parse(
                "33353732303235373731323634383839363236393439383130353737363838353737333732323333353635323133353239343736323830303631333239333735303231373238323133373832"),
            PositionRoot = BigInteger.Parse(
                "32383836323838323130373630343134343730323233333739383938383634333839393538343037383336363036393338353238353138303339303538353538393136393438343237373530"),
            PreviousBatchId = 49,
            PreviousOrderRoot = BigInteger.Parse(
                "373238373735323237343130393633303836383637373531333331353630323731313234313835373237313231363632343735333930373335343938313931373635343232323632343530"),
            PreviousPositionRoot =
                BigInteger.Parse("32393330353130363031373330333131393736333636373530313938393831383031333436303830313231333134363830313038303437363733323532323836393338353634393836343938"),
            SequenceNumber = 97,
            TimeCreated = 1649950823,
            TxsInfo = new List<TransactionInfoModel>
            {
                new()
                {
                    AltTxs = new List<TransactionModel>
                    {
                        new DepositModel
                        {
                            Amount = 2569146471088859254,
                            PositionId = 7758176404715800194,
                            PublicKey = "0x37ebdcde87a1613e443df789558867f5ba91faf7a024204f7c1bd874da5e70a",
                        },
                        new DepositModel
                        {
                            Amount = 2569146471088859254,
                            PositionId = 7758176404715800194,
                            PublicKey = "0x37ebdcde87a1613e443df789558867f5ba91faf7a024204f7c1bd874da5e70a",
                        },
                        new DepositModel
                        {
                            Amount = 2569146471088859254,
                            PositionId = 7758176404715800194,
                            PublicKey = "0x37ebdcde87a1613e443df789558867f5ba91faf7a024204f7c1bd874da5e70a",
                        },
                        new DepositModel
                        {
                            Amount = 2569146471088859254,
                            PositionId = 7758176404715800194,
                            PublicKey = "0x37ebdcde87a1613e443df789558867f5ba91faf7a024204f7c1bd874da5e70a",
                        },
                        new DepositModel
                        {
                            Amount = 2569146471088859254,
                            PositionId = 7758176404715800194,
                            PublicKey = "0x37ebdcde87a1613e443df789558867f5ba91faf7a024204f7c1bd874da5e70a",
                        },
                        new DepositModel
                        {
                            Amount = 2569146471088859254,
                            PositionId = 7758176404715800194,
                            PublicKey = "0x37ebdcde87a1613e443df789558867f5ba91faf7a024204f7c1bd874da5e70a",
                        },
                        new DepositModel
                        {
                            Amount = 2569146471088859254,
                            PositionId = 7758176404715800194,
                            PublicKey = "0x37ebdcde87a1613e443df789558867f5ba91faf7a024204f7c1bd874da5e70a",
                        },
                        new DepositModel
                        {
                            Amount = 2569146471088859254,
                            PositionId = 7758176404715800194,
                            PublicKey = "0x37ebdcde87a1613e443df789558867f5ba91faf7a024204f7c1bd874da5e70a",
                        },
                    },
                    OriginalTx = new DepositModel
                    {
                        Amount = 2011762206806500866,
                        PositionId = 4089715063379223119,
                        PublicKey = "0x149818d1759edc372ae22448b0163c1cd9d2b7d247a8333f7b0b7d2cda8056d",
                    },
                    OriginalTxId = 93,
                    WasReplaced = true,
                },
                new()
                {
                    AltTxs = new List<TransactionModel>(),
                    OriginalTx = new DepositModel
                    {
                        Amount = BigInteger.Parse("4466088725509430642"),
                        PositionId = BigInteger.Parse("10098502384506607689"),
                        PublicKey = "0x5129fb76288e1a5cc45782198a6416d1775336d71eacd0549a3e80e966e1278",
                    },
                    OriginalTxId = 90,
                    WasReplaced = false,
                },
                new()
                {
                    AltTxs = new List<TransactionModel>
                    {
                        new DepositModel
                        {
                            Amount = BigInteger.Parse("2569146471088859254"),
                            PositionId = BigInteger.Parse("7758176404715800194"),
                            PublicKey = "0x37ebdcde87a1613e443df789558867f5ba91faf7a024204f7c1bd874da5e70a",
                        },
                        new DepositModel
                        {
                            Amount = BigInteger.Parse("2569146471088859254"),
                            PositionId = BigInteger.Parse("7758176404715800194"),
                            PublicKey = "0x37ebdcde87a1613e443df789558867f5ba91faf7a024204f7c1bd874da5e70a",
                        },
                        new DepositModel
                        {
                            Amount = BigInteger.Parse("2569146471088859254"),
                            PositionId = BigInteger.Parse("7758176404715800194"),
                            PublicKey = "0x37ebdcde87a1613e443df789558867f5ba91faf7a024204f7c1bd874da5e70a",
                        },
                        new DepositModel
                        {
                            Amount = BigInteger.Parse("2569146471088859254"),
                            PositionId = BigInteger.Parse("7758176404715800194"),
                            PublicKey = "0x37ebdcde87a1613e443df789558867f5ba91faf7a024204f7c1bd874da5e70a",
                        },
                        new DepositModel
                        {
                            Amount = BigInteger.Parse("2569146471088859254"),
                            PositionId = BigInteger.Parse("7758176404715800194"),
                            PublicKey = "0x37ebdcde87a1613e443df789558867f5ba91faf7a024204f7c1bd874da5e70a",
                        },
                        new DepositModel
                        {
                            Amount = BigInteger.Parse("2569146471088859254"),
                            PositionId = BigInteger.Parse("7758176404715800194"),
                            PublicKey = "0x37ebdcde87a1613e443df789558867f5ba91faf7a024204f7c1bd874da5e70a",
                        },
                        new DepositModel
                        {
                            Amount = BigInteger.Parse("2569146471088859254"),
                            PositionId = BigInteger.Parse("7758176404715800194"),
                            PublicKey = "0x37ebdcde87a1613e443df789558867f5ba91faf7a024204f7c1bd874da5e70a",
                        },
                    },
                    OriginalTx = new DepositModel
                    {
                        Amount = BigInteger.Parse("10693485545316635201"),
                        PositionId = BigInteger.Parse("3444551907925535972"),
                        PublicKey = "0x148b275d7ab792809e469e6ec62b2c82648ee38e07405eb215663abc1f254b9",
                    },
                    OriginalTxId = 24,
                    WasReplaced = true,
                },
                new()
                {
                    AltTxs = new List<TransactionModel>(),
                    OriginalTx = new DepositModel
                    {
                        Amount = BigInteger.Parse("6134209306631123328"),
                        PositionId = BigInteger.Parse("1519513457529745562"),
                        PublicKey = "0x30bcab0d857010255d44936a1515607964a870c7c879b741d878f9f9cdf5a87",
                    },
                    OriginalTxId = 84,
                    WasReplaced = false,
                },
                new()
                {
                    AltTxs = new List<TransactionModel>
                    {
                        new DepositModel
                        {
                            Amount = BigInteger.Parse("2569146471088859254"),
                            PositionId = BigInteger.Parse("7758176404715800194"),
                            PublicKey = "0x37ebdcde87a1613e443df789558867f5ba91faf7a024204f7c1bd874da5e70a",
                        },
                        new DepositModel
                        {
                            Amount = BigInteger.Parse("2569146471088859254"),
                            PositionId = BigInteger.Parse("7758176404715800194"),
                            PublicKey = "0x37ebdcde87a1613e443df789558867f5ba91faf7a024204f7c1bd874da5e70a",
                        },
                    },
                    OriginalTx = new DepositModel
                    {
                        Amount = BigInteger.Parse("399123234584416836"),
                        PositionId = BigInteger.Parse("4035659881156086534"),
                        PublicKey = "0x950fd11db53334fb0323a1d576d4155ec17dbe176ea1b164264cd51ea45cd7",
                    },
                    OriginalTxId = 12,
                    WasReplaced = true,
                },
            },
        };

        var batchId = 1024;

        // Act
        var target = CreateService();
        var response = await target.GetBatchInfoAsync(batchId, CancellationToken.None);

        // Assert
        httpMessageHandler.Protected()
            .Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(x =>
                    x.RequestUri!.AbsolutePath.Equals("/feeder_gateway/get_batch_info")),
                ItExpr.IsAny<CancellationToken>());

        response.Should().BeEquivalentTo(expectedBatchInfoResponseModel);
    }

    private IPerpetualFeederGatewayClient CreateService()
    {
        return new PerpetualFeederGatewayClient(httpClientFactory.Object, settings);
    }

    private void MockHttpClient(string expectedCode = "{\"code\": \"TRANSACTION_RECEIVED\"}")
    {
        httpMessageHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK)
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
