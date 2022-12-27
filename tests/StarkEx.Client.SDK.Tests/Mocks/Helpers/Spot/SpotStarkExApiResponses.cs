namespace StarkEx.Client.SDK.Tests.Mocks.Helpers.Spot;

public class SpotStarkExApiResponses
{
    private const string Prefix = "Mocks/Json/Spot/Responses";

    public static string GetBatchDataMock()
    {
        return ReadJsonFile($"{Prefix}/BatchDataResponseMock.json");
    }

    public static string GetExpectedBatchEnclosingIdsResponseModel()
    {
        return ReadJsonFile($"{Prefix}/BatchEnclosingIdsResponseMock.json");
    }

    public static string GetExpectedBatchIdsResponseModel()
    {
        return ReadJsonFile($"{Prefix}/BatchIdsResponseMock.json");
    }

    public static string GetExpectedBatchInfoResponseModel()
    {
        return ReadJsonFile($"{Prefix}/BatchInfoResponseMock.json");
    }

    public static string GetExpectedBatchInfoV2ResponseModel()
    {
        return ReadJsonFile($"{Prefix}/BatchInfoV2ResponseMock.json");
    }

    private static string ReadJsonFile(string path)
    {
        using var r = new StreamReader(path);

        return r.ReadToEnd();
    }
}
