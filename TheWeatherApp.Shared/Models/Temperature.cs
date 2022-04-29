using System.Text.Json.Serialization;

namespace TheWeatherApp.Shared.Models
{
    public class Temperature
    {
        [JsonPropertyName("temp")]
        public double Current { get; set; }

        [JsonPropertyName("feels_like")]
        public double FeelsLike { get; set; }

        [JsonPropertyName("temp_min")]
        public double Min { get; set; }

        [JsonPropertyName("temp_max")]
        public double Max { get; set; }

        [JsonPropertyName("pressure")]
        public double Pressure { get; set; }

        [JsonPropertyName("humidity")]
        public double Humidity { get; set; }
    }
}