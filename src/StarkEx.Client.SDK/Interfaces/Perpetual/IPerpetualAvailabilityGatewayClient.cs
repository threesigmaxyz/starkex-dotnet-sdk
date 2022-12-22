namespace StarkEx.Client.SDK.Interfaces.Perpetual;

using StarkEx.Client.SDK.Models.Perpetual.AvailabilityModels;

/// <summary>
///     Perpetual StarkEx API endpoints for data availability committee interactions.
/// </summary>
public interface IPerpetualAvailabilityGatewayClient
{
    /// <summary>
    ///     Process committee signature for a batch.
    ///     <para>
    ///         <a
    ///             href="https://starkware.co/starkex-perpetual-api-v2/availability_gateway.html#services.perpetual.availability_gateway.availability_gateway.AvailabilityGateway.approve_new_roots" />
    ///     </para>
    /// </summary>
    /// <param name="committeeSignatureModel">Committee signature data.</param>
    /// <param name="cancellationToken">Token used for coop cancellation.</param>
    /// <returns>Signature acknowledgement.</returns>
    Task<string> ApproveNewRootsAsync(
        CommitteeSignatureModel committeeSignatureModel,
        CancellationToken cancellationToken);

    /// <summary>
    /// Get the data availability information for a specific batch.
    /// The availability information includes the ID of the previous batch in chronological order and the list of Merkle
    /// leaves (positions and orders) that were modified in the requested batch.
    /// prev_batch_id of -1 indicates that there is no previous state.
    /// Note that prev_batch_id might differ from batch_id - 1. This happens when a previously submitted batch is
    /// rejected on-chain.
    /// </summary>
    /// <param name="batchId">Batch ID to query.</param>
    /// <param name="cancellationToken">Token used for coop cancellation.</param>
    /// <returns>Batch information.</returns>
    Task<PerpetualBatchModel> GetBatchDataAsync(
        int batchId,
        CancellationToken cancellationToken);
}
