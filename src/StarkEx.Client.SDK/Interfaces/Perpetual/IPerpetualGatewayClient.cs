namespace StarkEx.Client.SDK.Interfaces.Perpetual;

using StarkEx.Client.SDK.Models.Perpetual.RequestModels;
using StarkEx.Client.SDK.Models.Perpetual.ResponseModels;

public interface IPerpetualGatewayClient
{
    Task<int> GetFirstUnusedTxAsync();

    Task<TransactionResponseModel> AddTransactionAsync(ConditionalTransferRequestModel conditionalTransferRequestModel);

    Task<TransactionResponseModel> AddTransactionAsync(DeleverageRequestModel deleverageRequestModel);

    Task<TransactionResponseModel> AddTransactionAsync(DepositRequestModel depositRequestModel);

    Task<TransactionResponseModel> AddTransactionAsync(ForcedTradeRequestModel forcedTradeRequestModel);

    Task<TransactionResponseModel> AddTransactionAsync(ForcedWithdrawalRequestModel forcedTradeRequestModel);

    Task<TransactionResponseModel> AddTransactionAsync(FundingTickRequestModel fundingTickRequestModel);

    Task<TransactionResponseModel> AddTransactionAsync(LiquidateRequestModel liquidateRequestModel);

    Task<TransactionResponseModel> AddTransactionAsync(MultiTransactionRequestModel multiTransactionRequestModel);

    Task<TransactionResponseModel> AddTransactionAsync(OraclePricesTickRequestModel oraclePricesTickRequestModel);

    Task<TransactionResponseModel> AddTransactionAsync(TradeRequestModel tradeRequestModel);

    Task<TransactionResponseModel> AddTransactionAsync(TransferRequestModel transferRequestModel);

    Task<TransactionResponseModel> AddTransactionAsync(WithdrawalRequestModel withdrawalRequestModel);

    Task<TransactionResponseModel> AddTransactionAsync(WithdrawalToAddressRequestModel withdrawalToAddressRequestModel);
}