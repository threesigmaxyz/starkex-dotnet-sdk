namespace StarkEx.Client.SDK.Models.Spot.RequestModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Models.Spot.TransactionModels;

public class MintRequestModel : BaseRequestModel
{
    [JsonPropertyName("tx")]
    public MintModel Transaction { get; set; }
}