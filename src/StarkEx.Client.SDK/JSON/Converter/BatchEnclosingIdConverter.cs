namespace StarkEx.Client.SDK.JSON.Converter;

using System.Text.Json;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Models.Spot.FeederGatewayModels;

public class BatchEnclosingIdConverter : JsonConverter<BatchEnclosingIdResponseModel>
{
    public override BatchEnclosingIdResponseModel Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartArray)
        {
            throw new JsonException($"Found token {reader.TokenType} but expected token {JsonTokenType.StartArray}");
        }

        using var doc = JsonDocument.ParseValue(ref reader);
        var enumerator = doc.RootElement.EnumerateArray();

        if (enumerator.Count() != 2)
        {
            throw new JsonException($"Found length {enumerator.Count()} but expected token 2");
        }

        return new BatchEnclosingIdResponseModel
        {
            FirstId = enumerator.First().GetInt32(),
            LastId = enumerator.Last().GetInt32(),
        };
    }

    public override void Write(Utf8JsonWriter writer, BatchEnclosingIdResponseModel value, JsonSerializerOptions options)
    {
        throw new NotSupportedException();
    }
}
