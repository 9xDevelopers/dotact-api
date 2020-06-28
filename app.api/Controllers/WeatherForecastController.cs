//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using App.Mail.Models;
//using App.Mail.Services;
//using AutoMapper;
//using dotenv.net.Interfaces;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;

//namespace App.Api.Controllers
//{
//    // [Authorize]
//    [ApiVersion("1.0")]
//    [Route("api/[controller]")]
//    public class WeatherForecastController : ControllerBase
//    {
//        private static readonly string[] Summaries =
//        {
//            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//        };

//        private readonly IEmailSender _emailSender;
//        private readonly IEnvReader _envReader;

//        private readonly ILogger<WeatherForecastController> _logger;
//        private readonly IMapper _mapper;

//        public WeatherForecastController(
//            ILogger<WeatherForecastController> logger,
//            IMapper mapper,
//            IEmailSender emailSender,
//            IEnvReader envReader
//        )
//        {
//            _logger = logger;
//            _mapper = mapper;
//            _emailSender = emailSender;
//            _envReader = envReader;
//        }

//        [HttpGet("")]
//        public async Task<IEnumerable<WeatherForecast>> Get()
//        {
//            var tmpFile = _envReader.GetStringValue("TMPFILE");
//            var rng = new Random();
//            var message = new Message(new[] {"toilati123vn@gmail.com"}, "Test email",
//                "This is the content from our email.", null);
//            // _emailSender.SendEmail(message);
//            await _emailSender.SendEmailAsync(message);
//            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
//                {
//                    Date = DateTime.Now.AddDays(index),
//                    TemperatureC = rng.Next(-20, 55),
//                    Summary = Summaries[rng.Next(Summaries.Length)]
//                })
//                .ToArray();
//        }

//        [HttpPost]
//        public async Task<IEnumerable<WeatherForecast>> Post()
//        {
//            var rng = new Random();

//            var files = Request.Form.Files.Any() ? Request.Form.Files : new FormFileCollection();

//            var message = new Message(new[] {"toilati123vn@gmail.com"}, "Test mail with Attachments",
//                "This is the content from our mail with attachments.", files);
//            _emailSender.SendMailWithTemplate(message);

//            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
//                {
//                    Date = DateTime.Now.AddDays(index),
//                    TemperatureC = rng.Next(-20, 55),
//                    Summary = Summaries[rng.Next(Summaries.Length)]
//                })
//                .ToArray();
//        }
//    }
//}