namespace StarkEx.Client.SDK.Extensions;

using Microsoft.Extensions.DependencyInjection;
using StarkEx.Client.SDK.Clients.Perpetual;
using StarkEx.Client.SDK.Clients.Spot;
using StarkEx.Client.SDK.Interfaces.Perpetual;
using StarkEx.Client.SDK.Interfaces.Spot;

public static class ServiceExtensions
{
    public static IServiceCollection AddStarkEx(this IServiceCollection services)
    {
        // Spot Clients
        services.AddSingleton<ISpotClient, SpotClient>();
        services.AddSingleton<ISpotGatewayClient, SpotGatewayClient>();
        services.AddSingleton<ISpotFeederGatewayClient, SpotFeederGatewayClient>();
        services.AddSingleton<ISpotAvailabilityGatewayClient, SpotAvailabilityGatewayClient>();

        // Perpetual Clients
        services.AddSingleton<IPerpetualClient, PerpetualClient>();
        services.AddSingleton<IPerpetualGatewayClient, PerpetualGatewayClient>();
        services.AddSingleton<IPerpetualFeederGatewayClient, PerpetualFeederGatewayClient>();
        services.AddSingleton<IPerpetualAvailabilityGatewayClient, PerpetualAvailabilityGatewayClient>();

        return services;
    }
}