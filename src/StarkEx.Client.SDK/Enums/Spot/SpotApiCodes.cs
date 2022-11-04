namespace StarkEx.Client.SDK.Enums.Spot;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum SpotApiCodes
{
    [EnumMember(Value = "API_FUNCTION_TEMPORARILY_DISABLED")]
    ApiFunctionTemporarilyDisabled = 0,

    [EnumMember(Value = "BATCH_ABORTED")]
    BatchAborted = 1,

    [EnumMember(Value = "BATCH_CREATION_FAILURE")]
    BatchCreationFailure = 2,

    [EnumMember(Value = "BATCH_FULL")]
    BatchFull = 3,

    [EnumMember(Value = "BATCH_NOT_READY")]
    BatchNotReady = 4,

    [EnumMember(Value = "CONNECTION_ERROR")]
    ConnectionError = 5,

    [EnumMember(Value = "DUPLICATE_ORDER")]
    DuplicateOrder = 6,

    [EnumMember(Value = "EMPTY_TRANSACTIONS_LIST_IN_MULTI_TRANSACTION")]
    EmptyTransactionsListInMultiTransaction = 7,

    [EnumMember(Value = "FACT_NOT_REGISTERED")]
    FactNotRegistered = 8,

    [EnumMember(Value = "INSUFFICIENT_ONCHAIN_BALANCE")]
    InsufficientOnChainBalance = 9,

    [EnumMember(Value = "INVALID_BATCH_ID")]
    InvalidBatchId = 10,

    [EnumMember(Value = "INVALID_BATCH_MIGRATION_INFO")]
    InvalidBatchMigrationInfo = 11,

    [EnumMember(Value = "INVALID_CLAIM_HASH")]
    InvalidClaimHash = 12,

    [EnumMember(Value = "INVALID_COMMITTEE_MEMBER")]
    InvalidCommitteeMember = 13,

    [EnumMember(Value = "INVALID_CONTRACT_ADDRESS")]
    InvalidContractAddress = 14,

    [EnumMember(Value = "INVALID_DEPLOYMENT_INFO")]
    InvalidDeploymentInfo = 15,

    [EnumMember(Value = "INVALID_ETH_ADDRESS")]
    InvalidEthAddress = 16,

    [EnumMember(Value = "INVALID_FACT")]
    InvalidFact = 17,

    [EnumMember(Value = "INVALID_FEE_TAKEN")]
    InvalidFeeTaken = 18,

    [EnumMember(Value = "INVALID_MULTI_TRANSACTION")]
    InvalidMultiTransaction = 19,

    [EnumMember(Value = "INVALID_ORDER_ID")]
    InvalidOrderId = 20,

    [EnumMember(Value = "INVALID_ORDER_TYPE")]
    InvalidOrderType = 21,

    [EnumMember(Value = "INVALID_REQUEST")]
    InvalidRequest = 22,

    [EnumMember(Value = "INVALID_REQUEST_PARAMETERS")]
    InvalidRequestParameters = 23,

    [EnumMember(Value = "INVALID_SETTLEMENT_INFO")]
    InvalidSettlementInfo = 24,

    [EnumMember(Value = "INVALID_SETTLEMENT_RATIO")]
    InvalidSettlementRatio = 25,

    [EnumMember(Value = "INVALID_SETTLEMENT_TOKENS")]
    InvalidSettlementTokens = 26,

    [EnumMember(Value = "INVALID_SIGNATURE")]
    InvalidSignature = 27,

    [EnumMember(Value = "INVALID_TOKEN_TYPE")]
    InvalidTokenType = 28,

    [EnumMember(Value = "INVALID_TRANSACTION")]
    InvalidTransaction = 29,

    [EnumMember(Value = "INVALID_TRANSACTION_ID")]
    InvalidTransactionId = 30,

    [EnumMember(Value = "INVALID_VAULT")]
    InvalidVault = 31,

    [EnumMember(Value = "MALFORMED_REQUEST")]
    MalformedRequest = 32,

    [EnumMember(Value = "MIGRATED_PIPELINE_OBJECT_MISSING")]
    MigratedPipelineObjectMissing = 33,

    [EnumMember(Value = "MISSING_BLOCKCHAIN_ID")]
    MissingBlockchainId = 34,

    [EnumMember(Value = "MISSING_FEE_OBJECT")]
    MissingFeeObject = 35,

    [EnumMember(Value = "NESTED_MULTI_TRANSACTION")]
    NestedMultiTransaction = 36,

    [EnumMember(Value = "ORDER_OVERDUE")]
    OrderOverdue = 37,

    [EnumMember(Value = "OUT_OF_RANGE_AMOUNT")]
    OutOfRangeAmount = 38,

    [EnumMember(Value = "OUT_OF_RANGE_BALANCE")]
    OutOfRangeBalance = 39,

    [EnumMember(Value = "OUT_OF_RANGE_BATCH_ID")]
    OutOfRangeBatchId = 40,

    [EnumMember(Value = "OUT_OF_RANGE_ETH_ADDRESS")]
    OutOfRangeEthAddress = 41,

    [EnumMember(Value = "OUT_OF_RANGE_EXPIRATION_TIMESTAMP")]
    OutOfRangeExpirationTimestamp = 42,

    [EnumMember(Value = "OUT_OF_RANGE_FIELD_ELEMENT")]
    OutOfRangeFieldElement = 43,

    [EnumMember(Value = "OUT_OF_RANGE_NONCE")]
    OutOfRangeNonce = 44,

    [EnumMember(Value = "OUT_OF_RANGE_ORACLE_PRICE_QUORUM")]
    OutOfRangeOraclePriceQuorum = 45,

    [EnumMember(Value = "OUT_OF_RANGE_ORDER_ID")]
    OutOfRangeOrderId = 46,

    [EnumMember(Value = "OUT_OF_RANGE_POSITIVE_AMOUNT")]
    OutOfRangePositiveAmount = 47,

    [EnumMember(Value = "OUT_OF_RANGE_PUBLIC_KEY")]
    OutOfRangePublicKey = 48,

    [EnumMember(Value = "OUT_OF_RANGE_SIGNATURE_SUBFIELD")]
    OutOfRangeSignatureSubfield = 49,

    [EnumMember(Value = "OUT_OF_RANGE_TOKEN_ID")]
    OutOfRangeTokenId = 50,

    [EnumMember(Value = "OUT_OF_RANGE_VAULT_ID")]
    OutOfRangeVaultId = 51,

    [EnumMember(Value = "REPLACED_BEFORE")]
    ReplacedBefore = 52,

    [EnumMember(Value = "REQUEST_FAILED")]
    RequestFailed = 53,

    [EnumMember(Value = "SCHEMA_VALIDATION_ERROR")]
    SchemaValidationError = 54,

    [EnumMember(Value = "TRANSACTION_CANCELLED")]
    TransactionCancelled = 55,

    [EnumMember(Value = "TRANSACTION_PENDING")]
    TransactionPending = 56,
}