namespace StarkEx.Client.SDK.Enums.Spot;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

/// <summary>
/// Enum of API codes for the StarkEx Spot API.
/// Uses a JSON string enum converter to serialize and deserialize the values as strings.
/// </summary>
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum SpotApiCodes
{
    /// <summary>
    /// The API function is temporarily disabled.
    /// </summary>
    [EnumMember(Value = "API_FUNCTION_TEMPORARILY_DISABLED")]
    ApiFunctionTemporarilyDisabled = 0,

    /// <summary>
    /// The batch has been aborted.
    /// </summary>
    [EnumMember(Value = "BATCH_ABORTED")]
    BatchAborted = 1,

    /// <summary>
    /// There was a failure while creating the batch.
    /// </summary>
    [EnumMember(Value = "BATCH_CREATION_FAILURE")]
    BatchCreationFailure = 2,

    /// <summary>
    /// The batch is full.
    /// </summary>
    [EnumMember(Value = "BATCH_FULL")]
    BatchFull = 3,

    /// <summary>
    /// The batch is not ready.
    /// </summary>
    [EnumMember(Value = "BATCH_NOT_READY")]
    BatchNotReady = 4,

    /// <summary>
    /// There was a connection error.
    /// </summary>
    [EnumMember(Value = "CONNECTION_ERROR")]
    ConnectionError = 5,

    /// <summary>
    /// There was a duplicate order.
    /// </summary>
    [EnumMember(Value = "DUPLICATE_ORDER")]
    DuplicateOrder = 6,

    /// <summary>
    /// The transactions list in the multi-transaction request was empty.
    /// </summary>

    [EnumMember(Value = "EMPTY_TRANSACTIONS_LIST_IN_MULTI_TRANSACTION")]
    EmptyTransactionsListInMultiTransaction = 7,

    /// <summary>
    /// The fact was not registered.
    /// </summary>
    [EnumMember(Value = "FACT_NOT_REGISTERED")]
    FactNotRegistered = 8,

    /// <summary>
    /// There was an insufficient on-chain balance.
    /// </summary>
    [EnumMember(Value = "INSUFFICIENT_ONCHAIN_BALANCE")]
    InsufficientOnChainBalance = 9,

    /// <summary>
    /// The batch ID was invalid.
    /// </summary>
    [EnumMember(Value = "INVALID_BATCH_ID")]
    InvalidBatchId = 10,

    /// <summary>
    /// The batch migration information was invalid.
    /// </summary>
    [EnumMember(Value = "INVALID_BATCH_MIGRATION_INFO")]
    InvalidBatchMigrationInfo = 11,

    /// <summary>
    /// The claim hash was invalid.
    /// </summary>
    [EnumMember(Value = "INVALID_CLAIM_HASH")]
    InvalidClaimHash = 12,

    /// <summary>
    /// The committee member was invalid.
    /// </summary>
    [EnumMember(Value = "INVALID_COMMITTEE_MEMBER")]
    InvalidCommitteeMember = 13,

    /// <summary>
    /// The contract address was invalid.
    /// </summary>
    [EnumMember(Value = "INVALID_CONTRACT_ADDRESS")]
    InvalidContractAddress = 14,

    /// <summary>
    /// The deployment information was invalid.
    /// </summary>
    [EnumMember(Value = "INVALID_DEPLOYMENT_INFO")]
    InvalidDeploymentInfo = 15,

    /// <summary>
    /// The Ethereum address was invalid.
    /// </summary>
    [EnumMember(Value = "INVALID_ETH_ADDRESS")]
    InvalidEthAddress = 16,

    /// <summary>
    /// The fact was invalid.
    /// </summary>
    [EnumMember(Value = "INVALID_FACT")]
    InvalidFact = 17,

    /// <summary>
    /// The fee taken was invalid.
    /// </summary>
    [EnumMember(Value = "INVALID_FEE_TAKEN")]
    InvalidFeeTaken = 18,

    /// <summary>
    /// The multi-transaction request was invalid.
    /// </summary>
    [EnumMember(Value = "INVALID_MULTI_TRANSACTION")]
    InvalidMultiTransaction = 19,

    /// <summary>
    /// The order ID was invalid.
    /// </summary>
    [EnumMember(Value = "INVALID_ORDER_ID")]
    InvalidOrderId = 20,

    /// <summary>
    /// The order type was invalid.
    /// </summary>
    [EnumMember(Value = "INVALID_ORDER_TYPE")]
    InvalidOrderType = 21,

    /// <summary>
    /// The request was invalid.
    /// </summary>
    [EnumMember(Value = "INVALID_REQUEST")]
    InvalidRequest = 22,

    /// <summary>
    /// The request parameters were invalid.
    /// </summary>
    [EnumMember(Value = "INVALID_REQUEST_PARAMETERS")]
    InvalidRequestParameters = 23,

    /// <summary>
    /// The settlement information was invalid.
    /// </summary>
    [EnumMember(Value = "INVALID_SETTLEMENT_INFO")]
    InvalidSettlementInfo = 24,

    /// <summary>
    /// The settlement ratio was invalid.
    /// </summary>
    [EnumMember(Value = "INVALID_SETTLEMENT_RATIO")]
    InvalidSettlementRatio = 25,

    /// <summary>
    /// The settlement tokens were invalid.
    /// </summary>
    [EnumMember(Value = "INVALID_SETTLEMENT_TOKENS")]
    InvalidSettlementTokens = 26,

    /// <summary>
    /// The signature was invalid.
    /// </summary>
    [EnumMember(Value = "INVALID_SIGNATURE")]
    InvalidSignature = 27,

    /// <summary>
    /// The token type was invalid.
    /// </summary>
    [EnumMember(Value = "INVALID_TOKEN_TYPE")]
    InvalidTokenType = 28,

    /// <summary>
    /// The transaction was invalid.
    /// </summary>
    [EnumMember(Value = "INVALID_TRANSACTION")]
    InvalidTransaction = 29,

    /// <summary>
    /// The transaction ID was invalid.
    /// </summary>
    [EnumMember(Value = "INVALID_TRANSACTION_ID")]
    InvalidTransactionId = 30,

    /// <summary>
    /// The vault was invalid.
    /// </summary>
    [EnumMember(Value = "INVALID_VAULT")]
    InvalidVault = 31,

    /// <summary>
    /// The request was malformed.
    /// </summary>
    [EnumMember(Value = "MALFORMED_REQUEST")]
    MalformedRequest = 32,

    /// <summary>
    /// The migrated pipeline object was missing.
    /// </summary>
    [EnumMember(Value = "MIGRATED_PIPELINE_OBJECT_MISSING")]
    MigratedPipelineObjectMissing = 33,

    /// <summary>
    /// The blockchain ID was missing.
    /// </summary>
    [EnumMember(Value = "MISSING_BLOCKCHAIN_ID")]
    MissingBlockchainId = 34,

    /// <summary>
    /// The fee object was missing.
    /// </summary>
    [EnumMember(Value = "MISSING_FEE_OBJECT")]
    MissingFeeObject = 35,

    /// <summary>
    /// The request contained a nested multi-transaction.
    /// </summary>
    [EnumMember(Value = "NESTED_MULTI_TRANSACTION")]
    NestedMultiTransaction = 36,

    /// <summary>
    /// The order was overdue.
    /// </summary>
    [EnumMember(Value = "ORDER_OVERDUE")]
    OrderOverdue = 37,

    /// <summary>
    /// The amount was out of range.
    /// </summary>
    [EnumMember(Value = "OUT_OF_RANGE_AMOUNT")]
    OutOfRangeAmount = 38,

    /// <summary>
    /// The balance was out of range.
    /// </summary>
    [EnumMember(Value = "OUT_OF_RANGE_BALANCE")]
    OutOfRangeBalance = 39,

    /// <summary>
    /// The batch ID was out of range.
    /// </summary>
    [EnumMember(Value = "OUT_OF_RANGE_BATCH_ID")]
    OutOfRangeBatchId = 40,

    /// <summary>
    /// The Ethereum address was out of range.
    /// </summary>
    [EnumMember(Value = "OUT_OF_RANGE_ETH_ADDRESS")]
    OutOfRangeEthAddress = 41,

    /// <summary>
    /// The expiration timestamp was out of range.
    /// </summary>
    [EnumMember(Value = "OUT_OF_RANGE_EXPIRATION_TIMESTAMP")]
    OutOfRangeExpirationTimestamp = 42,

    /// <summary>
    /// The field element was out of range.
    /// </summary>
    [EnumMember(Value = "OUT_OF_RANGE_FIELD_ELEMENT")]
    OutOfRangeFieldElement = 43,

    /// <summary>
    /// The nonce was out of range.
    /// </summary>
    [EnumMember(Value = "OUT_OF_RANGE_NONCE")]
    OutOfRangeNonce = 44,

    /// <summary>
    /// The oracle price quorum was out of range.
    /// </summary>
    [EnumMember(Value = "OUT_OF_RANGE_ORACLE_PRICE_QUORUM")]
    OutOfRangeOraclePriceQuorum = 45,

    /// <summary>
    /// The order ID was out of range.
    /// </summary>
    [EnumMember(Value = "OUT_OF_RANGE_ORDER_ID")]
    OutOfRangeOrderId = 46,

    /// <summary>
    /// The positive amount was out of range.
    /// </summary>
    [EnumMember(Value = "OUT_OF_RANGE_POSITIVE_AMOUNT")]
    OutOfRangePositiveAmount = 47,

    /// <summary>
    /// The public key was out of range.
    /// </summary>
    [EnumMember(Value = "OUT_OF_RANGE_PUBLIC_KEY")]
    OutOfRangePublicKey = 48,

    /// <summary>
    /// The signature subfield was out of range.
    /// </summary>
    [EnumMember(Value = "OUT_OF_RANGE_SIGNATURE_SUBFIELD")]
    OutOfRangeSignatureSubfield = 49,

    /// <summary>
    /// The token ID was out of range.
    /// </summary>
    [EnumMember(Value = "OUT_OF_RANGE_TOKEN_ID")]
    OutOfRangeTokenId = 50,

    /// <summary>
    /// The vault ID was out of range.
    /// </summary>
    [EnumMember(Value = "OUT_OF_RANGE_VAULT_ID")]
    OutOfRangeVaultId = 51,

    /// <summary>
    /// The transaction was replaced before.
    /// </summary>
    [EnumMember(Value = "REPLACED_BEFORE")]
    ReplacedBefore = 52,

    /// <summary>
    /// The request failed.
    /// </summary>
    [EnumMember(Value = "REQUEST_FAILED")]
    RequestFailed = 53,

    /// <summary>
    /// There was a schema validation error.
    /// </summary>
    [EnumMember(Value = "SCHEMA_VALIDATION_ERROR")]
    SchemaValidationError = 54,

    /// <summary>
    /// The transaction was cancelled.
    /// </summary>
    [EnumMember(Value = "TRANSACTION_CANCELLED")]
    TransactionCancelled = 55,

    /// <summary>
    /// The transaction is pending.
    /// </summary>
    [EnumMember(Value = "TRANSACTION_PENDING")]
    TransactionPending = 56,
}