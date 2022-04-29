using System.Text.Json.Serialization;

namespace TheWeatherApp.Shared.Models
{
    public class WeatherResponse
    {
        [JsonPropertyName("name")]
        public string LocationName { get; set; }

        [JsonPropertyName("weather")]
        public List<Weather> WeatherDetails { get; set; }

        [JsonPropertyName("main")]
        public Temperature Temperature { get; set; }

        [JsonPropertyName("sys")]
        public Suntime Suntime { get; set; }
    } 
}