namespace StarkEx.Client.SDK.Tests.Mocks.Helpers.Perpetual;

public class PerpetualStarkExApiResponses
{
    private const string Prefix = "Mocks/Json/Perpetual/Responses";

    public static string GetExpectedBatchResponseInfoModel()
    {
        return ReadJsonFile($"{Prefix}/BatchInfoResponseMock.json");
    }

    public static string GetExpectedStateUpdateModel()
    {
        return ReadJsonFile($"{Prefix}/StateUpdateResponseMock.json");
    }

    private static string ReadJsonFile(string path)
    {
        using var r = new StreamReader(path);

        return r.ReadToEnd();
    }
}
