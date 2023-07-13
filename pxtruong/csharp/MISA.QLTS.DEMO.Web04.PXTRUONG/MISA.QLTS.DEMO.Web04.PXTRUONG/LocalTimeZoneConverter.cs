using System.Text.Json;
using System.Text.Json.Serialization;

namespace MISA.QLTS.DEMO.Web04.PXTRUONG
{
    public class LocalTimeZoneConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.Parse(reader.GetString() ?? DateTime.Now.ToString());
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
           
        }
    }
}
