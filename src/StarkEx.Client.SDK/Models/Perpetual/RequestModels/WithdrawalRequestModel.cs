﻿namespace StarkEx.Client.SDK.Models.Perpetual.RequestModels;

using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

/// <summary>
/// Represents a request model for a withdrawal transaction in the StarkEx Perpetual API.
/// </summary>
public class WithdrawalRequestModel : BaseRequestModel
{
    /// <summary>
    /// Gets or sets the transaction model for the withdrawal.
    /// </summary>
    /// <value>
    /// The transaction model for the withdrawal.
    /// </value>
    /// <seealso cref="WithdrawalModel"/>
    [JsonPropertyName("tx")]
    public WithdrawalModel Transaction { get; set; }
}
