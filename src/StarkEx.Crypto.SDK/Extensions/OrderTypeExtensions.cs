namespace StarkEx.Crypto.SDK.Extensions;

using StarkEx.Crypto.SDK.Enums;

public static class OrderTypeExtensions
{
    public static string ToIntegerString(this OrderType orderType)
    {
        return ((int)orderType).ToString();
    }
}