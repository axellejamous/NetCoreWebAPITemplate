using System.Text.Json.Serialization;

namespace NetCoreWebApiTemplateProject.Model
{
    public class ExampleRequestObject
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}
