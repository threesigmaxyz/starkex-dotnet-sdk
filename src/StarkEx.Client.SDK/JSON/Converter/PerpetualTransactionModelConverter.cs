namespace StarkEx.Client.SDK.JSON.Converter;

using System.Text.Json;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Models.Perpetual.TransactionModels;

public class PerpetualTransactionModelConverter : JsonConverter<TransactionModel>
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeof(TransactionModel).IsAssignableFrom(typeToConvert);
    }

    public override TransactionModel Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDoc = JsonDocument.ParseValue(ref reader);

        return jsonDoc.RootElement.GetProperty("type").GetString() switch
        {
            "CONDITIONAL_TRANSFER" => jsonDoc.RootElement.Deserialize<ConditionalTransferModel>(options),
            "DELEVERAGE" => jsonDoc.RootElement.Deserialize<DeleverageModel>(options),
            "FORCED_TRADE" => jsonDoc.RootElement.Deserialize<ForcedTradeModel>(options),
            "FORCED_WITHDRAWAL" => jsonDoc.RootElement.Deserialize<ForcedWithdrawalModel>(options),
            "FUNDING_TICK" => jsonDoc.RootElement.Deserialize<FundingTickModel>(options),
            "LIQUIDATE" => jsonDoc.RootElement.Deserialize<LiquidateModel>(options),
            "ORACLE_PRICES_TICK" => jsonDoc.RootElement.Deserialize<OraclePricesTickModel>(options),
            "DEPOSIT" => jsonDoc.RootElement.Deserialize<DepositModel>(options),
            "MULTI_TRANSACTION" => jsonDoc.RootElement.Deserialize<MultiTransactionModel>(options),
            "TRANSFER" => jsonDoc.RootElement.Deserialize<TransferModel>(options),
            "WITHDRAWAL" => jsonDoc.RootElement.Deserialize<WithdrawalModel>(options),
            "TRADE" => jsonDoc.RootElement.Deserialize<TradeModel>(options),
            "WITHDRAWAL_TO_ADDRESS" => jsonDoc.RootElement.Deserialize<WithdrawalToAddressModel>(options),
            _ => throw new JsonException("'Type' doesn't match a known derived type"),
        };
    }

    public override void Write(Utf8JsonWriter writer, TransactionModel transaction, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, (object)transaction, options);
    }
}
