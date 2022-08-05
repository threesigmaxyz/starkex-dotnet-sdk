namespace StarkEx.Crypto.SDK.Extensions;

using Microsoft.Extensions.DependencyInjection;
using StarkEx.Crypto.SDK.Hashing;
using StarkEx.Crypto.SDK.Signing;

public static class ServiceExtensions
{
    public static IServiceCollection AddStarkExCryptoUtils(this IServiceCollection services)
    {
        services.AddSingleton<IPeadersonHash, PeadersonHash>();
        services.AddSingleton<ISpotTradingMessageHasher, SpotTradingMessageHasher>();
        services.AddSingleton<IStarkExSigner, StarkExSigner>();

        return services;
    }
}