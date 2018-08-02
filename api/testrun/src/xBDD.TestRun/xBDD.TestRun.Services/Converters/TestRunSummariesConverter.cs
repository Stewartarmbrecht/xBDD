using System;
using xBDD.TestRun.Services.Models.Responses;
using Newtonsoft.Json;

namespace xBDD.TestRun.Services.Converters
{
    public class TestRunSummariesConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(TestRunSummaries));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            foreach (var summary in (TestRunSummaries)value)
            {
                writer.WritePropertyName(summary.Id);
                summary.Id = null;
                serializer.Serialize(writer, summary);
            }
            writer.WriteEndObject();
        }
        
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
