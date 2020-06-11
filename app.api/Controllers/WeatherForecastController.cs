using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.mail.Models;
using app.mail.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace app.api.Controllers
{
    // [Authorize]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries =
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IMapper mapper,
            IEmailSender emailSender
        )
        {
            _logger = logger;
            _mapper = mapper;
            _emailSender = emailSender;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var rng = new Random();
            var message = new Message(new string[] {"toilati123vn@gmail.com"}, "Test email",
                "This is the content from our email.", null);
            // _emailSender.SendEmail(message);
            await _emailSender.SendEmailAsync(message);
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray();
        }

        [HttpPost]
        public async Task<IEnumerable<WeatherForecast>> Post()
        {
            var rng = new Random();

            var files = Request.Form.Files.Any() ? Request.Form.Files : new FormFileCollection();

            var message = new Message(new string[] {"toilati123vn@gmail.com"}, "Test mail with Attachments",
                "This is the content from our mail with attachments.", files);
            _emailSender.SendMailWithTemplate(message);

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray();
        }
    }
}