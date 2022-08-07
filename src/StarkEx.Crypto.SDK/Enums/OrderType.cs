namespace StarkEx.Crypto.SDK.Enums;

public enum OrderType
{
    [Obsolete("This order type is no longer supported")]
    LimitOrder = 0,
    [Obsolete("This order type is no longer supported")]
    Transfer = 1,
    [Obsolete("This order type is no longer supported")]
    ConditionalTransfer = 2,
    LimitOrderWithFees = 3,
    TransferWithFees = 4,
    ConditionalTransferWithFees = 5,
}