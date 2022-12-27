namespace StarkEx.Client.SDK.Enums.Perpetual;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

/// <summary>
/// Enum of request types for the StarkEx perpetual order API.
/// Uses a JSON string enum converter to serialize and deserialize the values as strings.
/// </summary>
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum PerpetualOrderRequestType
{
    /// <summary>
    /// A limit order with fees.
    /// </summary>
    [EnumMember(Value = "LIMIT_ORDER_WITH_FEES")]
    LIMIT_ORDER_WITH_FEES = 0,
}
