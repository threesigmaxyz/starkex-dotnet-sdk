namespace StarkEx.Client.SDK.Tests.Clients.Spot;

using System.Net;
using FluentAssertions;
using Moq;
using Moq.Protected;
using StarkEx.Client.SDK.Clients.Spot;
using StarkEx.Client.SDK.Enums.Spot;
using StarkEx.Client.SDK.Interfaces.Spot;
using StarkEx.Client.SDK.Models.Spot.RequestModels;
using StarkEx.Client.SDK.Models.Spot.ResponseModels;
using StarkEx.Client.SDK.Models.Spot.TransactionModels;
using StarkEx.Client.SDK.Settings;
using StarkEx.Client.SDK.Tests.Mocks.Helpers;
using StarkEx.Client.SDK.Tests.Mocks.Helpers.Spot;
using StarkEx.Commons.SDK.Models;
using Xunit;

public class SpotGatewayClientTests
{
    private const string BaseAddress = "https://localhost";
    private const string Version = "v2";

    private readonly Mock<IHttpClientFactory> httpClientFactory;
    private readonly Mock<HttpMessageHandler> httpMessageHandler;
    private readonly StarkExApiSettings settings;

    public SpotGatewayClientTests()
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
    public async Task AddTransactionAsync_MintRequestModelIsValid_PostRequestIsSentWithCorrectRequestBody()
    {
        // Arrange
        MockHttpClient();
        var expectedRequestModel = SpotStarkExApiRequests.GetExpectedMintRequestModel();
        var mintRequestModel = new MintRequestModel
        {
            TransactionId = 1234,
            Transaction = new MintModel
            {
                Amount = 4029557120079369747,
                StarkKey = "0x7c65c1e82e2e662f728b4fa42485e3a0a5d2f346baa9455e3e70682c2094cac",
                TokenId = "0x400b7527a024204f7c1bd874da5e709d4713d60c8a70639eb1167b367a9c378",
                VaultId = 1654615998,
            },
        };

        var target = CreateService();

        // Act
        await target.AddTransactionAsync(mintRequestModel);

        // Assert
        AssertHttpRequestMessage(expectedRequestModel);
    }

    [Fact]
    public async Task AddTransactionAsync_SettlementRequestModelIsValid_PostRequestIsSentWithCorrectRequestBody()
    {
        // Arrange
        MockHttpClient();
        var expectedSettlementRequestModel = SpotStarkExApiRequests.GetExpectedSettlementRequestModel();
        var settlementRequestModel = new SettlementRequestModel
        {
            TransactionId = 1234,
            Transaction = new SettlementModel
            {
                PartyA = new PartyModel
                {
                    BuyAmount = 80,
                    SellAmount = 70,
                    ExpirationTimestamp = 2171951,
                    Nonce = 1654615998,
                    PublicKey = "0x4da5e70d4713d60c8a70639eb1167b367a9c3787c65c1e582e2e662f728b4fa",
                    Signature = new SignatureModel
                    {
                        R = "0x0",
                        S = "0x0",
                    },
                    TokenBuy = "0x22222222222222222222222222222222222222222222222222222222222222",
                    TokenSell = "0x11111111111111111111111111111111111111111111111111111111111111",
                    Type = SpotOrderRequestType.OrderL2Request,
                    VaultIdBuy = 173879092,
                    VaultIdSell = 1806341205,
                },
                PartyB = new PartyModel
                {
                    BuyAmount = 30,
                    SellAmount = 40,
                    EthAddress = "0xa9eb20c9A09F5eD00BE849049a554A60CCe4fC27",
                    ExpirationTimestamp = 989173,
                    FeeInfo = new FeeInfoModel
                    {
                        FeeLimit = 7,
                        SourceVaultId = 1210484339,
                        TokenId = "0x23a77118133287637ebdcd9e87a1613e443df789558867f5ba91faf7a024204",
                    },
                    Nonce = 577090037,
                    TokenBuy = "0x11111111111111111111111111111111111111111111111111111111111111",
                    TokenSell = "0x22222222222222222222222222222222222222222222222222222222222222",
                    Type = SpotOrderRequestType.OrderL1Request,
                    VaultIdBuy = 1095513148,
                    VaultIdSell = 271041745,
                },
                SettlementInfo = new SettlementInfoModel
                {
                    PartyASold = 30,
                    PartyBInfo = new FeeInfoExchangeModel
                    {
                        DestinationStarkKey = "0x7c65c1e82e2e662f728b4fa42485e3a0a5d2f346baa9455e3e70682c2094cac",
                        DestinationVaultId = 1654615998,
                        FeeTaken = 1,
                    },
                    PartyBSold = 40,
                },
            },
        };

        var target = CreateService();

        // Act
        await target.AddTransactionAsync(settlementRequestModel);

        // Assert
        AssertHttpRequestMessage(expectedSettlementRequestModel);
    }

    [Fact]
    public async Task AddTransactionAsync_TransferRequestModelIsValid_PostRequestIsSentWithCorrectRequestBody()
    {
        // Arrange
        MockHttpClient();
        var expectedTransferRequestModel = SpotStarkExApiRequests.GetExpectedTransferRequestModel();
        var transferRequestModel = new TransferRequestModel
        {
            TransactionId = 1234,
            Transaction = new TransferModel
            {
                Amount = 7106521602475165645,
                ExpirationTimestamp = 2728011,
                FeeInfoExchange = new FeeInfoExchangeModel
                {
                    DestinationStarkKey = "0x7c65c1e82e2e662f728b4fa42485e3a0a5d2f346baa9455e3e70682c2094cac",
                    DestinationVaultId = 1654615998,
                    FeeTaken = 5,
                },
                FeeInfo = new FeeInfoModel
                {
                    FeeLimit = 15,
                    SourceVaultId = 1210484339,
                    TokenId = "0x23a77118133287637ebdcd9e87a1613e443df789558867f5ba91faf7a024204",
                },
                Nonce = 1806341205,
                ReceiverPublicKey = "0x5548582de1b372ad3fbf47a7e5b1e7f9ca5499d004ae545a0116be5ab0c1681",
                ReceiverVaultId = 1047589226,
                SenderPublicKey = "0x6f25e2a5a92118719c78df48f4ff31e78de58575487ce1eaf19922ad9b8a714",
                SenderVaultId = 1358054485,
                Signature = new SignatureModel
                {
                    R = "0x0",
                    S = "0x0",
                },
                Token = "0x71545a17a1d50068d723104f77383c13458a748e9bb17bca3f2c9bf9c6316b9",
            },
        };

        var target = CreateService();

        // Act
        await target.AddTransactionAsync(transferRequestModel);

        // Assert
        AssertHttpRequestMessage(expectedTransferRequestModel);
    }

    [Fact]
    public async Task AddTransactionAsync_DepositRequestModelIsValid_PostRequestIsSentWithCorrectRequestBody()
    {
        // Arrange
        MockHttpClient();
        var expectedDepositRequestModel = SpotStarkExApiRequests.GetExpectedDepositRequestModel();
        var depositRequestModel = new DepositRequestModel
        {
            TransactionId = 1234,
            Transaction = new DepositModel
            {
                Amount = 4029557120079369747,
                StarkKey = "0x7c65c1e82e2e662f728b4fa42485e3a0a5d2f346baa9455e3e70682c2094cac",
                TokenId = "0x2dd48fd7a024204f7c1bd874da5e709d4713d60c8a70639eb1167b367a9c378",
                VaultId = 1654615998,
            },
        };

        var target = CreateService();

        // Act
        await target.AddTransactionAsync(depositRequestModel);

        // Assert
        AssertHttpRequestMessage(expectedDepositRequestModel);
    }

    [Fact]
    public async Task AddTransactionAsync_WithdrawalRequestModelIsValid_PostRequestIsSentWithCorrectRequestBody()
    {
        // Arrange
        MockHttpClient();
        var expectedWithdrawalRequestModel = SpotStarkExApiRequests.GetExpectedWithdrawalRequestModel();
        var withdrawalRequestModel = new WithdrawalRequestModel
        {
            TransactionId = 1234,
            Transaction = new WithdrawalModel
            {
                Amount = 4029557120079369747,
                StarkKey = "0x7c65c1e82e2e662f728b4fa42485e3a0a5d2f346baa9455e3e70682c2094cac",
                TokenId = "0x5ba91fa7a024204f7c1bd874da5e709d4713d60c8a70639eb1167b367a9c378",
                VaultId = 1654615998,
            },
        };

        var target = CreateService();

        // Act
        await target.AddTransactionAsync(withdrawalRequestModel);

        // Assert
        AssertHttpRequestMessage(expectedWithdrawalRequestModel);
    }

    [Fact]
    public async Task AddTransactionAsync_FullWithdrawalRequestModelIsValid_PostRequestIsSentWithCorrectRequestBody()
    {
        // Arrange
        MockHttpClient();
        var expectedFullWithdrawalRequestModel = SpotStarkExApiRequests.GetExpectedFullWithdrawalRequestModel();
        var fullWithdrawalRequestModel = new FullWithdrawalRequestModel
        {
            TransactionId = 1234,
            Transaction = new FullWithdrawalModel
            {
                StarkKey = "0x7c65c1e82e2e662f728b4fa42485e3a0a5d2f346baa9455e3e70682c2094cac",
                VaultId = 1654615998,
            },
        };

        var target = CreateService();

        // Act
        await target.AddTransactionAsync(fullWithdrawalRequestModel);

        // Assert
        AssertHttpRequestMessage(expectedFullWithdrawalRequestModel);
    }

    [Fact]
    public async Task AddTransactionAsync_FalseFullWithdrawalRequestModelIsValid_PostRequestIsSentWithCorrectRequestBody()
    {
        // Arrange
        MockHttpClient();
        var expectedFullWithdrawalRequestModel = SpotStarkExApiRequests.GetExpectedFalseFullWithdrawalRequestModel();
        var fullWithdrawalRequestModel = new FalseFullWithdrawalRequestModel
        {
            TransactionId = 1234,
            Transaction = new FalseFullWithdrawalModel
            {
                RequesterStarkKey = "0x7c65c1e82e2e662f728b4fa42485e3a0a5d2f346baa9455e3e70682c2094cac",
                VaultId = 1654615998,
            },
        };

        var target = CreateService();

        // Act
        await target.AddTransactionAsync(fullWithdrawalRequestModel);

        // Assert
        AssertHttpRequestMessage(expectedFullWithdrawalRequestModel);
    }

    [Fact]
    public async Task AddTransactionAsync_MultiTransactionRequestModelIsValid_PostRequestIsSentWithCorrectRequestBody()
    {
        // Arrange
        MockHttpClient();
        var expectedMultiTransactionRequestModel = SpotStarkExApiRequests.GetExpectedMultiTransactionRequestModel();
        var multiTransactionRequestModel = new MultiTransactionRequestModel
        {
            TransactionId = 1234,
            Transaction = new MultiTransactionModel
            {
                Transactions = new List<TransactionModel>
                {
                    new DepositModel
                    {
                        VaultId = 1654615998,
                        TokenId = "0x2dd48fd7a024204f7c1bd874da5e709d4713d60c8a70639eb1167b367a9c378",
                        StarkKey = "0x7c65c1e82e2e662f728b4fa42485e3a0a5d2f346baa9455e3e70682c2094cac",
                        Amount = 4029557120079369747,
                    },
                    new WithdrawalModel
                    {
                        VaultId = 1654615998,
                        TokenId = "0x5ba91fa7a024204f7c1bd874da5e709d4713d60c8a70639eb1167b367a9c378",
                        StarkKey = "0x7c65c1e82e2e662f728b4fa42485e3a0a5d2f346baa9455e3e70682c2094cac",
                        Amount = 4029557120079369747,
                    },
                },
            },
        };

        var target = CreateService();

        // Act
        await target.AddTransactionAsync(multiTransactionRequestModel);

        // Assert
        AssertHttpRequestMessage(expectedMultiTransactionRequestModel);
    }

    [Fact]
    public async Task AnyRequest_RequestModelIsNull_ExceptionIsThrown()
    {
        // Arrange
        var target = CreateService();

        // Act
        var action = async () => await target.AddTransactionAsync((MintRequestModel)null!);

        // Assert
        await action
            .Should().ThrowExactlyAsync<ArgumentNullException>()
            .WithParameterName("requestModel");
    }

    [Theory]
    [MemberData(nameof(Data))]
    public async Task AnyRequest_RequestModelIsValid_ResponseIsCorrectlyParsed(
        string responseMock,
        SpotApiCodes expectedApiCode)
    {
        // Arrange
        MockHttpClient(responseMock);
        var expectedResponseModel = new ResponseModel
        {
            Code = expectedApiCode,
        };
        var mintRequestModel = new MintRequestModel();
        var target = CreateService();

        // Act
        var responseModel = await target.AddTransactionAsync(mintRequestModel);

        // Assert
        responseModel.Should().BeEquivalentTo(expectedResponseModel);
    }

    private static IEnumerable<object[]> Data()
    {
        yield return new object[] { "{\"code\": \"API_FUNCTION_TEMPORARILY_DISABLED\"}", SpotApiCodes.ApiFunctionTemporarilyDisabled };
        yield return new object[] { "{\"code\": \"BATCH_CREATION_FAILURE\"}", SpotApiCodes.BatchCreationFailure };
        yield return new object[] { "{\"code\": \"BATCH_FULL\"}", SpotApiCodes.BatchFull };
        yield return new object[] { "{\"code\": \"BATCH_NOT_READY\"}", SpotApiCodes.BatchNotReady };
        yield return new object[] { "{\"code\": \"CONFLICTING_ORDER_AMOUNTS\"}", SpotApiCodes.ConflictingOrderAmounts };
        yield return new object[] { "{\"code\": \"CONNECTION_ERROR\"}", SpotApiCodes.ConnectionError };
        yield return new object[] { "{\"code\": \"FACT_NOT_REGISTERED\"}", SpotApiCodes.FactNotRegistered };
        yield return new object[] { "{\"code\": \"INSUFFICIENT_ON_CHAIN_BALANCE\"}", SpotApiCodes.InsufficientOnChainBalance };
        yield return new object[] { "{\"code\": \"INVALID_BATCH_ID\"}", SpotApiCodes.InvalidBatchId };
        yield return new object[] { "{\"code\": \"INVALID_CLAIM_HASH\"}", SpotApiCodes.InvalidClaimHash };
        yield return new object[] { "{\"code\": \"INVALID_COMMITTEE_MEMBER\"}", SpotApiCodes.InvalidCommitteeMember };
        yield return new object[] { "{\"code\": \"INVALID_CONTRACT_ADDRESS\"}", SpotApiCodes.InvalidContractAddress };
        yield return new object[] { "{\"code\": \"INVALID_DEPLOYMENT_INFO\"}", SpotApiCodes.InvalidDeploymentInfo };
        yield return new object[] { "{\"code\": \"INVALID_ETH_ADDRESS\"}", SpotApiCodes.InvalidEthAddress };
        yield return new object[] { "{\"code\": \"INVALID_FACT\"}", SpotApiCodes.InvalidFact };
        yield return new object[] { "{\"code\": \"INVALID_FEE_TAKEN\"}", SpotApiCodes.InvalidFeeTaken };
        yield return new object[] { "{\"code\": \"INVALID_ORDER_ID\"}", SpotApiCodes.InvalidOrderId };
        yield return new object[] { "{\"code\": \"INVALID_ORDER_TYPE\"}", SpotApiCodes.InvalidOrderType };
        yield return new object[] { "{\"code\": \"INVALID_REQUEST\"}", SpotApiCodes.InvalidRequest };
        yield return new object[] { "{\"code\": \"INVALID_REQUEST_PARAMETERS\"}", SpotApiCodes.InvalidRequestParameters };
        yield return new object[] { "{\"code\": \"INVALID_SETTLEMENT_INFO\"}", SpotApiCodes.InvalidSettlementInfo };
        yield return new object[] { "{\"code\": \"INVALID_SETTLEMENT_RATIO\"}", SpotApiCodes.InvalidSettlementRatio };
        yield return new object[] { "{\"code\": \"INVALID_SETTLEMENT_TOKENS\"}", SpotApiCodes.InvalidSettlementTokens };
        yield return new object[] { "{\"code\": \"INVALID_SIGNATURE\"}", SpotApiCodes.InvalidSignature };
        yield return new object[] { "{\"code\": \"INVALID_TOKEN_TYPE\"}", SpotApiCodes.InvalidTokenType };
        yield return new object[] { "{\"code\": \"INVALID_TRANSACTION\"}", SpotApiCodes.InvalidTransaction };
        yield return new object[] { "{\"code\": \"INVALID_TRANSACTION_ID\"}", SpotApiCodes.InvalidTransactionId };
        yield return new object[] { "{\"code\": \"INVALID_VAULT\"}", SpotApiCodes.InvalidVault };
        yield return new object[] { "{\"code\": \"MALFORMED_REQUEST\"}", SpotApiCodes.MalformedRequest };
        yield return new object[] { "{\"code\": \"MIGRATED_PIPELINE_OBJECT_MISSING\"}", SpotApiCodes.MigratedPipelineObjectMissing };
        yield return new object[] { "{\"code\": \"MISSING_BLOCKCHAIN_ID\"}", SpotApiCodes.MissingBlockchainId };
        yield return new object[] { "{\"code\": \"MISSING_FEE_OBJECT\"}", SpotApiCodes.MissingFeeObject };
        yield return new object[] { "{\"code\": \"ORDER_OVERDUE\"}", SpotApiCodes.OrderOverdue };
        yield return new object[] { "{\"code\": \"OUT_OF_RANGE_AMOUNT\"}", SpotApiCodes.OutOfRangeAmount };
        yield return new object[] { "{\"code\": \"OUT_OF_RANGE_BALANCE\"}", SpotApiCodes.OutOfRangeBalance };
        yield return new object[] { "{\"code\": \"OUT_OF_RANGE_BATCH_ID\"}", SpotApiCodes.OutOfRangeBatchId };
        yield return new object[] { "{\"code\": \"OUT_OF_RANGE_EXPIRATION_TIMESTAMP\"}", SpotApiCodes.OutOfRangeExpirationTimestamp };
        yield return new object[] { "{\"code\": \"OUT_OF_RANGE_NONCE\"}", SpotApiCodes.OutOfRangeNonce };
        yield return new object[] { "{\"code\": \"OUT_OF_RANGE_ORACLE_PRICE_QUORUM\"}", SpotApiCodes.OutOfRangeOraclePriceQuorum };
        yield return new object[] { "{\"code\": \"OUT_OF_RANGE_ORDER_ID\"}", SpotApiCodes.OutOfRangeOrderId };
        yield return new object[] { "{\"code\": \"OUT_OF_RANGE_POSITIVE_AMOUNT\"}", SpotApiCodes.OutOfRangePositiveAmount };
        yield return new object[] { "{\"code\": \"OUT_OF_RANGE_PUBLIC_KEY\"}", SpotApiCodes.OutOfRangePublicKey };
        yield return new object[] { "{\"code\": \"OUT_OF_RANGE_SIGNATURE_SUBFIELD\"}", SpotApiCodes.OutOfRangeSignatureSubfield };
        yield return new object[] { "{\"code\": \"OUT_OF_RANGE_TOKEN_ID\"}", SpotApiCodes.OutOfRangeTokenId };
        yield return new object[] { "{\"code\": \"OUT_OF_RANGE_VAULT_ID\"}", SpotApiCodes.OutOfRangeVaultId };
        yield return new object[] { "{\"code\": \"REPLACED_BEFORE\"}", SpotApiCodes.ReplacedBefore };
        yield return new object[] { "{\"code\": \"REQUEST_FAILED\"}", SpotApiCodes.RequestFailed };
        yield return new object[] { "{\"code\": \"SCHEMA_VALIDATION_ERROR\"}", SpotApiCodes.SchemaValidationError };
        yield return new object[] { "{\"code\": \"TRANSACTION_PENDING\"}", SpotApiCodes.TransactionPending };
    }

    private ISpotGatewayClient CreateService()
    {
        return new SpotGatewayClient(httpClientFactory.Object, settings);
    }

    private void MockHttpClient(string expectedCode = "{\"code\": \"TRANSACTION_PENDING\"}")
    {
        httpMessageHandler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
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

    private void AssertHttpRequestMessage(string expectedRequestModel)
    {
        httpMessageHandler.Protected()
            .Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(x =>
                    x.RequestUri!.AbsolutePath.Equals($"/{settings.Version}/gateway/add_transaction") &&
                    x.Content!.ReadAsStringAsync().Result.RemoveNewLineCharsAndSpacesAndTrim().Equals(expectedRequestModel.RemoveNewLineCharsAndSpacesAndTrim())),
                ItExpr.IsAny<CancellationToken>());
    }
}