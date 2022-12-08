namespace StarkEx.Crypto.SDK.Enums;

/// <summary>
/// Enum of order types supported by the StarkEx system.
/// </summary>
public enum OrderType
{
    /// <summary>
    /// Limit order without fees.
    /// Obsolete order type, no longer supported.
    /// </summary>
    [Obsolete("This order type is no longer supported")]
    LimitOrder = 0,

    /// <summary>
    /// Transfer without fees.
    /// Obsolete order type, no longer supported.
    /// </summary>
    [Obsolete("This order type is no longer supported")]
    Transfer = 1,

    /// <summary>
    /// Conditional transfer without fees.
    /// Obsolete order type, no longer supported.
    /// </summary>
    [Obsolete("This order type is no longer supported")]
    ConditionalTransfer = 2,

    /// <summary>
    /// Limit order with fees.
    /// </summary>
    LimitOrderWithFees = 3,

    /// <summary>
    /// Transfer with fees.
    /// </summary>
    TransferWithFees = 4,

    /// <summary>
    /// Conditional transfer with fees.
    /// </summary>
    ConditionalTransferWithFees = 5,
}