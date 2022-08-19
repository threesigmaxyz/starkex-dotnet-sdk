﻿namespace StarkEx.Client.SDK.Models.Perpetual.RequestModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

public class DeleverageRequestModel : BaseRequestModel
{
    [JsonPropertyName("tx")]
    public DeleverageModel Transaction { get; set; }
}