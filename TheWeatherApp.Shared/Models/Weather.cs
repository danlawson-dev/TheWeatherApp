using System.Text.Json.Serialization;

namespace TheWeatherApp.Shared.Models
{
    public class Weather
    {
        [JsonPropertyName("main")]
        public string Type { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }
    }
}