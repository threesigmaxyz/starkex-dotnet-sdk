namespace StarkEx.Client.SDK.JSON.Converter;

using System.Globalization;
using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;

// This converts from number to big integer
public class BigIntegerConverter : JsonConverter<BigInteger>
{
    public override BigInteger Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.Number)
        {
            throw new JsonException($"Found token {reader.TokenType} but expected token {JsonTokenType.Number}");
        }

        using var doc = JsonDocument.ParseValue(ref reader);

        return BigInteger.Parse(doc.RootElement.GetRawText(), NumberFormatInfo.InvariantInfo);
    }

    public override void Write(Utf8JsonWriter writer, BigInteger value, JsonSerializerOptions options)
    {
        var s = value.ToString(NumberFormatInfo.InvariantInfo);
        using var doc = JsonDocument.Parse(s);
        doc.WriteTo(writer);
    }
}
