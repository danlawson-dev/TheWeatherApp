using System.Text.Json;
using TheWeatherApp.Shared.Models;

namespace TheWeatherApp.API.Services
{
    public class OpenWeatherMapService : IWeatherService
    {
        private const string UNITS_TYPE = "metric";

        private readonly IConfiguration _configuration;
        private readonly HttpClient _client;

        public OpenWeatherMapService(IConfiguration configuration, HttpClient client)
        {
            _configuration = configuration;
            _client = client;
        }

        public async Task<WeatherResponse> GetWeatherForLocation(string location)
        {
            // Always use 'metric' units type to show temperature in Celsius
            var response = await _client.GetAsync($"weather?q={location}&appid={_configuration["OpenWeatherMap:APIKey"]}&units={UNITS_TYPE}");

            response.EnsureSuccessStatusCode();

            using var contentStream = await response.Content.ReadAsStreamAsync();

            return await JsonSerializer.DeserializeAsync<WeatherResponse>(contentStream);
        }
    }
}