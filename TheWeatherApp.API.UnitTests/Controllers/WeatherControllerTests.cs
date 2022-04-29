using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using TheWeatherApp.API.Controllers;
using TheWeatherApp.API.Services;
using TheWeatherApp.Shared.Models;

namespace TheWeatherApp.API.UnitTests.Controllers
{
    public class WeatherControllerTests
    {
        [Test]
        public async Task GetWeatherForLocation_InterfaceReturnsWeatherResponseObject_ControllerReturnsWeatherResponseObject()
        {
            // Arrange
            var weatherSerivce = A.Fake<IWeatherService>();
            A.CallTo(() => weatherSerivce.GetWeatherForLocation("")).Returns(new WeatherResponse());
            var controller = new WeatherController(weatherSerivce);

            // Act
            var response = await controller.GetWeatherForLocation("");
            
            // Assert
            var result = response.Result as OkObjectResult;
            var value = result.Value;
            Assert.AreEqual(typeof(WeatherResponse), value.GetType());
        }

        [Test]
        public async Task GetWeatherForLocation_InterfaceReturnsWeatherResponseObject_ControllerReturnsStatus200OK()
        {
            // Arrange
            var weatherSerivce = A.Fake<IWeatherService>();
            A.CallTo(() => weatherSerivce.GetWeatherForLocation("")).Returns(new WeatherResponse());
            var controller = new WeatherController(weatherSerivce);

            // Act
            var response = await controller.GetWeatherForLocation("");

            // Assert
            var result = response.Result as OkObjectResult;
            Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);
        }

        [Test]
        public async Task GetWeatherForLocation_InterfaceThrowsException_ControllerReturnsStatus400BadRequest()
        {
            // Arrange
            var weatherSerivce = A.Fake<IWeatherService>();
            A.CallTo(() => weatherSerivce.GetWeatherForLocation("")).Throws<Exception>();
            var controller = new WeatherController(weatherSerivce);

            // Act
            var response = await controller.GetWeatherForLocation("");

            // Assert
            var result = response.Result as BadRequestObjectResult;
            Assert.AreEqual(StatusCodes.Status400BadRequest, result.StatusCode);
        }
    }
}