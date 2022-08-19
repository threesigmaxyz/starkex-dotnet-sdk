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
        services.AddSingleton<ISpotClient, SpotClient>();
        services.AddSingleton<IPerpetualClient, PerpetualClient>();

        return services;
    }
}