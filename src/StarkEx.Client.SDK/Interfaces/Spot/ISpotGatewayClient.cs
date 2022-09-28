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
    /// <param name="cancellationToken">Token used for coop cancellation.</param>
    /// <returns>The next consecutive transaction id.</returns>
    Task<int> GetFirstUnusedTxAsync(CancellationToken cancellationToken);

    /// <summary>
    ///     Get the StarkEx contract address.
    ///     This is the address used for registering keys and tokens, and performing on-chain deposits and withdrawals.
    ///     <para>
    ///         <a
    ///             href="https://starkware.co/starkex-restapi-v4/gateway.html#services.starkex.gateway.gateway.GatewayServiceVersion2.get_stark_dex_address" />
    ///     </para>
    /// </summary>
    /// <param name="cancellationToken">Token used for coop cancellation.</param>
    /// <returns>The on-chain StarkEx contract address.</returns>
    Task<string> GetStarkDexAddress(CancellationToken cancellationToken);

    /// <summary>
    ///     Get the time (in seconds) that the tx id following the last tx id accepted on-chain has spent in the system.
    ///     Returns -1 if no such transaction id exists.
    ///     <para>
    ///         <a
    ///             href="https://starkware.co/starkex-restapi-v4/gateway.html#services.starkex.gateway.gateway.GatewayServiceVersion2.get_time_spent_by_oldest_unaccepted_tx_in_system" />
    ///     </para>
    /// </summary>
    /// <param name="cancellationToken">Token used for coop cancellation.</param>
    /// <returns>The time spent in the system of the next tx id which was not accepted on-chain.</returns>
    Task<int> GetTimeSpentByOldestUnacceptedTxInSystem(CancellationToken cancellationToken);

    /// <summary>
    ///     Get specific a transaction’s information.
    ///     <para>
    ///         <a
    ///             href="https://starkware.co/starkex-restapi-v4/gateway.html#services.starkex.gateway.gateway.GatewayServiceVersion2.get_transaction" />
    ///     </para>
    /// </summary>
    /// <param name="txId">Transaction ID to query.</param>
    /// <param name="cancellationToken">Token used for coop cancellation.</param>
    /// <returns>Information about the queried transaction.</returns>
    Task<TransactionModel> GetTransactionAsync(int txId, CancellationToken cancellationToken);

    /// <summary>
    ///     Send a new transaction to StarkEx. This function handles all types of StarkEx transactions.
    /// </summary>
    /// <typeparam name="T">Request model type.</typeparam>
    /// <param name="requestModel">Representation for a MintRequestModel.</param>
    /// <param name="cancellationToken">Token used for coop cancellation.</param>
    /// <returns>Transaction Response Model.</returns>
    Task<ResponseModel> AddTransactionAsync<T>(T requestModel, CancellationToken cancellationToken)
        where T : BaseRequestModel;
}