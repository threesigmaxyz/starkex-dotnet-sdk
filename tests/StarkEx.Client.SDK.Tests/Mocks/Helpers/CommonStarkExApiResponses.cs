namespace StarkEx.Client.SDK.Tests.Mocks.Helpers;

public class CommonStarkExApiResponses
{
    public static string GetExpectedInternalServerErrorResponseModel()
    {
        return ReadJsonFile($"Mocks/Json/Common/InternalServerErrorResponseMock.json");
    }

    private static string ReadJsonFile(string path)
    {
        using var r = new StreamReader(path);

        return r.ReadToEnd();
    }
}