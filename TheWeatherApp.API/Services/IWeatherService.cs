using TheWeatherApp.Shared.Models;

namespace TheWeatherApp.API.Services
{
    public interface IWeatherService
    {
        Task<WeatherResponse> GetWeatherForLocation(string location);
    }
}