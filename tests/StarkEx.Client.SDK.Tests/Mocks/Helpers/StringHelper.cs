namespace StarkEx.Client.SDK.Tests.Mocks.Helpers;

using System.Text.RegularExpressions;

public static class StringHelper
{
    public static string RemoveNewLineCharsAndSpacesAndTrim(this string str)
    {
        return Regex.Replace(Regex.Replace(str, @"\t|\n|\r", string.Empty), @"\s+", string.Empty);
    }
}