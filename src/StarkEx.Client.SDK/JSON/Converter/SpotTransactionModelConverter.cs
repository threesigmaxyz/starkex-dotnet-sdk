namespace StarkEx.Client.SDK.JSON.Converter;

using System.Text.Json;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Models.Spot.TransactionModels;

public class SpotTransactionModelConverter : JsonConverter<TransactionModel>
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
            "MintRequest" => jsonDoc.RootElement.Deserialize<MintModel>(options),
            "SettlementRequest" => jsonDoc.RootElement.Deserialize<SettlementModel>(options),
            "TransferRequest" => jsonDoc.RootElement.Deserialize<TransferModel>(options),
            "DepositRequest" => jsonDoc.RootElement.Deserialize<DepositModel>(options),
            "WithdrawalRequest" => jsonDoc.RootElement.Deserialize<WithdrawalModel>(options),
            "FullWithdrawalRequest" => jsonDoc.RootElement.Deserialize<FullWithdrawalModel>(options),
            "FalseFullWithdrawalRequest" => jsonDoc.RootElement.Deserialize<FalseFullWithdrawalModel>(options),
            "MultiTransactionRequest" => jsonDoc.RootElement.Deserialize<MultiTransactionModel>(options),
            _ => throw new JsonException("'Type' doesn't match a known derived type"),
        };
    }

    public override void Write(Utf8JsonWriter writer, TransactionModel transaction, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, (object)transaction, options);
    }
}