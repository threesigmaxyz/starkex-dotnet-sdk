namespace StarkEx.Client.SDK.Enums.Perpetual;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

/// <summary>
/// Enum of API codes for the StarkEx Perpetual API.
/// Uses a JSON string enum converter to serialize and deserialize the values as strings.
/// Official documentation <see href="https://starkware.co/starkex-perpetual-api-v2/">here</see>.
/// </summary>
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum PerpetualApiCodes
{
    /// <summary>
    /// An illegal position transition occurred where the synthetic holdings were enlarged.
    /// </summary>
    [EnumMember(Value = "ILLEGAL_POSITION_TRANSITION_ENLARGING_SYNTHETIC_HOLDINGS")]
    IllegalPositionTransitionEnlargingSyntheticHoldings = 0,

    /// <summary>
    /// An illegal position transition occurred where the total value risk ratio was reduced.
    /// </summary>
    [EnumMember(Value = "ILLEGAL_POSITION_TRANSITION_REDUCING_TOTAL_VALUE_RISK_RATIO")]
    IllegalPositionTransitionReducingTotalValueRiskRatio = 1,

    /// <summary>
    /// An illegal position transition occurred where no risk was reduced.
    /// </summary>
    [EnumMember(Value = "ILLEGAL_POSITION_TRANSITION_NO_RISK_REDUCED_VALUE")]
    IllegalPositionTransitionNoRiskReducedValue = 2,

    /// <summary>
    /// An invalid asset oracle price was provided.
    /// </summary>
    [EnumMember(Value = "INVALID_ASSET_ORACLE_PRICE")]
    InvalidAssetOraclePrice = 3,

    /// <summary>
    /// An invalid collateral asset ID was provided.
    /// </summary>
    [EnumMember(Value = "INVALID_COLLATERAL_ASSET_ID")]
    InvalidCollateralAssetId = 4,

    /// <summary>
    /// An invalid fee position participation was provided.
    /// </summary>
    [EnumMember(Value = "INVALID_FEE_POSITION_PARTICIPATION")]
    InvalidFeePositionParticipation = 5,

    /// <summary>
    /// An invalid forced transaction was provided.
    /// </summary>
    [EnumMember(Value = "INVALID_FORCED_TRANSACTION")]
    InvalidForcedTransaction = 6,

    /// <summary>
    /// An invalid fulfillment assets ratio was provided.
    /// </summary>
    [EnumMember(Value = "INVALID_FULFILLMENT_ASSETS_RATIO")]
    InvalidFulfillmentAssetsRatio = 7,

    /// <summary>
    /// An invalid fulfillment fee ratio was provided.
    /// </summary>
    [EnumMember(Value = "INVALID_FULFILLMENT_FEE_RATIO")]
    InvalidFulfillmentFeeRatio = 8,

    /// <summary>
    /// Invalid fulfillment information was provided.
    /// </summary>
    [EnumMember(Value = "INVALID_FULFILLMENT_INFO")]
    InvalidFulfillmentInfo = 9,

    /// <summary>
    /// An invalid funding tick rate was provided.
    /// </summary>
    [EnumMember(Value = "INVALID_FUNDING_TICK_RATE")]
    InvalidFundingTickRate = 10,

    /// <summary>
    /// An invalid funding tick timestamp was provided.
    /// </summary>
    [EnumMember(Value = "INVALID_FUNDING_TICK_TIMESTAMP")]
    InvalidFundingTickTimestamp = 11,

    /// <summary>
    /// An invalid liquidate order was provided.
    /// </summary>
    [EnumMember(Value = "INVALID_LIQUIDATE")]
    InvalidLiquidate = 12,

    /// <summary>
    /// Invalid assets were provided for an order.
    /// </summary>
    [EnumMember(Value = "INVALID_ORDER_ASSETS")]
    InvalidOrderAssets = 13,

    /// <summary>
    /// An invalid value was provided for the "is buying" property of an order.
    /// </summary>
    [EnumMember(Value = "INVALID_ORDER_IS_BUYING_PROPERTY")]
    InvalidOrderIsBuyingProperty = 14,

    /// <summary>
    /// An invalid public key was provided.
    /// </summary>
    [EnumMember(Value = "INVALID_PUBLIC_KEY")]
    InvalidPublicKey = 15,

    /// <summary>
    /// An invalid synthetic asset ID was provided.
    /// </summary>
    [EnumMember(Value = "INVALID_SYNTHETIC_ASSET_ID")]
    InvalidSyntheticAssetId = 16,

    /// <summary>
    /// An invalid tick timestamp was provided, with a distance from the blockchain time that is out of range.
    /// </summary>
    [EnumMember(Value = "INVALID_TICK_TIMESTAMP_DISTANCE_FROM_BLOCKCHAIN_TIME")]
    InvalidTickTimestampDistanceFromBlockchainTime = 17,

    /// <summary>
    /// The global funding index is missing.
    /// </summary>
    [EnumMember(Value = "MISSING_GLOBAL_FUNDING_INDEX")]
    MissingGlobalFundingIndex = 18,

    /// <summary>
    /// The oracle price is missing.
    /// </summary>
    [EnumMember(Value = "MISSING_ORACLE_PRICE")]
    MissingOraclePrice = 19,

    /// <summary>
    /// The oracle price is signed, but not within the specified time range.
    /// </summary>
    [EnumMember(Value = "MISSING_ORACLE_PRICE_SIGNED_IN_TIME_RANGE")]
    MissingOraclePriceSignedInTimeRange = 20,

    /// <summary>
    /// The signed oracle price is missing.
    /// </summary>
    [EnumMember(Value = "MISSING_SIGNED_ORACLE_PRICE")]
    MissingSignedOraclePrice = 21,

    /// <summary>
    /// The synthetic asset ID is missing.
    /// </summary>
    [EnumMember(Value = "MISSING_SYNTHETIC_ASSET_ID")]
    MissingSyntheticAssetId = 22,

    /// <summary>
    /// The provided asset ID is out of range.
    /// </summary>
    [EnumMember(Value = "OUT_OF_RANGE_ASSET_ID")]
    OutOfRangeAssetId = 23,

    /// <summary>
    /// The provided asset resolution is out of range.
    /// </summary>
    [EnumMember(Value = "OUT_OF_RANGE_ASSET_RESOLUTION")]
    OutOfRangeAssetResolution = 24,

    /// <summary>
    /// The provided collateral asset ID is out of range.
    /// </summary>
    [EnumMember(Value = "OUT_OF_RANGE_COLLATERAL_ASSET_ID")]
    OutOfRangeCollateralAssetId = 25,

    /// <summary>
    /// The provided contract address is out of range.
    /// </summary>
    [EnumMember(Value = "OUT_OF_RANGE_CONTRACT_ADDRESS")]
    OutOfRangeContractAddress = 26,

    /// <summary>
    /// The provided external price is out of range.
    /// </summary>
    [EnumMember(Value = "OUT_OF_RANGE_EXTERNAL_PRICE")]
    OutOfRangeExternalPrice = 27,

    /// <summary>
    /// The provided oracle price signed asset ID is out of range.
    /// </summary>
    [EnumMember(Value = "OUT_OF_RANGE_ORACLE_PRICE_SIGNED_ASSET_ID")]
    OutOfRangeOraclePriceSignedAssetId = 28,

    /// <summary>
    /// The provided fact is out of range.
    /// </summary>
    [EnumMember(Value = "OUT_OF_RANGE_FACT")]
    OutOfRangeFact = 29,

    /// <summary>
    /// The provided funding index is out of range.
    /// </summary>
    [EnumMember(Value = "OUT_OF_RANGE_FUNDING_INDEX")]
    OutOfRangeFundingIndex = 30,

    /// <summary>
    /// The provided funding rate is out of range.
    /// </summary>
    [EnumMember(Value = "OUT_OF_RANGE_FUNDING_RATE")]
    OutOfRangeFundingRate = 31,

    /// <summary>
    /// The provided position ID is out of range.
    /// </summary>
    [EnumMember(Value = "OUT_OF_RANGE_POSITION_ID")]
    OutOfRangePositionId = 32,

    /// <summary>
    /// The provided price is out of range.
    /// </summary>
    [EnumMember(Value = "OUT_OF_RANGE_PRICE")]
    OutOfRangePrice = 33,

    /// <summary>
    /// The provided risk factor is out of range.
    /// </summary>
    [EnumMember(Value = "OUT_OF_RANGE_RISK_FACTOR")]
    OutOfRangeRiskFactor = 34,

    /// <summary>
    /// The provided timestamp is out of range.
    /// </summary>
    [EnumMember(Value = "OUT_OF_RANGE_TIMESTAMP")]
    OutOfRangeTimestamp = 35,

    /// <summary>
    /// The provided total risk is out of range.
    /// </summary>
    [EnumMember(Value = "OUT_OF_RANGE_TOTAL_RISK")]
    OutOfRangeTotalRisk = 36,

    /// <summary>
    /// The provided total value is out of range.
    /// </summary>
    [EnumMember(Value = "OUT_OF_RANGE_TOTAL_VALUE")]
    OutOfRangeTotalValue = 37,

    /// <summary>
    /// The provided position ID is already in use.
    /// </summary>
    [EnumMember(Value = "SAME_POSITION_ID")]
    SamePositionId = 38,

    /// <summary>
    /// The system time is decreasing.
    /// </summary>
    [EnumMember(Value = "SYSTEM_TIME_DECREASING")]
    SystemTimeDecreasing = 39,

    /// <summary>
    /// The position has too many synthetic assets.
    /// </summary>
    [EnumMember(Value = "TOO_MANY_SYNTHETIC_ASSETS_IN_POSITION")]
    TooManySyntheticAssetsInPosition = 40,

    /// <summary>
    /// The system has too many synthetic assets.
    /// </summary>
    [EnumMember(Value = "TOO_MANY_SYNTHETIC_ASSETS_IN_SYSTEM")]
    TooManySyntheticAssetsInSystem = 41,

    /// <summary>
    /// The transaction has already been received.
    /// </summary>
    [EnumMember(Value = "TRANSACTION_RECEIVED")]
    TransactionReceived = 42,

    /// <summary>
    /// The provided deleverage is unfair.
    /// </summary>
    [EnumMember(Value = "UNFAIR_DELEVERAGE")]
    UnfairDeleverage = 43,

    /// <summary>
    /// The provided position has unassigned funds.
    /// </summary>
    [EnumMember(Value = "UNASSIGNED_POSITION_FUNDS")]
    UnassignedPositionFunds = 44,

    /// <summary>
    /// The provided position is undeletveragable.
    /// </summary>
    [EnumMember(Value = "UNDELEVERAGABLE_POSITION")]
    UndeleveragablePosition = 45,

    /// <summary>
    /// The provided position is unliquidatable.
    /// </summary>
    [EnumMember(Value = "UNLIQUIDATABLE_POSITION")]
    UnliquidatablePosition = 46,
}