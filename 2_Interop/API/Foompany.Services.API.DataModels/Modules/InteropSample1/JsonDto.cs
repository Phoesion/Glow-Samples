using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Foompany.Services.API.SampleService2.Modules.InteropSample1.DataModels
{
    //Sample json dto with custom JsonConverter
    public class JsonDto
    {
        public string NormalData { get; set; }

        //custom JsonConverter
        [JsonConverter(typeof(JsonDtodataConverter))]
        public string Data { get; set; }
    }

    public class JsonDtodataConverter : JsonConverter<string>
    {
        public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return "JsonRead : " + reader.GetString();
        }

        public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
        {
            writer.WriteStringValue("JsonWrite : " + value);
        }
    }
}
