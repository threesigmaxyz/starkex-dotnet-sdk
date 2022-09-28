namespace StarkEx.Client.SDK.JSON.Converter;

using System.Text.Json;
using System.Text.Json.Serialization;
using StarkEx.Client.SDK.Models.Spot.FeederGatewayModels;

public class BatchIdsConverter : JsonConverter<BatchIdsResponseModel>
{
    public override BatchIdsResponseModel Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartArray)
        {
            throw new JsonException($"Found token {reader.TokenType} but expected token {JsonTokenType.StartArray}");
        }

        using var doc = JsonDocument.ParseValue(ref reader);

        var enumerator = doc.RootElement.EnumerateArray();

        return new BatchIdsResponseModel
        {
            BatchIds = enumerator.Select(x => x.GetInt32()).ToList(),
        };
    }

    public override void Write(Utf8JsonWriter writer, BatchIdsResponseModel value, JsonSerializerOptions options)
    {
        throw new NotSupportedException();
    }
}