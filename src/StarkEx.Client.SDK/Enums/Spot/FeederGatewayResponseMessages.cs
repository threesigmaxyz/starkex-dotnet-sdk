namespace StarkEx.Client.SDK.Enums.Spot;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum FeederGatewayResponseMessages
{
    [EnumMember(Value = "FeederGateway is alive!")]
    FeederGatewayIsAliveMessage = 0,

    [EnumMember(Value = "FeederGateway is ready!")]
    FeederGatewayIsReadyMessage = 1,
}