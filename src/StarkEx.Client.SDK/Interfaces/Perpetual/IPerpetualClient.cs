namespace StarkEx.Client.SDK.Interfaces.Perpetual;

/// <summary>
///     SDK client for Perpetual APIs.
/// </summary>
public interface IPerpetualClient
{
    /// <summary>
    ///     Gets or sets perpetual StarkEx API endpoints for data availability committee interactions.
    /// </summary>
    IPerpetualAvailabilityGatewayClient AvailabilityGatewayClient { get; set; }

    /// <summary>
    ///     Gets or sets perpetual StarkEx API endpoints for feeder interactions.
    /// </summary>
    IPerpetualFeederGatewayClient FeederGatewayClient { get; set; }

    /// <summary>
    ///     Gets or sets perpetual StarkEx API endpoints for external interactions.
    /// </summary>
    IPerpetualGatewayClient GatewayClient { get; set; }
}
