using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using App.Api.DTOs.Account;
using App.Api.DTOs.Response;
using App.Api.Routes;
using App.Api.Services;
using App.Core.Helpers;
using App.Core.Models;
using App.Mail.Models;
using App.Mail.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace App.Api.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _config;
        private readonly IEmailSender _emailSender;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signManager,
            IConfiguration config,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signManager = signManager;
            _config = config;
            _emailSender = emailSender;
        }


        [HttpPost(ApiRoutes.Identity.Register)]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {
            if (!ModelState.IsValid) return BadRequest(new AuthFailedResponse
            {
                Errors = ModelState.Values.SelectMany(x => x.Errors.Select(x => x.ErrorMessage))
            });
            //Check if user exists
            var existsUser = _userManager.FindByEmailAsync(userRegisterDto.Email).Result;
            if (existsUser!=null) {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = new[] { "User with this email address already exists" }
                });
            };

            // Create new user
            var newUser = new AppUser { UserName = userRegisterDto.Email, Email = userRegisterDto.Email, PasswordHash = userRegisterDto.Password };
            var result = await _userManager.CreateAsync(newUser, userRegisterDto.Password);

            // Send mail
            if (result.Succeeded)
            {
                var jwt = new JwtService(_config);
                dynamic emailParams = new ExpandoObject();
                emailParams.Name = userRegisterDto.FirstName;
                string token = jwt.GenerateSecurityToken(userRegisterDto.Email);
                emailParams.Url = $"{_config.GetSection("ClientAppUrl").Value}?token={HttpUtility.UrlEncode(token)}";
                emailParams.TemplateName = "ConfirmEmailTemplate";
                Message message = new Message(new string[] { userRegisterDto.Email }, AppConstants.ConfirmEmail, "", null);
                _emailSender.SendMailWithTemplate(message, emailParams);
                return Ok(result);
            }
            return BadRequest(new AuthFailedResponse
            {
                Errors = result.Errors.Select(x=>x.Description)
            });
        }
    }
}