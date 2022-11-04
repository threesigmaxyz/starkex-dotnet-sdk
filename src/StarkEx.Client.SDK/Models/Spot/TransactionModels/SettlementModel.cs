﻿namespace StarkEx.Client.SDK.Models.Spot.TransactionModels;

using System.Text.Json.Serialization;

public class SettlementModel : TransactionModel
{
    [JsonPropertyName("party_a_order")]
    public OrderRequestModel PartyA { get; set; }

    [JsonPropertyName("party_b_order")]
    public OrderRequestModel PartyB { get; set; }

    [JsonPropertyName("settlement_info")]
    public SettlementInfoModel SettlementInfo { get; set; }

    [JsonPropertyName("type")]
    public override string Type => "SettlementRequest";
}