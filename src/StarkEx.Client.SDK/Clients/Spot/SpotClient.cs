namespace StarkEx.Client.SDK.Clients.Spot;

using StarkEx.Client.SDK.Interfaces.Spot;

/// <inheritdoc />
public class SpotClient : ISpotClient
{
    public SpotClient(
        ISpotAvailabilityGatewayClient availabilityGatewayClient,
        ISpotFeederGatewayClient feederGatewayClient,
        ISpotGatewayClient gatewayClient)
    {
        AvailabilityGatewayClient = availabilityGatewayClient;
        FeederGatewayClient = feederGatewayClient;
        GatewayClient = gatewayClient;
    }

    /// <inheritdoc />
    public ISpotAvailabilityGatewayClient AvailabilityGatewayClient { get; set; }

    /// <inheritdoc />
    public ISpotFeederGatewayClient FeederGatewayClient { get; set; }

    /// <inheritdoc />
    public ISpotGatewayClient GatewayClient { get; set; }
}
