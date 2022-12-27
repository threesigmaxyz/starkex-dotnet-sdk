namespace StarkEx.Client.SDK.Enums.Spot;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

/// <summary>
/// Enum of response messages for the StarkEx feeder gateway API.
/// Uses a JSON string enum converter to serialize and deserialize the values as strings.
/// </summary>
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum FeederGatewayResponseMessages
{
    /// <summary>
    /// The feeder gateway is alive.
    /// </summary>
    [EnumMember(Value = "FeederGateway is alive!")]
    FeederGatewayIsAliveMessage = 0,

    /// <summary>
    /// The feeder gateway is ready.
    /// </summary>
    [EnumMember(Value = "FeederGateway is ready!")]
    FeederGatewayIsReadyMessage = 1,
}
