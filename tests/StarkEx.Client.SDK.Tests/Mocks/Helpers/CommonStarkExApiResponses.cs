namespace StarkEx.Client.SDK.Tests.Mocks.Helpers;

public static class CommonStarkExApiResponses
{
    public static string GetExpectedStarkExErrorExceptionResponseModel()
    {
        return ReadJsonFile("Mocks/Json/Common/StarkExErrorExceptionResponseMock.json");
    }

    public static string GetExpectedStarkExErrorExceptionComplexProblemsResponseModel()
    {
        return ReadJsonFile("Mocks/Json/Common/StarkExErrorExceptionProblemsResponseMock.json");
    }

    private static string ReadJsonFile(string path)
    {
        using var r = new StreamReader(path);

        return r.ReadToEnd();
    }
}