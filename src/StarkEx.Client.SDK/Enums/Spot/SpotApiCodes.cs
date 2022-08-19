namespace StarkEx.Client.SDK.Enums.Spot;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum SpotApiCodes
{
    [EnumMember(Value = "API_FUNCTION_TEMPORARILY_DISABLED")]
    ApiFunctionTemporarilyDisabled = 0,

    [EnumMember(Value = "BATCH_CREATION_FAILURE")]
    BatchCreationFailure = 1,

    [EnumMember(Value = "BATCH_FULL")]
    BatchFull = 2,

    [EnumMember(Value = "BATCH_NOT_READY")]
    BatchNotReady = 3,

    [EnumMember(Value = "CONFLICTING_ORDER_AMOUNTS")]
    ConflictingOrderAmounts = 4,

    [EnumMember(Value = "CONNECTION_ERROR")]
    ConnectionError = 5,

    [EnumMember(Value = "FACT_NOT_REGISTERED")]
    FactNotRegistered = 6,

    [EnumMember(Value = "INSUFFICIENT_ON_CHAIN_BALANCE")]
    InsufficientOnChainBalance = 7,

    [EnumMember(Value = "INVALID_BATCH_ID")]
    InvalidBatchId = 8,

    [EnumMember(Value = "INVALID_CLAIM_HASH")]
    InvalidClaimHash = 9,

    [EnumMember(Value = "INVALID_COMMITTEE_MEMBER")]
    InvalidCommitteeMember = 10,

    [EnumMember(Value = "INVALID_CONTRACT_ADDRESS")]
    InvalidContractAddress = 11,

    [EnumMember(Value = "INVALID_DEPLOYMENT_INFO")]
    InvalidDeploymentInfo = 12,

    [EnumMember(Value = "INVALID_ETH_ADDRESS")]
    InvalidEthAddress = 13,

    [EnumMember(Value = "INVALID_FACT")]
    InvalidFact = 14,

    [EnumMember(Value = "INVALID_FEE_TAKEN")]
    InvalidFeeTaken = 15,

    [EnumMember(Value = "INVALID_ORDER_ID")]
    InvalidOrderId = 16,

    [EnumMember(Value = "INVALID_ORDER_TYPE")]
    InvalidOrderType = 17,

    [EnumMember(Value = "INVALID_REQUEST")]
    InvalidRequest = 18,

    [EnumMember(Value = "INVALID_REQUEST_PARAMETERS")]
    InvalidRequestParameters = 19,

    [EnumMember(Value = "INVALID_SETTLEMENT_INFO")]
    InvalidSettlementInfo = 20,

    [EnumMember(Value = "INVALID_SETTLEMENT_RATIO")]
    InvalidSettlementRatio = 21,

    [EnumMember(Value = "INVALID_SETTLEMENT_TOKENS")]
    InvalidSettlementTokens = 22,

    [EnumMember(Value = "INVALID_SIGNATURE")]
    InvalidSignature = 23,

    [EnumMember(Value = "INVALID_TOKEN_TYPE")]
    InvalidTokenType = 24,

    [EnumMember(Value = "INVALID_TRANSACTION")]
    InvalidTransaction = 25,

    [EnumMember(Value = "INVALID_TRANSACTION_ID")]
    InvalidTransactionId = 26,
    [EnumMember(Value = "INVALID_VAULT")]
    InvalidVault = 27,

    [EnumMember(Value = "MALFORMED_REQUEST")]
    MalformedRequest = 28,

    [EnumMember(Value = "MIGRATED_PIPELINE_OBJECT_MISSING")]
    MigratedPipelineObjectMissing = 29,

    [EnumMember(Value = "MISSING_BLOCKCHAIN_ID")]
    MissingBlockchainId = 30,

    [EnumMember(Value = "MISSING_FEE_OBJECT")]
    MissingFeeObject = 31,

    [EnumMember(Value = "ORDER_OVERDUE")]
    OrderOverdue = 32,

    [EnumMember(Value = "OUT_OF_RANGE_AMOUNT")]
    OutOfRangeAmount = 34,

    [EnumMember(Value = "OUT_OF_RANGE_BALANCE")]
    OutOfRangeBalance = 35,

    [EnumMember(Value = "OUT_OF_RANGE_BATCH_ID")]
    OutOfRangeBatchId = 36,

    [EnumMember(Value = "OUT_OF_RANGE_EXPIRATION_TIMESTAMP")]
    OutOfRangeExpirationTimestamp = 37,

    [EnumMember(Value = "OUT_OF_RANGE_NONCE")]
    OutOfRangeNonce = 38,

    [EnumMember(Value = "OUT_OF_RANGE_ORACLE_PRICE_QUORUM")]
    OutOfRangeOraclePriceQuorum = 39,

    [EnumMember(Value = "OUT_OF_RANGE_ORDER_ID")]
    OutOfRangeOrderId = 40,

    [EnumMember(Value = "OUT_OF_RANGE_POSITIVE_AMOUNT")]
    OutOfRangePositiveAmount = 33,

    [EnumMember(Value = "OUT_OF_RANGE_PUBLIC_KEY")]
    OutOfRangePublicKey = 41,

    [EnumMember(Value = "OUT_OF_RANGE_SIGNATURE_SUBFIELD")]
    OutOfRangeSignatureSubfield = 42,

    [EnumMember(Value = "OUT_OF_RANGE_TOKEN_ID")]
    OutOfRangeTokenId = 43,

    [EnumMember(Value = "OUT_OF_RANGE_VAULT_ID")]
    OutOfRangeVaultId = 44,

    [EnumMember(Value = "REPLACED_BEFORE")]
    ReplacedBefore = 45,

    [EnumMember(Value = "REQUEST_FAILED")]
    RequestFailed = 46,

    [EnumMember(Value = "SCHEMA_VALIDATION_ERROR")]
    SchemaValidationError = 47,

    [EnumMember(Value = "TRANSACTION_PENDING")]
    TransactionPending = 48,
}