namespace StarkEx.Crypto.SDK.Extensions;

using Microsoft.Extensions.DependencyInjection;
using StarkEx.Crypto.SDK.Hashing;
using StarkEx.Crypto.SDK.Signing;

/// <summary>
/// Provides extension methods for configuring the StarkEx Crypto SDK in a .NET application.
/// </summary>
public static class ServiceExtensions
{
    /// <summary>
    /// Registers the StarkEx Crypto SDK in the specified .NET Dependency Injection container.
    /// This method should be called from the `ConfigureServices` method in the startup class of your application.
    /// </summary>
    /// <param name="services">The .NET Dependency Injection container to configure.</param>
    /// <returns>The configured .NET Dependency Injection container.</returns>
    public static IServiceCollection AddStarkExCryptoUtils(this IServiceCollection services)
    {
        services.AddSingleton<IPedersenHash, PedersenHash>();
        services.AddSingleton<ISpotTradingMessageHasher, SpotTradingMessageHasher>();
        services.AddSingleton<IStarkExSigner, StarkExSigner>();
        services.AddSingleton<StarkCurve>();

        return services;
    }
}
