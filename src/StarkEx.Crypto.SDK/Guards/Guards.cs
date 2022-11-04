namespace StarkEx.Crypto.SDK.Guards;

using Nethereum.Hex.HexConvertors.Extensions;

public static class Guards
{
    public static void NotInvalidHex(string param, string paramName)
    {
        if (param != null && !param.IsHex())
        {
            throw new ArgumentException("Parameter isn't a valid hexadecimal type.", paramName);
        }
    }

    public static void NotNullOrEmptyOrWhitespace(string value)
    {
        NotNull(value);
        NotEmptyOrWhitespace(value);
    }

    public static void NotNull(object param)
    {
        Fail(param == null, $"Parameter {param} is null");
    }

    private static void NotEmptyOrWhitespace(string value)
    {
        Fail(value.All(char.IsWhiteSpace) || value == string.Empty, $"{value} is empty or whitespace");
    }

    private static void Fail(bool condition, string message)
    {
        if (condition)
        {
            throw new ArgumentException(message);
        }
    }
}