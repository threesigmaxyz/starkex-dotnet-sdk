namespace StarkEx.Client.SDK.Clients.Perpetual;

using StarkEx.Client.SDK.Interfaces.Perpetual;

/// <inheritdoc />
public class PerpetualClient : IPerpetualClient
{
    public PerpetualClient(
        IPerpetualAvailabilityGatewayClient availabilityGatewayClient,
        IPerpetualFeederGatewayClient feederGatewayClient,
        IPerpetualGatewayClient gatewayClient)
    {
        AvailabilityGatewayClient = availabilityGatewayClient;
        FeederGatewayClient = feederGatewayClient;
        GatewayClient = gatewayClient;
    }

    /// <inheritdoc />
    public IPerpetualAvailabilityGatewayClient AvailabilityGatewayClient { get; set; }

    /// <inheritdoc />
    public IPerpetualFeederGatewayClient FeederGatewayClient { get; set; }

    /// <inheritdoc />
    public IPerpetualGatewayClient GatewayClient { get; set; }
}
