namespace StarkEx.Client.SDK.Interfaces.Perpetual;

using StarkEx.Client.SDK.Models.Perpetual.RequestModels;
using StarkEx.Client.SDK.Models.Perpetual.ResponseModels;

// TODO Add docs
public interface IPerpetualGatewayClient
{
    Task<int> GetFirstUnusedTxAsync(CancellationToken cancellationToken);

    Task<TransactionResponseModel> AddTransactionAsync<T>(
        T requestModel,
        CancellationToken cancellationToken)
        where T : BaseRequestModel;
}