namespace StarkEx.Client.SDK.Extensions;

using Microsoft.Extensions.DependencyInjection;
using StarkEx.Client.SDK.Clients.Perpetual;
using StarkEx.Client.SDK.Clients.Spot;
using StarkEx.Client.SDK.Interfaces.Perpetual;
using StarkEx.Client.SDK.Interfaces.Spot;

/// <summary>
/// Provides extension methods for configuring the StarkEx API client in a .NET application.
/// </summary>
public static class ServiceExtensions
{
    /// <summary>
    /// Registers the StarkEx API clients in the specified .NET Dependency Injection container.
    /// This method should be called from the `ConfigureServices` method in the startup class of your application.
    /// </summary>
    /// <param name="services">The .NET Dependency Injection container to configure.</param>
    /// <returns>The configured .NET Dependency Injection container.</returns>
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
