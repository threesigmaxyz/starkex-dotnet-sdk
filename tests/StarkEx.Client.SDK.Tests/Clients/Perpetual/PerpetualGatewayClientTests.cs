namespace StarkEx.Client.SDK.Tests.Clients.Perpetual;

using System.Net;
using System.Numerics;
using FluentAssertions;
using Moq;
using Moq.Protected;
using StarkEx.Client.SDK.Clients.Perpetual;
using StarkEx.Client.SDK.Enums.Perpetual;
using StarkEx.Client.SDK.Interfaces.Perpetual;
using StarkEx.Client.SDK.Models.Perpetual.RequestModels;
using StarkEx.Client.SDK.Models.Perpetual.ResponseModels;
using StarkEx.Client.SDK.Models.Perpetual.TransactionModels;
using StarkEx.Client.SDK.Settings;
using StarkEx.Client.SDK.Tests.Mocks.Helpers;
using StarkEx.Client.SDK.Tests.Mocks.Helpers.Perpetual;
using StarkEx.Commons.SDK.Models;
using Xunit;

public class PerpetualGatewayClientTests
{
    private const string BaseAddress = "https://localhost";
    private const string Version = "v2";

    private readonly Mock<IHttpClientFactory> httpClientFactory;
    private readonly Mock<HttpMessageHandler> httpMessageHandler;
    private readonly StarkExApiSettings settings;

    public PerpetualGatewayClientTests()
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
        MockHttpClient("10");
        var expectedResponse = 10;

        // Act
        var target = CreateService();

        // Act
        var response = await target.GetFirstUnusedTxAsync();

        // Assert
        httpMessageHandler.Protected()
            .Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(x =>
                    x.RequestUri!.AbsolutePath.Equals("/get_first_unused_tx_id")),
                ItExpr.IsAny<CancellationToken>());
        response.Should().Be(expectedResponse);
    }

    [Fact]
    public async Task
        AddTransactionAsync_ConditionalTransferRequestModelIsValid_PostRequestIsSentWithCorrectRequestBody()
    {
        // Arrange
        MockHttpClient();
        var expectedRequestModel = PerpetualStarkExApiRequests.GetExpectedConditionalTransferRequestModel();

        var conditionalTransferRequestModel = new ConditionalTransferRequestModel
        {
            TransactionId = 1234,
            Transaction = new ConditionalTransferModel
            {
                Amount = 7758176404715800194,
                AssetId = "0x57d05d11b570fd197b55746070ee051c731ee109b07255eab3c9cf8b6c579d",
                ExpirationTimestamp = 2404381470,
                Fact = "6461646162616461626164616461626164616261646164616261646162616461",
                FactRegistryAddress = "0x599f9eC17474c2E25C9859ee34A6A02fE9738083",
                Nonce = 2195908194,
                ReceiverPositionId = 6091063652223914538,
                ReceiverPublicKey = "0x259f432e6f4590b9a164106cf6a659eb4862b21fb97d43588561712e8e5216b",
                SenderPositionId = 9309829342914403545,
                SenderPublicKey = "0x243343249edf36010f231a63f3e102c5510f6dfcb270990e15a6317c747e65",
                Signature = new SignatureModel
                {
                    R = "0x8a46893fa614eba8f681843c484abe055e03462235810d3514c2266a033a89",
                    S = "0x6350cf237ca1df18700ccb72ebd74759c7249c32c92e578d684455a631e9a3e",
                },
            },
        };

        var target = CreateService();

        // Act
        await target.AddTransactionAsync(conditionalTransferRequestModel);

        // Assert
        AssertHttpRequestMessage(expectedRequestModel);
    }

    [Fact]
    public async Task AddTransactionAsync_DeleverageRequestModelIsValid_PostRequestIsSentWithCorrectRequestBody()
    {
        // Arrange
        MockHttpClient();
        var expectedRequestModel = PerpetualStarkExApiRequests.GetExpectedDeleverageRequestModel();
        var deleverageRequestModel = new DeleverageRequestModel
        {
            TransactionId = 1234,
            Transaction = new DeleverageModel
            {
                AmountCollateral = 5721212930748269353,
                AmountSynthetic = 9309829342914403545,
                DeleveragedPositionId = 7758176404715800194,
                DeleveragerIsBuyingSynthetic = false,
                DeleveragerPositionId = 15308084094301570617,
                SyntheticAssetId = "0x1",
            },
        };

        var target = CreateService();

        // Act
        await target.AddTransactionAsync(deleverageRequestModel);

        // Assert
        AssertHttpRequestMessage(expectedRequestModel);
    }

    [Fact]
    public async Task AddTransactionAsync_DepositRequestModelIsValid_PostRequestIsSentWithCorrectRequestBody()
    {
        // Arrange
        MockHttpClient();
        var expectedRequestModel = PerpetualStarkExApiRequests.GetExpectedDepositRequestModel();
        var depositRequestModel = new DepositRequestModel
        {
            TransactionId = 1234,
            Transaction = new DepositModel
            {
                Amount = 2569146471088859254,
                PositionId = 7758176404715800194,
                PublicKey = "0x37ebdcde87a1613e443df789558867f5ba91faf7a024204f7c1bd874da5e70a",
            },
        };

        var target = CreateService();

        // Act
        await target.AddTransactionAsync(depositRequestModel);

        // Assert
        AssertHttpRequestMessage(expectedRequestModel);
    }

    [Fact]
    public async Task AddTransactionAsync_ForcedTradeRequestModelIsValid_PostRequestIsSentWithCorrectRequestBody()
    {
        // Arrange
        MockHttpClient();
        var expectedRequestModel = PerpetualStarkExApiRequests.GetExpectedForcedTradeRequestModel();
        var forcedTradeRequestModel = new ForcedTradeRequestModel
        {
            TransactionId = 1234,
            Transaction = new ForcedTradeModel
            {
                AmountCollateral = 7838377020387924882,
                AmountSynthetic = 11113581968013062307,
                CollateralAssetId = "0x57d05d11b570fd197b55746070ee051c731ee109b07255eab3c9cf8b6c579d",
                IsPartyABuyingSynthetic = false,
                IsValid = false,
                Nonce = 1284389859,
                PositionIdPartyA = 9276979549170356654,
                PositionIdPartyB = 18112525187809919137,
                PublicKeyPartyA = "0x3db6c6e82fab496fa87fbeed99848903a92a7ba339dbcda84663f3baa2a666a",
                PublicKeyPartyB = "0x7ad4c47197cceaf20de795ef88c7b1b7e5f27191fcda85c69c512e3326f23d7",
                SyntheticAssetId = "0x1",
            },
        };

        var target = CreateService();

        // Act
        await target.AddTransactionAsync(forcedTradeRequestModel);

        // Assert
        AssertHttpRequestMessage(expectedRequestModel);
    }

    [Fact]
    public async Task AddTransactionAsync_ForcedWithdrawalRequestModelIsValid_PostRequestIsSentWithCorrectRequestBody()
    {
        // Arrange
        MockHttpClient();
        var expectedRequestModel = PerpetualStarkExApiRequests.GetExpectedForcedWithdrawalRequestModel();
        var forcedWithdrawalRequestModel = new ForcedWithdrawalRequestModel
        {
            Transaction = new ForcedWithdrawalModel
            {
                Amount = 653212427667887001,
                IsValid = false,
                PositionId = 12811351868539174612,
                PublicKey = "0x758e9e1803bd82196a71da4b085725b195de5d9c50908e3a6399351982ced6",
            },
            TransactionId = 1234,
        };

        var target = CreateService();

        // Act
        await target.AddTransactionAsync(forcedWithdrawalRequestModel);

        // Assert
        AssertHttpRequestMessage(expectedRequestModel);
    }

    [Fact]
    public async Task AddTransactionAsync_FundingTickRequestModelIsValid_PostRequestIsSentWithCorrectRequestBody()
    {
        // Arrange
        MockHttpClient();
        var expectedRequestModel = PerpetualStarkExApiRequests.GetExpectedFundingTickRequestModel();
        var fundingTickRequestModel = new FundingTickRequestModel
        {
            TransactionId = 1234,
            Transaction = new FundingTickModel
            {
                GlobalFundingIndices = new FundingIndicesStateModel
                {
                    Indices = new Dictionary<string, BigInteger>
                    {
                        { "0x0", -431710025170174585 },
                        { "0x1", 6084712057446794809 },
                    },
                    Timestamp = 3900315155,
                },
            },
        };

        var target = CreateService();

        // Act
        await target.AddTransactionAsync(fundingTickRequestModel);

        // Assert
        AssertHttpRequestMessage(expectedRequestModel);
    }

    [Fact]
    public async Task AddTransactionAsync_LiquidateRequestModelIsValid_PostRequestIsSentWithCorrectRequestBody()
    {
        // Arrange
        MockHttpClient();
        var expectedRequestModel = PerpetualStarkExApiRequests.GetExpectedLiquidateRequestModel();
        var liquidateRequestModel = new LiquidateRequestModel
        {
            TransactionId = 1234,
            Transaction = new LiquidateModel
            {
                ActualCollateral = 7758176404715800194,
                ActualLiquidatorFee = 8791662011684601223,
                ActualSynthetic = 15308084094301570617,
                LiquidatedPositionId = 15419682365516802845,
                LiquidatorOrder = new OrderModel
                {
                    AmountCollateral = 8187132600743567510, // TODO BigInteger is not big enough to hold value from docs
                    AmountFee = 11081939229867047606,
                    AmountSynthetic = 16558026091473266411,
                    AssetIdCollateral = "0x57d05d11b570fd197b55746070ee051c731ee109b07255eab3c9cf8b6c579d",
                    AssetIdSynthetic = "0x2",
                    ExpirationTimestamp = 1430804514,
                    IsBuyingSynthetic = false,
                    Nonce = 3900315155,
                    OrderType = PerpetualOrderRequestType.LIMIT_ORDER_WITH_FEES,
                    PositionId = 11534118754833929857,
                    PublicKey = "0x5db665983e23607de57d6dc068797336bfdcb954238044688bec922ca296d3e",
                    Signature = new SignatureModel
                    {
                        R = "0x4ac8a77f5863238a8bfb8a2e7f2dcc70cb8cad7b45692497b4b2c3ff06f6c94",
                        S = "0x6fd86c349a6c6266d34c11da0ff8c0cf211cafbadc39ba4a4c38124344f3bb1",
                    },
                },
            },
        };

        var target = CreateService();

        // Act
        await target.AddTransactionAsync(liquidateRequestModel);

        // Assert
        AssertHttpRequestMessage(expectedRequestModel);
    }

    [Fact]
    public async Task AddTransactionAsync_MultiTransactionRequestModelIsValid_PostRequestIsSentWithCorrectRequestBody()
    {
        // Arrange
        MockHttpClient();
        var expectedRequestModel = PerpetualStarkExApiRequests.GetExpectedMultiTransactionRequestModel();
        var multiTransactionRequestModel = new MultiTransactionRequestModel
        {
            TransactionId = 1234,
            Transaction = new MultiTransactionModel
            {
                Transactions = new List<TransactionModel>
                {
                    new DepositModel
                    {
                        Amount = 2569146471088859254,
                        PositionId = 7758176404715800194,
                        PublicKey = "0x37ebdcde87a1613e443df789558867f5ba91faf7a024204f7c1bd874da5e70a",
                    },
                    new TransferModel
                    {
                        Amount = 13942126818862981423,
                        AssetId = "0x57d05d11b570fd197b55746070ee051c731ee109b07255eab3c9cf8b6c579d",
                        ExpirationTimestamp = 2628077981,
                        Nonce = 3874773259,
                        ReceiverPositionId = 11534118754833929857,
                        ReceiverPublicKey = "0x66194cbd71037d1b83e90ec17e0aa3c03983ca8ea7e9d498c778ea6eb2083e7",
                        SenderPositionId = 10326739782786242647,
                        SenderPublicKey = "0x6306fae7e23046b2fc9763011b703ae8dae5099180c96125bddd421d30b048a",
                        Signature = new SignatureModel
                        {
                            R = "0x399bbab600b27b983c7807c32caadf38bb897f412055d9989c63661416d56e4",
                            S = "0x73bae1a10349372ca04487d2271f3e3c0733c327b4114238de8cf0c5ded3b1b",
                        },
                    },
                },
            },
        };

        var target = CreateService();

        // Act
        await target.AddTransactionAsync(multiTransactionRequestModel);

        // Assert
        AssertHttpRequestMessage(expectedRequestModel);
    }

    [Fact]
    public async Task AddTransactionAsync_OraclePricesTickRequestModelIsValid_PostRequestIsSentWithCorrectRequestBody()
    {
        // Arrange
        MockHttpClient();
        var expectedRequestModel = PerpetualStarkExApiRequests.GetExpectedOraclePricesTickRequestModel();
        var oraclePricesTickRequestModel = new OraclePricesTickRequestModel
        {
            TransactionId = 1234,
            Transaction = new OraclePricesTickModel
            {
                OraclePrices = new Dictionary<string, AssetOraclePriceModel>
                {
                    {
                        "0x0", new AssetOraclePriceModel
                        {
                            Price = 4345629098988793194,
                            SignedPrices = new Dictionary<string, SignedOraclePrice>
                            {
                                {
                                    "0x2ae10445c08f66270cd8d3a71cdac5630a541b1f7d13e47ec1d0373ce3e8fd3",
                                    new SignedOraclePrice
                                    {
                                        ExternalAssetId = "0x425443555344000000000000000000004d616b6572",
                                        Price = BigInteger.Parse("10117956201985462554675959028152"),
                                        TimestampedSignature = new TimestampedSignatureModel
                                        {
                                            Signature = new SignatureModel
                                            {
                                                R = "0x6f301f84b4622bcd472a0f375469ce1118d0ce45cb8f9f089ce403981ce5154",
                                                S = "0xd17a6912b8dd4110ff9f643422448f3a9e725a07be3108aeeccf4a9e9dbdd0",
                                            },
                                            Timestamp = 3618339112,
                                        },
                                    }
                                },
                            },
                        }
                    },
                    {
                        "0x1", new AssetOraclePriceModel
                        {
                            Price = 14829673561266596382,
                            SignedPrices = new Dictionary<string, SignedOraclePrice>
                            {
                                {
                                    "0x35007be34c2c3d47d2216cb3e13f61d65f4c3c76bb4c57bf1afbe7388bc3238",
                                    new SignedOraclePrice
                                    {
                                        ExternalAssetId = "0x455448555344000000000000000000004d616b6572",
                                        Price = BigInteger.Parse("216314955048675504460053108771"),
                                        TimestampedSignature = new TimestampedSignatureModel
                                        {
                                            Signature = new SignatureModel
                                            {
                                                R = "0x7272c78aab3a1d59cde4cec98630ea164ba79a7efd07dd987f0c4eb3b32d6e3",
                                                S = "0x6b86d1c1d08bb9b3bb9dde346bf76a1bf5b4c8a13cf875ba194080756312932",
                                            },
                                            Timestamp = 4265854110,
                                        },
                                    }
                                },
                                {
                                    "0x4722c15415ba4ab0a1b3a516be64b94846e9257d25e619c6014f8af08acf90c",
                                    new SignedOraclePrice
                                    {
                                        ExternalAssetId = "0x455448555344000000000000000000004d616b6572",
                                        Price = BigInteger.Parse("345280244044647467828513979784"),
                                        TimestampedSignature = new TimestampedSignatureModel
                                        {
                                            Signature = new SignatureModel
                                            {
                                                R = "0x7912daf400f5d87299b2f9f7593f99015835b62cd15efe74f2a31a590c59773",
                                                S = "0x57eed714363fc4cae375a0adb938651d5e450fc6efaf61ce73ec64f578f0566",
                                            },
                                            Timestamp = 2685496293,
                                        },
                                    }
                                },
                            },
                        }
                    },
                },
                Timestamp = 3485918757,
            },
        };

        var target = CreateService();

        // Act
        await target.AddTransactionAsync(oraclePricesTickRequestModel);

        // Assert
        AssertHttpRequestMessage(expectedRequestModel);
    }

    [Fact]
    public async Task AddTransactionAsync_TradeRequestModelIsValid_PostRequestIsSentWithCorrectRequestBody()
    {
        // Arrange
        MockHttpClient();
        var expectedRequestModel = PerpetualStarkExApiRequests.GetExpectedTradeRequestModel();
        var tradeRequestModel = new TradeRequestModel
        {
            TransactionId = 1234,
            Transaction = new TradeModel
            {
                ActualAFee = 8791662011684601223,
                ActualBFee = 9309829342914403545,
                ActualCollateral = 7758176404715800194,
                ActualSynthetic = 15308084094301570617,
                PartyAOrder = new OrderModel
                {
                    AmountCollateral = 15334874138764573096,
                    AmountFee = 17677494534592486883,
                    AmountSynthetic = 15460142528840632302,
                    AssetIdCollateral = "0x57d05d11b570fd197b55746070ee051c731ee109b07255eab3c9cf8b6c579d",
                    AssetIdSynthetic = "0x2",
                    ExpirationTimestamp = 3608164305,
                    IsBuyingSynthetic = true,
                    Nonce = 1210484339,
                    OrderType = PerpetualOrderRequestType.LIMIT_ORDER_WITH_FEES,
                    PositionId = 4805234989534244506,
                    PublicKey = "0x6b974202431eb8c0692c9c8111528d947bc7e70f7ffefaffbab7455dfa5d4f7",
                    Signature = new SignatureModel
                    {
                        R = "0x54730fcf60f37072926ba182d17e55e21104fbc22886d876a7e8b191b2d456f",
                        S = "0x1f32f41a809b2f2b888bddc2bdbf5ef709403a00d4e5e23dbaef09e55130464",
                    },
                },
                PartyBOrder = new OrderModel
                {
                    AmountCollateral = 7800133567066683830,
                    AmountFee = 10547508580746848044,
                    AmountSynthetic = 17015053283814123498,
                    AssetIdCollateral = "0x57d05d11b570fd197b55746070ee051c731ee109b07255eab3c9cf8b6c579d",
                    AssetIdSynthetic = "0x2",
                    ExpirationTimestamp = 3407305306,
                    IsBuyingSynthetic = false,
                    Nonce = 2046685052,
                    OrderType = PerpetualOrderRequestType.LIMIT_ORDER_WITH_FEES,
                    PositionId = 5076743434755564658,
                    PublicKey = "0x7784139b0eee3f6fd937bba714acc2b199af2877565ba7c926d3f10d0bca378",
                    Signature = new SignatureModel
                    {
                        R = "0x929a5a30bb98b23d0fcfcc75a1ff5f0f5a437edac75002cb6ebca78173ffd3",
                        S = "0x2abbf077eb504ae44b2cf1ca81c1aa73489a38aead87600a7dadf82bd39efcc",
                    },
                },
            },
        };

        var target = CreateService();

        // Act
        await target.AddTransactionAsync(tradeRequestModel);

        // Assert
        AssertHttpRequestMessage(expectedRequestModel);
    }

    [Fact]
    public async Task AddTransactionAsync_TransferRequestModelIsValid_PostRequestIsSentWithCorrectRequestBody()
    {
        // Arrange
        MockHttpClient();
        var expectedRequestModel = PerpetualStarkExApiRequests.GetExpectedTransferRequestModel();
        var transferRequestModel = new TransferRequestModel
        {
            TransactionId = 1234,
            Transaction = new TransferModel
            {
                Amount = 7758176404715800194,
                AssetId = "0x57d05d11b570fd197b55746070ee051c731ee109b07255eab3c9cf8b6c579d",
                ExpirationTimestamp = 2404381470,
                Nonce = 2195908194,
                ReceiverPositionId = 6091063652223914538,
                ReceiverPublicKey = "0x259f432e6f4590b9a164106cf6a659eb4862b21fb97d43588561712e8e5216b",
                SenderPositionId = 9309829342914403545,
                SenderPublicKey = "0x463ef5fbed3a0b89e1fd1d630544c4cb2a358e93f5305c5d04ea919810633c7",
                Signature = new SignatureModel
                {
                    R = "0x9ae426da12f9084cabb23793249439b1580e2fa794130b99a35d051af4e3e6",
                    S = "0x1aab922485eb0df5ef6856d0fcbdadad0acea652b5a0ec24bcabb5385ddc0a3",
                },
            },
        };

        var target = CreateService();

        // Act
        await target.AddTransactionAsync(transferRequestModel);

        // Assert
        AssertHttpRequestMessage(expectedRequestModel);
    }

    [Fact]
    public async Task AddTransactionAsync_WithdrawalRequestModelIsValid_PostRequestIsSentWithCorrectRequestBody()
    {
        // Arrange
        MockHttpClient();
        var expectedRequestModel = PerpetualStarkExApiRequests.GetExpectedWithdrawalRequestModel();
        var withdrawalRequestModel = new WithdrawalRequestModel
        {
            TransactionId = 1234,
            Transaction = new WithdrawalModel
            {
                Amount = 2569146471088859254,
                ExpirationTimestamp = 631194409,
                Nonce = 3433407905,
                PositionId = 7758176404715800194,
                PublicKey = "0x35989d400b783796677a03aec2a321cd7e0f8e85d9e62f595209ca9b17beefc",
                Signature = new SignatureModel
                {
                    R = "0x4b3b9e4934d635f6d1d015212cf773217abd65a32a804f0bd5c6cf3eab926f4",
                    S = "0x377ea02a33203f8f497ff1290e9b59c1e586134e41c3287b262f9c6e02e66c2",
                },
            },
        };

        var target = CreateService();

        // Act
        await target.AddTransactionAsync(withdrawalRequestModel);

        // Assert
        AssertHttpRequestMessage(expectedRequestModel);
    }

    [Fact]
    public async Task
        AddTransactionAsync_WithdrawalToAddressRequestModelIsValid_PostRequestIsSentWithCorrectRequestBody()
    {
        // Arrange
        MockHttpClient();
        var expectedRequestModel = PerpetualStarkExApiRequests.GetExpectedWithdrawalToAddressRequestModel();
        var withdrawalToAddressRequestModel = new WithdrawalToAddressRequestModel
        {
            TransactionId = 1234,
            Transaction = new WithdrawalToAddressModel
            {
                Amount = 1682637359498011204,
                EthAddress = "0xB6aD5EfBd6aDfa29dEfad5BC0f8cE0ad57d4c5Fb",
                ExpirationTimestamp = 2101470722,
                Nonce = 4265854110,
                PositionId = 7758176404715800194,
                PublicKey = "0x1b9e4c42a399f6ce069127df5ad618489aad21b1687acf4d4b09e08744084a7",
                Signature = new SignatureModel
                {
                    R = "0x18326a6181a507f701968f45f56799b890374a1e329c6b9a37ec3292d92b1f8",
                    S = "0x66dd6745be06d033149a2bcb686e3ec896fc914ff2cb52dcc1d34bbe220b639",
                },
            },
        };

        var target = CreateService();

        // Act
        await target.AddTransactionAsync(withdrawalToAddressRequestModel);

        // Assert
        AssertHttpRequestMessage(expectedRequestModel);
    }

    [Theory]
    [MemberData(nameof(Data))]
    public async Task AnyRequest_RequestModelIsValid_ResponseIsCorrectlyParsed(
        string responseMock,
        PerpetualApiCodes expectedApiCode)
    {
        // Arrange
        MockHttpClient(responseMock);
        var expectedResponseModel = new TransactionResponseModel
        {
            Code = expectedApiCode,
            TxId = new BigInteger(0),
        };
        var conditionalTransferRequestModel = new ConditionalTransferRequestModel();

        var target = CreateService();

        // Act
        var responseModel = await target.AddTransactionAsync(conditionalTransferRequestModel);

        // Assert
        responseModel.Should().BeEquivalentTo(expectedResponseModel);
    }

    private static IEnumerable<object[]> Data()
    {
        yield return new object[] { "{\"code\": \"ILLEGAL_POSITION_TRANSITION_ENLARGING_SYNTHETIC_HOLDINGS\"}", PerpetualApiCodes.IllegalPositionTransitionEnlargingSyntheticHoldings };
        yield return new object[] { "{\"code\": \"ILLEGAL_POSITION_TRANSITION_REDUCING_TOTAL_VALUE_RISK_RATIO\"}", PerpetualApiCodes.IllegalPositionTransitionReducingTotalValueRiskRatio };
        yield return new object[] { "{\"code\": \"ILLEGAL_POSITION_TRANSITION_NO_RISK_REDUCED_VALUE\"}", PerpetualApiCodes.IllegalPositionTransitionNoRiskReducedValue };
        yield return new object[] { "{\"code\": \"INVALID_ASSET_ORACLE_PRICE\"}", PerpetualApiCodes.InvalidAssetOraclePrice };
        yield return new object[] { "{\"code\": \"INVALID_COLLATERAL_ASSET_ID\"}", PerpetualApiCodes.InvalidCollateralAssetId };
        yield return new object[] { "{\"code\": \"INVALID_FEE_POSITION_PARTICIPATION\"}", PerpetualApiCodes.InvalidFeePositionParticipation };
        yield return new object[] { "{\"code\": \"INVALID_FORCED_TRANSACTION\"}", PerpetualApiCodes.InvalidForcedTransaction };
        yield return new object[] { "{\"code\": \"INVALID_FULFILLMENT_ASSETS_RATIO\"}", PerpetualApiCodes.InvalidFulfillmentAssetsRatio };
        yield return new object[] { "{\"code\": \"INVALID_FULFILLMENT_FEE_RATIO\"}", PerpetualApiCodes.InvalidFulfillmentFeeRatio };
        yield return new object[] { "{\"code\": \"INVALID_FULFILLMENT_INFO\"}", PerpetualApiCodes.InvalidFulfillmentInfo };
        yield return new object[] { "{\"code\": \"INVALID_FUNDING_TICK_RATE\"}", PerpetualApiCodes.InvalidFundingTickRate };
        yield return new object[] { "{\"code\": \"INVALID_FUNDING_TICK_TIMESTAMP\"}", PerpetualApiCodes.InvalidFundingTickTimestamp };
        yield return new object[] { "{\"code\": \"INVALID_LIQUIDATE\"}", PerpetualApiCodes.InvalidLiquidate };
        yield return new object[] { "{\"code\": \"INVALID_ORDER_ASSETS\"}", PerpetualApiCodes.InvalidOrderAssets };
        yield return new object[] { "{\"code\": \"INVALID_ORDER_IS_BUYING_PROPERTY\"}", PerpetualApiCodes.InvalidOrderIsBuyingProperty };
        yield return new object[] { "{\"code\": \"INVALID_PUBLIC_KEY\"}", PerpetualApiCodes.InvalidPublicKey };
        yield return new object[] { "{\"code\": \"INVALID_SYNTHETIC_ASSET_ID\"}", PerpetualApiCodes.InvalidSyntheticAssetId };
        yield return new object[] { "{\"code\": \"INVALID_TICK_TIMESTAMP_DISTANCE_FROM_BLOCKCHAIN_TIME\"}", PerpetualApiCodes.InvalidTickTimestampDistanceFromBlockchainTime };
        yield return new object[] { "{\"code\": \"MISSING_GLOBAL_FUNDING_INDEX\"}", PerpetualApiCodes.MissingGlobalFundingIndex };
        yield return new object[] { "{\"code\": \"MISSING_ORACLE_PRICE\"}", PerpetualApiCodes.MissingOraclePrice };
        yield return new object[] { "{\"code\": \"MISSING_ORACLE_PRICE_SIGNED_IN_TIME_RANGE\"}", PerpetualApiCodes.MissingOraclePriceSignedInTimeRange };
        yield return new object[] { "{\"code\": \"MISSING_SIGNED_ORACLE_PRICE\"}", PerpetualApiCodes.MissingSignedOraclePrice };
        yield return new object[] { "{\"code\": \"MISSING_SYNTHETIC_ASSET_ID\"}", PerpetualApiCodes.MissingSyntheticAssetId };
        yield return new object[] { "{\"code\": \"OUT_OF_RANGE_ASSET_ID\"}", PerpetualApiCodes.OutOfRangeAssetId };
        yield return new object[] { "{\"code\": \"OUT_OF_RANGE_ASSET_RESOLUTION\"}", PerpetualApiCodes.OutOfRangeAssetResolution };
        yield return new object[] { "{\"code\": \"OUT_OF_RANGE_COLLATERAL_ASSET_ID\"}", PerpetualApiCodes.OutOfRangeCollateralAssetId };
        yield return new object[] { "{\"code\": \"OUT_OF_RANGE_CONTRACT_ADDRESS\"}", PerpetualApiCodes.OutOfRangeContractAddress };
        yield return new object[] { "{\"code\": \"OUT_OF_RANGE_EXTERNAL_PRICE\"}", PerpetualApiCodes.OutOfRangeExternalPrice };
        yield return new object[] { "{\"code\": \"OUT_OF_RANGE_ORACLE_PRICE_SIGNED_ASSET_ID\"}", PerpetualApiCodes.OutOfRangeOraclePriceSignedAssetId };
        yield return new object[] { "{\"code\": \"OUT_OF_RANGE_FACT\"}", PerpetualApiCodes.OutOfRangeFact };
        yield return new object[] { "{\"code\": \"OUT_OF_RANGE_FUNDING_INDEX\"}", PerpetualApiCodes.OutOfRangeFundingIndex };
        yield return new object[] { "{\"code\": \"OUT_OF_RANGE_FUNDING_RATE\"}", PerpetualApiCodes.OutOfRangeFundingRate };
        yield return new object[] { "{\"code\": \"OUT_OF_RANGE_POSITION_ID\"}", PerpetualApiCodes.OutOfRangePositionId };
        yield return new object[] { "{\"code\": \"OUT_OF_RANGE_PRICE\"}", PerpetualApiCodes.OutOfRangePrice };
        yield return new object[] { "{\"code\": \"OUT_OF_RANGE_RISK_FACTOR\"}", PerpetualApiCodes.OutOfRangeRiskFactor };
        yield return new object[] { "{\"code\": \"OUT_OF_RANGE_TIMESTAMP\"}", PerpetualApiCodes.OutOfRangeTimestamp };
        yield return new object[] { "{\"code\": \"OUT_OF_RANGE_TOTAL_RISK\"}", PerpetualApiCodes.OutOfRangeTotalRisk };
        yield return new object[] { "{\"code\": \"OUT_OF_RANGE_TOTAL_VALUE\"}", PerpetualApiCodes.OutOfRangeTotalValue };
        yield return new object[] { "{\"code\": \"SAME_POSITION_ID\"}", PerpetualApiCodes.SamePositionId };
        yield return new object[] { "{\"code\": \"SYSTEM_TIME_DECREASING\"}", PerpetualApiCodes.SystemTimeDecreasing };
        yield return new object[] { "{\"code\": \"TOO_MANY_SYNTHETIC_ASSETS_IN_POSITION\"}", PerpetualApiCodes.TooManySyntheticAssetsInPosition };
        yield return new object[] { "{\"code\": \"TOO_MANY_SYNTHETIC_ASSETS_IN_SYSTEM\"}", PerpetualApiCodes.TooManySyntheticAssetsInSystem };
        yield return new object[] { "{\"code\": \"TRANSACTION_RECEIVED\"}", PerpetualApiCodes.TransactionReceived };
        yield return new object[] { "{\"code\": \"UNFAIR_DELEVERAGE\"}", PerpetualApiCodes.UnfairDeleverage };
        yield return new object[] { "{\"code\": \"UNASSIGNED_POSITION_FUNDS\"}", PerpetualApiCodes.UnassignedPositionFunds };
        yield return new object[] { "{\"code\": \"UNDELEVERAGABLE_POSITION\"}", PerpetualApiCodes.UndeleveragablePosition };
        yield return new object[] { "{\"code\": \"UNLIQUIDATABLE_POSITION\"}", PerpetualApiCodes.UnliquidatablePosition };
    }

    private IPerpetualGatewayClient CreateService()
    {
        return new PerpetualGatewayClient(httpClientFactory.Object, settings);
    }

    private void MockHttpClient(string expectedCode = "{\"code\": \"TRANSACTION_RECEIVED\"}")
    {
        httpMessageHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
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

    private void AssertHttpRequestMessage(string expectedRequestModel)
    {
        httpMessageHandler.Protected()
            .Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(
                    x =>
                        x.RequestUri!.AbsolutePath.Equals("/add_transaction") &&
                        x.Content!.ReadAsStringAsync().Result.RemoveNewLineCharsAndSpacesAndTrim().Equals(expectedRequestModel.RemoveNewLineCharsAndSpacesAndTrim())),
                ItExpr.IsAny<CancellationToken>());
    }
}