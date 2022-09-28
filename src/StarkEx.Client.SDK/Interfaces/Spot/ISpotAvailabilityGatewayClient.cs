namespace StarkEx.Client.SDK.Interfaces.Spot;

using StarkEx.Client.SDK.Models.Spot.AvailabilityGateway;

/// <summary>
///     Spot StarkEx API endpoints for data availability committee interactions.
/// </summary>
public interface ISpotAvailabilityGatewayClient
{
    /// <summary>
    ///     Process committee signature for a batch.
    ///     <para>
    ///         <a
    ///             href="https://starkware.co/starkex-restapi-v4/availability_gateway.html#services.starkex.availability_gateway.availability_gateway.AvailabilityGateway.approve_new_roots" />
    ///     </para>
    /// </summary>
    /// <param name="committeeSignature">Committee signature data.</param>
    /// <param name="cancellationToken">Token used for coop cancellation.</param>
    /// <returns>Signature acknowledgement.</returns>
    Task<bool> ApproveNewRootsAsync(
        CommitteeSignatureModel committeeSignature,
        CancellationToken cancellationToken);

    /// <summary>
    ///     Get the data availability information for a specific batch.
    ///     The availability information includes the ID of the previous batch in chronological order and the list of tree
    ///     leaves (Validium vaults tree and orders tree) that were modified in the requested batch.
    ///     If validate_rollup is set to True, the list of rollup vault tree leaves that were modified is also returned.
    ///     A prev_batch_id of -1 indicates that there is no previous state.
    ///     Note that prev_batch_id might differ from batch_id -1.
    ///     This happens when a previously submitted batch is rejected on-chain.
    ///     <para>
    ///         <a
    ///             href="https://starkware.co/starkex/api/v4/availability_gateway.html#services.starkex.availability_gateway.availability_gateway.AvailabilityGateway.get_batch_data" />
    ///     </para>
    /// </summary>
    /// <param name="batchId">Batch ID to query.</param>
    /// <param name="validateRollup">Whether or not to respond with rollup vault modification data.</param>
    /// <param name="cancellationToken">Token used for coop cancellation.</param>
    /// <returns>Batch information.</returns>
    Task<BatchModel> GetBatchDataAsync(
        int batchId,
        bool validateRollup,
        CancellationToken cancellationToken);

    /// <summary>
    ///     Query the API for the height of the order tree.
    ///     <para>
    ///         <a
    ///             href="https://starkware.co/starkex-restapi-v4/availability_gateway.html#services.starkex.availability_gateway.availability_gateway.AvailabilityGateway.order_tree_height" />
    ///     </para>
    /// </summary>
    /// <param name="cancellationToken">Token used for coop cancellation.</param>
    /// <returns>Height of the order tree.</returns>
    Task<int> GetOrderTreeHeightAsync(CancellationToken cancellationToken);

    // TODO Task<bool> InitDummyBatchStateUpdate(bool withRollup);
    // TODO Task UpdateSignedBatches();
}