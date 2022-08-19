namespace StarkEx.Client.SDK.Tests.Mocks.Helpers.Perpetual;

public class PerpetualStarkExApiRequests
{
    private const string Prefix = "Mocks/Json/Perpetual/Requests";

    public static string GetExpectedConditionalTransferRequestModel()
    {
        return ReadJsonFile($"{Prefix}/ConditionalTransferRequestMock.json");
    }

    public static string GetExpectedDeleverageRequestModel()
    {
        return ReadJsonFile($"{Prefix}/DeleverageRequestMock.json");
    }

    public static string GetExpectedDepositRequestModel()
    {
        return ReadJsonFile($"{Prefix}/DepositRequestMock.json");
    }

    public static string GetExpectedForcedTradeRequestModel()
    {
        return ReadJsonFile($"{Prefix}/ForcedTradeRequestMock.json");
    }

    public static string GetExpectedForcedWithdrawalRequestModel()
    {
        return ReadJsonFile($"{Prefix}/ForcedWithdrawalRequestMock.json");
    }

    public static string GetExpectedFundingTickRequestModel()
    {
        return ReadJsonFile($"{Prefix}/FundingTickRequestMock.json");
    }

    public static string GetExpectedLiquidateRequestModel()
    {
        return ReadJsonFile($"{Prefix}/LiquidateRequestMock.json");
    }

    public static string GetExpectedMultiTransactionRequestModel()
    {
        return ReadJsonFile($"{Prefix}/MultiTransactionRequestMock.json");
    }

    public static string GetExpectedOraclePricesTickRequestModel()
    {
        return ReadJsonFile($"{Prefix}/OraclePricesTickRequestMock.json");
    }

    public static string GetExpectedTradeRequestModel()
    {
        return ReadJsonFile($"{Prefix}/TradeRequestMock.json");
    }

    public static string GetExpectedTransferRequestModel()
    {
        return ReadJsonFile($"{Prefix}/TransferRequestMock.json");
    }

    public static string GetExpectedWithdrawalRequestModel()
    {
        return ReadJsonFile($"{Prefix}/WithdrawalRequestMock.json");
    }

    public static string GetExpectedWithdrawalToAddressRequestModel()
    {
        return ReadJsonFile($"{Prefix}/WithdrawalToAddressRequestMock.json");
    }

    private static string ReadJsonFile(string path)
    {
        using var r = new StreamReader(path);

        return r.ReadToEnd();
    }
}