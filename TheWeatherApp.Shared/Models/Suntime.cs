using System.Text.Json.Serialization;

namespace TheWeatherApp.Shared.Models
{
    public class Suntime
    {
        [JsonPropertyName("sunrise")]
        public double Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public double Sunset { get; set; }
    }
}