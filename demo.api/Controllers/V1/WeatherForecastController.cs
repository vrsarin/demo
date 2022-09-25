﻿using demo.api.Models.V1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace demo.api.Controllers.V1
{
    [ApiController]
    [Route("[controller]")]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiVersion("1.1-dev")]
    public class WeatherForecastController : ControllerBase
    {
        private static int callCount;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> logger;
        private readonly IDiagnosticContext diagnosticContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IDiagnosticContext diagnosticContext )
        {
            this.logger = logger;
            this.diagnosticContext = diagnosticContext;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]

        //[Obsolete("Will be removed in version 2.0")]
        public IEnumerable<WeatherForecast> GetV1()
        {
            this.diagnosticContext.Set("IndexCallCount", Interlocked.Increment(ref callCount));
            this.logger.LogInformation("Starting GetV1");
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
        [MapToApiVersion("1.1-dev")]
        public IEnumerable<WeatherForecast> GetV1_1_dev()
        {
            this.diagnosticContext.Set("IndexCallCount", Interlocked.Increment(ref callCount));
            this.logger.LogInformation("Starting GetV1");
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)] + "v1.1-dev2"
            })
                .ToArray();
        }
    }
}
