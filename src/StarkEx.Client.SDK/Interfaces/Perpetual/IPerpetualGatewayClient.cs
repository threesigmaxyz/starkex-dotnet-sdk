namespace StarkEx.Client.SDK.Interfaces.Perpetual;

using StarkEx.Client.SDK.Models.Perpetual.RequestModels;
using StarkEx.Client.SDK.Models.Perpetual.ResponseModels;

/// <summary>
///     Perpetual StarkEx API endpoints for external interactions.
/// </summary>
public interface IPerpetualGatewayClient
{
    /// <summary>
    /// Gets the next transaction id that all of its predecessors exist in the system. If no ids exist in the system -
    /// then 0 will be returned.
    /// While most of the time this implies the next tx_id used should be the returned value, this is not guaranteed,
    /// since while this value is returned, some new transaction may be written, rendering the returned response irrelevant.
    /// </summary>
    /// <param name="cancellationToken">Token used for coop cancellation.</param>
    /// <returns>The next consecutive tx_id, all of its predecessors exist in our system.</returns>
    Task<int> GetFirstUnusedTxAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Send a new transaction to StarkEx. This function handles all types of StarkEx transactions.
    /// </summary>
    /// <typeparam name="T">Request model type.</typeparam>
    /// <param name="requestModel">Representation for a RequestModel.</param>
    /// <param name="cancellationToken">Token used for coop cancellation.</param>
    /// <returns>Transaction Response Model.</returns>
    Task<TransactionResponseModel> AddTransactionAsync<T>(
        T requestModel,
        CancellationToken cancellationToken)
        where T : BaseRequestModel;
}