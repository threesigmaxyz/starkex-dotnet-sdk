namespace StarkEx.Client.SDK.JSON.Converter;

using System.Globalization;
using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;

public class DictionaryStringBigIntegerAsTextConverter : JsonConverter<IDictionary<string, BigInteger>>
{
    public override IDictionary<string, BigInteger> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotSupportedException();
    }

    public override void Write(Utf8JsonWriter writer, IDictionary<string, BigInteger> value, JsonSerializerOptions options)
    {
        var dict = value.ToDictionary(
            k => k.Key,
            k => k.Value.ToString(NumberFormatInfo.InvariantInfo));

        JsonSerializer.Serialize(writer, (IDictionary<string, string>)dict, options);
    }
}