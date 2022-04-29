using Microsoft.AspNetCore.Mvc;
using TheWeatherApp.API.Services;
using TheWeatherApp.Shared.Models;

namespace TheWeatherApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        // GET api/weather/London
        [HttpGet("{location}")]
        public async Task<ActionResult<WeatherResponse>> GetWeatherForLocation(string location)
        {
            try
            {
                return Ok(await _weatherService.GetWeatherForLocation(location));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}