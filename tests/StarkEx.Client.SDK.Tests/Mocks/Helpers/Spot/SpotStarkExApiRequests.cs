namespace StarkEx.Client.SDK.Tests.Mocks.Helpers.Spot;

// All these mocks are taken from the examples in the documentation @https://starkware.co/starkex-restapi-v4/gateway.html
// TODO Ideally in the future we can perform proper contract testing to avoid depending on having the same prop order that is used on StarkEx Docs
// https://github.com/pact-foundation/pact-net
public static class SpotStarkExApiRequests
{
    private const string Prefix = "Mocks/Json/Spot/Requests";

    public static string GetExpectedMintRequestModel()
    {
        return ReadJsonFile($"{Prefix}/MintRequestMock.json");
    }

    public static string GetExpectedSettlementRequestModel()
    {
        return ReadJsonFile($"{Prefix}/SettlementRequestMock.json");
    }

    public static string GetExpectedTransferRequestModel()
    {
        return ReadJsonFile($"{Prefix}/TransferRequestMock.json");
    }

    public static string GetExpectedDepositRequestModel()
    {
        return ReadJsonFile($"{Prefix}/DepositRequestMock.json");
    }

    public static string GetExpectedWithdrawalRequestModel()
    {
        return ReadJsonFile($"{Prefix}/WithdrawalRequestMock.json");
    }

    public static string GetExpectedFullWithdrawalRequestModel()
    {
        return ReadJsonFile($"{Prefix}/FullWithdrawalRequestMock.json");
    }

    public static string GetExpectedFalseFullWithdrawalRequestModel()
    {
        return ReadJsonFile($"{Prefix}/FalseFullWithdrawalRequestMock.json");
    }

    public static string GetExpectedMultiTransactionRequestModel()
    {
        return ReadJsonFile($"{Prefix}/MultiTransactionRequestMock.json");
    }

    public static string GetExpectedCommitteeSignatureModel()
    {
        return ReadJsonFile($"{Prefix}/CommitteeSignatureMock.json");
    }

    private static string ReadJsonFile(string path)
    {
        using var r = new StreamReader(path);

        return r.ReadToEnd();
    }
}
