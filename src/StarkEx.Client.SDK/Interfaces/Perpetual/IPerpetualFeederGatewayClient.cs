namespace StarkEx.Client.SDK.Interfaces.Perpetual;

using StarkEx.Client.SDK.Models.Perpetual.ResponseModels;

/// <summary>
///     Perpetual StarkEx API endpoints for feeder interactions.
/// </summary>
public interface IPerpetualFeederGatewayClient
{
    /// <summary>
    /// Get detailed batch information.
    /// </summary>
    /// <param name="batchId">Batch ID to query.</param>
    /// <param name="cancellationToken">Token used for coop cancellation.</param>
    /// <returns>Batch information.</returns>
    Task<BatchInfoResponseModel> GetBatchInfoAsync(
        int batchId,
        CancellationToken cancellationToken);
}