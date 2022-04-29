using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;
using TheWeatherApp.Client.ViewModels;
using TheWeatherApp.Shared.Models;

namespace TheWeatherApp.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;

        public HomeController(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> WeatherLookup(string location)
        {
            var viewModel = new WeatherLocationResultViewModel();

            // Call TheWeatherApp.API project controller
            _client.BaseAddress = new Uri(_configuration["TheWeatherApp:Endpoint"]);
            var response = await _client.GetAsync($"weather/{location}");

            // Bad request if fails
            if (response.StatusCode == HttpStatusCode.BadRequest)
                viewModel.MessageTitle = $"No weather details found for '{location}'. Please try another location.";
            else
            {
                // Everything OK, convert to WeatherResponse object for the viewModel
                using var contentStream = await response.Content.ReadAsStreamAsync();
                WeatherResponse weatherResponse = await JsonSerializer.DeserializeAsync<WeatherResponse>(contentStream);

                viewModel.MessageTitle = $"Weather for {weatherResponse.LocationName}";
                viewModel.WeatherDetails = new()
                {
                    // Use the first 'Weather' object from the list, as there should only be 1
                    Type = weatherResponse.WeatherDetails.FirstOrDefault().Type,
                    Icon = weatherResponse.WeatherDetails.FirstOrDefault().Icon,
                    CurrentTempC = weatherResponse.Temperature.Current,
                    FeelsLikeTempC = weatherResponse.Temperature.FeelsLike,
                    MinTempC = weatherResponse.Temperature.Min,
                    MaxTempC = weatherResponse.Temperature.Max,
                    Pressure = weatherResponse.Temperature.Pressure,
                    Humidity = weatherResponse.Temperature.Humidity,
                    Sunrise = weatherResponse.Suntime.Sunrise,
                    Sunset = weatherResponse.Suntime.Sunset
                };
            }

            return PartialView("_WeatherLocationResult", viewModel);
        }
    }
}