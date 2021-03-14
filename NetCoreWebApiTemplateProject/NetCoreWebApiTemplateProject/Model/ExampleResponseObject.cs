using System.Text.Json.Serialization;

namespace NetCoreWebApiTemplateProject.Model
{
    public class ExampleResponseObject
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}
