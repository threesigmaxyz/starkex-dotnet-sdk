namespace StarkEx.Client.SDK.Interfaces.Perpetual;

using StarkEx.Client.SDK.Models.Perpetual.AvailabilityModels;

// TODO Add docs
public interface IPerpetualAvailabilityGatewayClient
{
    Task<string> ApproveNewRootsAsync(
        CommitteeSignatureModel committeeSignatureModel,
        CancellationToken cancellationToken);

    Task<PerpetualBatchModel> GetBatchData(
        int batchId,
        CancellationToken cancellationToken);
}