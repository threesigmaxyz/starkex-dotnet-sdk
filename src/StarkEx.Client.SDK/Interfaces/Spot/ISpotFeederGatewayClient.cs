namespace StarkEx.Client.SDK.Interfaces.Spot;

using StarkEx.Client.SDK.Models.Spot.FeederGatewayModels;

/// <summary>
///     Spot StarkEx API endpoints for feeder interactions.
/// </summary>
public interface ISpotFeederGatewayClient
{
    /// <summary>
    ///     Gets The first and last transaction IDs for the input batch_id.
    ///     <para>
    ///         <a
    ///             href="https://starkware.co/starkex-restapi-v4/feeder_gateway.html#services.starkex.feeder_gateway.feeder_gateway.FeederGateway.get_batch_enclosing_ids" />
    ///     </para>
    /// </summary>
    /// <param name="batchId">Batch Id to query.</param>
    /// <param name="cancellationToken">Token used for coop cancellation.</param>
    /// <returns>First and last transaction ID of batch.</returns>
    Task<BatchEnclosingIdResponseModel> GetBatchEnclosingIdsAsync(
        int batchId,
        CancellationToken cancellationToken);

    /// <summary>
    ///     Get a list of batch IDs matching the input vaults root, orders root and sequence number.
    ///     <para>
    ///         <a
    ///             href="https://starkware.co/starkex-restapi-v4/feeder_gateway.html#services.starkex.feeder_gateway.feeder_gateway.FeederGateway.get_batch_ids" />
    ///     </para>
    /// </summary>
    /// <param name="vaultRoot">Vaults root to query.</param>
    /// <param name="orderRoot">Orders root to query.</param>
    /// <param name="sequenceNumber">Sequence number to query.</param>
    /// <param name="cancellationToken">Token used for coop cancellation.</param>
    /// <returns>List of batch IDs.</returns>
    Task<BatchIdsResponseModel> GetBatchIdsAsync(
        string vaultRoot,
        string orderRoot,
        int sequenceNumber,
        CancellationToken cancellationToken);

    /// <summary>
    ///     Get detailed batch information. Note that order roots can either be Merkle Trees or Patricia Trees.
    ///     If the batch was created prior the upgrade to V4.5 the roots will be of a Merkle tree, otherwise the roots will be
    ///     of a Patrica tree.
    ///     <para>
    ///         <a
    ///             href="https://starkware.co/starkex-restapi-v4/feeder_gateway.html#services.starkex.feeder_gateway.feeder_gateway.FeederGateway.get_batch_info" />
    ///     </para>
    /// </summary>
    /// <param name="batchId">Batch Id to query.</param>
    /// <param name="cancellationToken">Token used for coop cancellation.</param>
    /// <returns>Batch information.</returns>
    Task<BatchInfoResponseModel> GetBatchInfoAsync(
        int batchId,
        CancellationToken cancellationToken);

    /// <summary>
    ///     Get detailed batch information. Simpler response version to GetBatchInfoASync request.
    ///     <para>
    ///         <a
    ///             href="https://starkware.co/starkex-restapi-v4/feeder_gateway.html#services.starkex.feeder_gateway.feeder_gateway.FeederGateway.get_batch_info_version2" />
    ///     </para>
    /// </summary>
    /// <param name="batchId">Batch Id to query.</param>
    /// <param name="cancellationToken">Token used for coop cancellation.</param>
    /// <returns>Batch information.</returns>
    Task<BatchInfoV2ResponseModel> GetBatchInfoV2Async(
        int batchId,
        CancellationToken cancellationToken);

    /// <summary>
    ///     Returns the blockchain ID used by the system.
    ///     <para>
    ///         <a
    ///             href="https://starkware.co/starkex-restapi-v4/feeder_gateway.html#services.starkex.feeder_gateway.feeder_gateway.FeederGateway.get_l1_blockchain_id" />
    ///     </para>
    /// </summary>
    /// <param name="cancellationToken">Token used for coop cancellation.</param>
    /// <returns>Blockchain ID.</returns>
    Task<int> GetChainIdAsync(CancellationToken cancellationToken);

    /// <summary>
    ///     Get the last batch id used by StarkEx.
    ///     <para>
    ///         <a
    ///             href="https://starkware.co/starkex-restapi-v4/feeder_gateway.html#services.starkex.feeder_gateway.feeder_gateway.FeederGateway.get_last_batch_id" />
    ///     </para>
    /// </summary>
    /// <param name="cancellationToken">Token used for coop cancellation.</param>
    /// <returns>Last batch id.</returns>
    Task<int> GetLastBatchIdAsync(CancellationToken cancellationToken);

    /// <summary>
    ///     Get the previous batch id for the input batch_id.
    ///     <para>
    ///         <a
    ///             href="https://starkware.co/starkex-restapi-v4/feeder_gateway.html#services.starkex.feeder_gateway.feeder_gateway.FeederGateway.get_prev_batch_id" />
    ///     </para>
    /// </summary>
    /// <param name="batchId">Batch ID to query.</param>
    /// <param name="cancellationToken">Token used for coop cancellation.</param>
    /// <returns>Previous batch id.</returns>
    Task<int> GetPrevBatchIdRequestAsync(
        int batchId,
        CancellationToken cancellationToken);

    /// <summary>
    ///     Checks if the server is alive.
    ///     <para>
    ///         <a
    ///             href="https://starkware.co/starkex-restapi-v4/feeder_gateway.html#services.starkex.feeder_gateway.feeder_gateway.FeederGateway.is_alive" />
    ///     </para>
    /// </summary>
    /// <param name="cancellationToken">Token used for coop cancellation.</param>
    /// <returns>Server alive status.</returns>
    Task<bool> GetIsAliveAsync(CancellationToken cancellationToken);

    /// <summary>
    ///     Checks if the server is ready.
    ///     <para>
    ///         <a
    ///             href="https://starkware.co/starkex-restapi-v4/feeder_gateway.html#services.starkex.feeder_gateway.feeder_gateway.FeederGateway.is_ready" />
    ///     </para>
    /// </summary>
    /// <param name="cancellationToken">Token used for coop cancellation.</param>
    /// <returns>Server ready status.</returns>
    Task<bool> GetIsReadyAsync(CancellationToken cancellationToken);
}