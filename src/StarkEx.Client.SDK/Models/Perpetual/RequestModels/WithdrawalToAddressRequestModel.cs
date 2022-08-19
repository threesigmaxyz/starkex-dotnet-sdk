namespace StarkEx.Client.SDK.Models.Perpetual.RequestModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

public class WithdrawalToAddressRequestModel : BaseRequestModel
{
    [JsonPropertyName("tx")]
    public WithdrawalToAddressModel Transaction { get; set; }
}