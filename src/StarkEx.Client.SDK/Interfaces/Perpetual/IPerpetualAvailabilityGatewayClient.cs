namespace StarkEx.Client.SDK.Interfaces.Perpetual;

using StarkEx.Client.SDK.Models.Perpetual.AvailabilityModels;

public interface IPerpetualAvailabilityGatewayClient
{
    Task<string> ApproveNewRootsAsync(CommitteeSignatureModel committeeSignatureModel);

    Task<PerpetualBatchModel> GetBatchData(int batchId);
}