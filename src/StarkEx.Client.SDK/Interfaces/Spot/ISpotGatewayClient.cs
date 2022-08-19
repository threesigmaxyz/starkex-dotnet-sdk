namespace StarkEx.Client.SDK.Interfaces.Spot;

using StarkEx.Client.SDK.Models.Spot.RequestModels;
using StarkEx.Client.SDK.Models.Spot.ResponseModels;
using StarkEx.Client.SDK.Models.Spot.TransactionModels;

/// <summary>
///     Spot StarkEx API endpoints for external interactions.
/// </summary>
public interface ISpotGatewayClient
{
    /// <summary>
    ///     Gets the next transaction id that all of its predecessors exist in the system.
    ///     If no ids exist in the system - then 0 will be returned.
    ///     While most of the time this implies the next tx_id used should be the returned value, this is not guaranteed, since
    ///     while this value is returned, some new transaction may be written, rendering the returned response irrelevant.
    ///     <para>
    ///         <a
    ///             href="https://starkware.co/starkex-restapi-v4/gateway.html#services.starkex.gateway.gateway.GatewayServiceVersion2.get_first_unused_tx_id" />
    ///     </para>
    /// </summary>
    /// <returns>The next consecutive transaction id.</returns>
    Task<int> GetFirstUnusedTxAsync();

    /// <summary>
    ///     Get the StarkEx contract address.
    ///     This is the address used for registering keys and tokens, and performing on-chain deposits and withdrawals.
    ///     <para>
    ///         <a
    ///             href="https://starkware.co/starkex-restapi-v4/gateway.html#services.starkex.gateway.gateway.GatewayServiceVersion2.get_stark_dex_address" />
    ///     </para>
    /// </summary>
    /// <returns>The on-chain StarkEx contract address.</returns>
    Task<string> GetStarkDexAddress();

    /// <summary>
    ///     Get the time (in seconds) that the tx id following the last tx id accepted on-chain has spent in the system.
    ///     Returns -1 if no such transaction id exists.
    ///     <para>
    ///         <a
    ///             href="https://starkware.co/starkex-restapi-v4/gateway.html#services.starkex.gateway.gateway.GatewayServiceVersion2.get_time_spent_by_oldest_unaccepted_tx_in_system" />
    ///     </para>
    /// </summary>
    /// <returns>The time spent in the system of the next tx id which was not accepted on-chain.</returns>
    Task<int> GetTimeSpentByOldestUnacceptedTxInSystem();

    /// <summary>
    ///     Get specific a transaction’s information.
    ///     <para>
    ///         <a
    ///             href="https://starkware.co/starkex-restapi-v4/gateway.html#services.starkex.gateway.gateway.GatewayServiceVersion2.get_transaction" />
    ///     </para>
    /// </summary>
    /// <param name="txId">Transaction ID to query.</param>
    /// <returns>Information about the queried transaction.</returns>
    Task<TransactionModel> GetTransactionAsync(int txId);

    /// <summary>
    ///     Send a new transaction to StarkEx. This function handles all types of StarkEx transactions.
    /// </summary>
    /// <param name="mintRequestModel">Representation for a MintRequestModel.</param>
    /// <returns>Transaction Response Model.</returns>
    Task<ResponseModel> AddTransactionAsync(MintRequestModel mintRequestModel);

    /// <summary>
    ///     Send a new transaction to StarkEx. This function handles all types of StarkEx transactions.
    /// </summary>
    /// <param name="settlementRequestModel">Representation for a SettlementRequestModel.</param>
    /// <returns>Transaction Response Model.</returns>
    Task<ResponseModel> AddTransactionAsync(SettlementRequestModel settlementRequestModel);

    /// <summary>
    ///     Send a new transaction to StarkEx. This function handles all types of StarkEx transactions.
    /// </summary>
    /// <param name="transferRequestModel">Representation for a TransferRequestModel.</param>
    /// <returns>Transaction Response Model.</returns>
    Task<ResponseModel> AddTransactionAsync(TransferRequestModel transferRequestModel);

    /// <summary>
    ///     Send a new transaction to StarkEx. This function handles all types of StarkEx transactions.
    /// </summary>
    /// <param name="depositRequestModel">Representation for a DepositRequestModel.</param>
    /// <returns>Transaction Response Model.</returns>
    Task<ResponseModel> AddTransactionAsync(DepositRequestModel depositRequestModel);

    /// <summary>
    ///     Send a new transaction to StarkEx. This function handles all types of StarkEx transactions.
    /// </summary>
    /// <param name="withdrawalRequestModel">Representation for a WithdrawalRequestModel.</param>
    /// <returns>Transaction Response Model.</returns>
    Task<ResponseModel> AddTransactionAsync(WithdrawalRequestModel withdrawalRequestModel);

    /// <summary>
    ///     Send a new transaction to StarkEx. This function handles all types of StarkEx transactions.
    /// </summary>
    /// <param name="fullWithdrawalRequestModel">Representation for a FullWithdrawalRequestModel.</param>
    /// <returns>Transaction Response Model.</returns>
    Task<ResponseModel> AddTransactionAsync(FullWithdrawalRequestModel fullWithdrawalRequestModel);

    /// <summary>
    ///     Send a new transaction to StarkEx. This function handles all types of StarkEx transactions.
    /// </summary>
    /// <param name="falseFullWithdrawalRequestModel">Representation for a FalseFullWithdrawalRequestModel.</param>
    /// <returns>Transaction Response Model.</returns>
    Task<ResponseModel> AddTransactionAsync(FalseFullWithdrawalRequestModel falseFullWithdrawalRequestModel);

    /// <summary>
    ///     Send a new transaction to StarkEx. This function handles all types of StarkEx transactions.
    /// </summary>
    /// <param name="multiTransactionRequestModel">Representation for a MultiTransactionRequestModel.</param>
    /// <returns>Transaction Response Model.</returns>
    Task<ResponseModel> AddTransactionAsync(MultiTransactionRequestModel multiTransactionRequestModel);
}