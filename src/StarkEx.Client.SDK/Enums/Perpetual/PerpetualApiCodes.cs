namespace StarkEx.Client.SDK.Enums.Perpetual;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum PerpetualApiCodes
{
    [EnumMember(Value = "ILLEGAL_POSITION_TRANSITION_ENLARGING_SYNTHETIC_HOLDINGS")]
    IllegalPositionTransitionEnlargingSyntheticHoldings = 0,

    [EnumMember(Value = "ILLEGAL_POSITION_TRANSITION_REDUCING_TOTAL_VALUE_RISK_RATIO")]
    IllegalPositionTransitionReducingTotalValueRiskRatio = 1,

    [EnumMember(Value = "ILLEGAL_POSITION_TRANSITION_NO_RISK_REDUCED_VALUE")]
    IllegalPositionTransitionNoRiskReducedValue = 2,

    [EnumMember(Value = "INVALID_ASSET_ORACLE_PRICE")]
    InvalidAssetOraclePrice = 3,

    [EnumMember(Value = "INVALID_COLLATERAL_ASSET_ID")]
    InvalidCollateralAssetId = 4,

    [EnumMember(Value = "INVALID_FEE_POSITION_PARTICIPATION")]
    InvalidFeePositionParticipation = 5,

    [EnumMember(Value = "INVALID_FORCED_TRANSACTION")]
    InvalidForcedTransaction = 6,

    [EnumMember(Value = "INVALID_FULFILLMENT_ASSETS_RATIO")]
    InvalidFulfillmentAssetsRatio = 7,

    [EnumMember(Value = "INVALID_FULFILLMENT_FEE_RATIO")]
    InvalidFulfillmentFeeRatio = 8,

    [EnumMember(Value = "INVALID_FULFILLMENT_INFO")]
    InvalidFulfillmentInfo = 9,

    [EnumMember(Value = "INVALID_FUNDING_TICK_RATE")]
    InvalidFundingTickRate = 10,

    [EnumMember(Value = "INVALID_FUNDING_TICK_TIMESTAMP")]
    InvalidFundingTickTimestamp = 11,

    [EnumMember(Value = "INVALID_LIQUIDATE")]
    InvalidLiquidate = 12,

    [EnumMember(Value = "INVALID_ORDER_ASSETS")]
    InvalidOrderAssets = 13,

    [EnumMember(Value = "INVALID_ORDER_IS_BUYING_PROPERTY")]
    InvalidOrderIsBuyingProperty = 14,

    [EnumMember(Value = "INVALID_PUBLIC_KEY")]
    InvalidPublicKey = 15,

    [EnumMember(Value = "INVALID_SYNTHETIC_ASSET_ID")]
    InvalidSyntheticAssetId = 16,

    [EnumMember(Value = "INVALID_TICK_TIMESTAMP_DISTANCE_FROM_BLOCKCHAIN_TIME")]
    InvalidTickTimestampDistanceFromBlockchainTime = 17,

    [EnumMember(Value = "MISSING_GLOBAL_FUNDING_INDEX")]
    MissingGlobalFundingIndex = 18,

    [EnumMember(Value = "MISSING_ORACLE_PRICE")]
    MissingOraclePrice = 19,

    [EnumMember(Value = "MISSING_ORACLE_PRICE_SIGNED_IN_TIME_RANGE")]
    MissingOraclePriceSignedInTimeRange = 20,

    [EnumMember(Value = "MISSING_SIGNED_ORACLE_PRICE")]
    MissingSignedOraclePrice = 21,

    [EnumMember(Value = "MISSING_SYNTHETIC_ASSET_ID")]
    MissingSyntheticAssetId = 22,

    [EnumMember(Value = "OUT_OF_RANGE_ASSET_ID")]
    OutOfRangeAssetId = 23,

    [EnumMember(Value = "OUT_OF_RANGE_ASSET_RESOLUTION")]
    OutOfRangeAssetResolution = 24,

    [EnumMember(Value = "OUT_OF_RANGE_COLLATERAL_ASSET_ID")]
    OutOfRangeCollateralAssetId = 25,

    [EnumMember(Value = "OUT_OF_RANGE_CONTRACT_ADDRESS")]
    OutOfRangeContractAddress = 26,

    [EnumMember(Value = "OUT_OF_RANGE_EXTERNAL_PRICE")]
    OutOfRangeExternalPrice = 27,

    [EnumMember(Value = "OUT_OF_RANGE_ORACLE_PRICE_SIGNED_ASSET_ID")]
    OutOfRangeOraclePriceSignedAssetId = 28,

    [EnumMember(Value = "OUT_OF_RANGE_FACT")]
    OutOfRangeFact = 29,

    [EnumMember(Value = "OUT_OF_RANGE_FUNDING_INDEX")]
    OutOfRangeFundingIndex = 30,

    [EnumMember(Value = "OUT_OF_RANGE_FUNDING_RATE")]
    OutOfRangeFundingRate = 31,

    [EnumMember(Value = "OUT_OF_RANGE_POSITION_ID")]
    OutOfRangePositionId = 32,

    [EnumMember(Value = "OUT_OF_RANGE_PRICE")]
    OutOfRangePrice = 33,

    [EnumMember(Value = "OUT_OF_RANGE_RISK_FACTOR")]
    OutOfRangeRiskFactor = 34,

    [EnumMember(Value = "OUT_OF_RANGE_TIMESTAMP")]
    OutOfRangeTimestamp = 35,

    [EnumMember(Value = "OUT_OF_RANGE_TOTAL_RISK")]
    OutOfRangeTotalRisk = 36,

    [EnumMember(Value = "OUT_OF_RANGE_TOTAL_VALUE")]
    OutOfRangeTotalValue = 37,

    [EnumMember(Value = "SAME_POSITION_ID")]
    SamePositionId = 38,

    [EnumMember(Value = "SYSTEM_TIME_DECREASING")]
    SystemTimeDecreasing = 39,

    [EnumMember(Value = "TOO_MANY_SYNTHETIC_ASSETS_IN_POSITION")]
    TooManySyntheticAssetsInPosition = 40,

    [EnumMember(Value = "TOO_MANY_SYNTHETIC_ASSETS_IN_SYSTEM")]
    TooManySyntheticAssetsInSystem = 41,

    [EnumMember(Value = "TRANSACTION_RECEIVED")]
    TransactionReceived = 42,

    [EnumMember(Value = "UNFAIR_DELEVERAGE")]
    UnfairDeleverage = 43,

    [EnumMember(Value = "UNASSIGNED_POSITION_FUNDS")]
    UnassignedPositionFunds = 44,

    [EnumMember(Value = "UNDELEVERAGABLE_POSITION")]
    UndeleveragablePosition = 45,

    [EnumMember(Value = "UNLIQUIDATABLE_POSITION")]
    UnliquidatablePosition = 46,
}