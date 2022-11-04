namespace StarkEx.Client.SDK.Clients;

using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Settings;

[SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private", Justification = "Fields are used on a child class")]
public abstract class BaseClient
{
    protected readonly JsonSerializerOptions requestSerializerOptions = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    };

    protected IHttpClientFactory httpClientFactory;

    protected StarkExApiSettings settings;
}