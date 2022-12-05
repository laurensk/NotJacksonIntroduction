using System.Text.Json;
using System.Text.Json.Serialization;

namespace NotJacksonIntroduction.Converters;

public class DurationConverter : JsonConverter<TimeSpan>
{
    public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => TimeSpan.FromMinutes(reader.GetInt32());

    public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options) => writer.WriteNumberValue(value.Minutes);
}