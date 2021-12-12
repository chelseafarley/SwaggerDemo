using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SwaggerDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("{id}")]
        public WeatherForecast Get(int id)
        {
            var rng = new Random();
            return new WeatherForecast
            {
                Date = DateTime.Now,
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            };
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, WeatherForecast weatherForecast)
        {
            // Update WeatherForecast
            return Ok();
        }

        /// <summary>
        /// Creates a WeatherForecast.
        /// </summary>
        /// <param name="weatherForecast"></param>
        /// <returns>Returns location of newly created weather forecast in response header</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /WeatherForecast
        ///     {
        ///         "date": "2021-12-13T20:30:51.116021+13:00",
        ///         "temperatureC": 26,
        ///         "temperatureF": 78,
        ///         "summary": "Hot"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns location of newly created weather forecast in response header</response>
        [HttpPost]
        public IActionResult Post(WeatherForecast weatherForecast)
        {
            // Create WeatherForecast
            return Created("/WeatherForecase/1", null);
        }
    }
}
