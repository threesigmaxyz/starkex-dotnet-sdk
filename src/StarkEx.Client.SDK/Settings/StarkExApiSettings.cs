namespace StarkEx.Client.SDK.Settings;

/// <summary>
/// Represents the settings used to configure the StarkEx API client.
/// </summary>
public class StarkExApiSettings
{
    /// <summary>
    /// Gets or sets the base address of the StarkEx API.
    /// </summary>
    public Uri BaseAddress { get; set; }

    /// <summary>
    /// Gets or sets the version of the StarkEx API to use.
    /// The default value is "v2".
    /// </summary>
    public string Version { get; set; } = "v2";
}
