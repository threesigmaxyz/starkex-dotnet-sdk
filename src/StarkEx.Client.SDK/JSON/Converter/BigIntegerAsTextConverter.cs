namespace StarkEx.Client.SDK.JSON.Converter;

using System.Globalization;
using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;

// StarkExApi must serialize number with more than 64 bits (long) as string
// from their BE and convert the string another custom data type that supports number with more than 64 bits.
// Hence why we need this converter
// This convert from string to big integer
public class BigIntegerAsTextConverter : JsonConverter<BigInteger>
{
    public override BigInteger Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.String)
        {
            throw new JsonException($"Found token {reader.TokenType} but expected token {JsonTokenType.String}");
        }

        using var doc = JsonDocument.ParseValue(ref reader);

        return BigInteger.Parse(doc.RootElement.GetString() ?? "0");
    }

    public override void Write(Utf8JsonWriter writer, BigInteger value, JsonSerializerOptions options)
    {
        var s = value.ToString(NumberFormatInfo.InvariantInfo);
        writer.WriteStringValue(s);
    }
}