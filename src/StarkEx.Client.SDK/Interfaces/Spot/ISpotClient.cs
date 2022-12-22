namespace StarkEx.Client.SDK.Interfaces.Spot;

/// <summary>
///     SDK client for Spot APIs.
/// </summary>
public interface ISpotClient
{
    /// <summary>
    ///     Gets or sets spot StarkEx API endpoints for data availability committee interactions.
    /// </summary>
    ISpotAvailabilityGatewayClient AvailabilityGatewayClient { get; set; }

    /// <summary>
    ///     Gets or sets spot StarkEx API endpoints for feeder interactions.
    /// </summary>
    ISpotFeederGatewayClient FeederGatewayClient { get; set; }

    /// <summary>
    ///     Gets or sets spot StarkEx API endpoints for external interactions.
    /// </summary>
    ISpotGatewayClient GatewayClient { get; set; }
}
