namespace StarkEx.Client.SDK.Interfaces.Perpetual;

using StarkEx.Client.SDK.Models.Perpetual.ResponseModels;

public interface IPerpetualFeederGatewayClient
{
    Task<BatchInfoResponseModel> GetBatchInfoAsync(int batchId);
}