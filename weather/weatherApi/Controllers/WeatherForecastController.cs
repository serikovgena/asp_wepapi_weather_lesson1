using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using weatherDomain;

namespace weatherApi.Controllers
{
    [ApiController]
    [Route("api/weather")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly WeatherLog _weatherLog;

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherLog weatherLog) {
            _logger = logger;
            _weatherLog = weatherLog;
        }

        [HttpGet("get")]
        public IActionResult Get([FromQuery] DateTime from, [FromQuery] DateTime to) => Ok(_weatherLog.Get(from, to));

        [HttpPut("add")]
        public IActionResult Add([FromQuery] decimal tempreture, [FromQuery] DateTime date) {
            _weatherLog.Add(new WeatherDTO
            {
                Date = date,
                Tempreture = tempreture
            });
            return Ok();
        }

        [HttpPatch("update")]
        public IActionResult Update([FromQuery] decimal tempreture, [FromQuery] DateTime date) {
            _weatherLog.Update(tempreture, date);
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult Remove([FromQuery] DateTime date) {
             _weatherLog.Remove(new WeatherDTO
             {
                 Date = date
             });
             return Ok();
        }
    }
}
