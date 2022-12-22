namespace StarkEx.Client.SDK.Models.Spot.FeederGatewayModels;

using System.Text.Json.Serialization;

/// <summary>
///     Representation of a Tree.
/// </summary>
public class RootModel
{
    /// <summary>
    ///     Gets or sets the height of the Tree.
    /// </summary>
    [JsonPropertyName("height")]
    public int Height { get; set; }

    /// <summary>
    ///     Gets or sets the roof of the Tree.
    /// </summary>
    [JsonPropertyName("root")]
    public string Root { get; set; }
}
