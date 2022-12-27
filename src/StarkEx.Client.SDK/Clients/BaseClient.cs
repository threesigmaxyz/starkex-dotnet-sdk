namespace StarkEx.Client.SDK.Clients;

using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Settings;

/// <summary>
/// Represents the base class for all StarkEx API clients.
/// </summary>
[SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private", Justification = "Fields are used on a child class")]
public abstract class BaseClient
{
    protected readonly JsonSerializerOptions requestSerializerOptions = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    };

    /// <summary>
    /// Gets or sets the HTTP client factory used to create HTTP clients for making requests to the StarkEx API.
    /// </summary>
    protected IHttpClientFactory httpClientFactory;

    /// <summary>
    /// Gets or sets the <see cref="StarkExApiSettings"/> used to configure the StarkEx API client.
    /// </summary>
    protected StarkExApiSettings settings;
}
