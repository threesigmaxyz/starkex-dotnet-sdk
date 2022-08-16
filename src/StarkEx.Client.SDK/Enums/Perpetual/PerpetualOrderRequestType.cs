namespace StarkEx.Client.SDK.Enums.Perpetual;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum PerpetualOrderRequestType
{
    [EnumMember(Value = "LIMIT_ORDER_WITH_FEES")]
    LIMIT_ORDER_WITH_FEES = 0,
}