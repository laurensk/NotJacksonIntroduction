using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NotJacksonIntroduction.Converters;

public class JsonDateTimeFormat : JsonConverterAttribute
{
    private readonly string _format;

    public JsonDateTimeFormat(string format)
    {
        _format = format;
    }

    public override JsonConverter? CreateConverter(Type typeToConvert)
    {
        if (typeToConvert != typeof(DateTime))
            throw new Exception("Can only use this attribute on DateTime properties.");

        return new DateOfExamConverter(_format);
    }

    private class DateOfExamConverter : JsonConverter<DateTime>
    {
        private readonly string _format;

        public DateOfExamConverter(string format)
        {
            _format = format;
        }

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => DateTime.ParseExact(reader.GetString()!, _format, CultureInfo.InvariantCulture);

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options) => writer.WriteStringValue(value.ToString(_format));
    }
}