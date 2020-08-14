using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
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
using Google.Apis.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace App.Api.Controllers
{
    public class AccountController : Controller
    {
        private static readonly HttpClient Client = new HttpClient();
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _config;
        private readonly IEmailSender _emailSender;
        private JwtService jwtService;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            IConfiguration config,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
            _emailSender = emailSender;
            jwtService = new JwtService(_config);
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
            var newUser = new AppUser { UserName = userRegisterDto.Email, Email = userRegisterDto.Email, PasswordHash = userRegisterDto.Password, FirstName = userRegisterDto.FirstName, LastName = userRegisterDto.LastName };
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

        [HttpPost(ApiRoutes.Identity.Login)]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var user = await _userManager.FindByNameAsync(userLoginDto.Email);
            if (user == null)
                return Unauthorized("Your username hasn't joined our system, please click Sign Up link to register");
            var result = await _signInManager.PasswordSignInAsync(userLoginDto.Email, userLoginDto.Password, false, true);

            if (result.Succeeded)
            {
                var jwt = new JwtService(_config);
                var checkConfirmEmail = await _userManager.IsEmailConfirmedAsync(user);
                if (!checkConfirmEmail) return Unauthorized("Please Confirm Email");
                var tokenString = jwt.GenerateSecurityToken(user.Email);
                return new ObjectResult(tokenString);
            }
            return Unauthorized("Email or password is incorrect");
        }

        [HttpPost(ApiRoutes.Identity.LoginGoogle)]
        public async Task<IActionResult> LoginGoogle(string token)
        {
            try
            {
                var payload = await GoogleJsonWebSignature.ValidateAsync(token, new GoogleJsonWebSignature.ValidationSettings());
                var info = new ExternalLoginInfo(null, "Google", payload.Subject, "Google");
                var user = await _userManager.FindByEmailAsync(payload.Email);

                if (user == null)
                {
                    user = new AppUser { UserName = payload.Email, Email = payload.Email, LastName = payload.FamilyName, FirstName = payload.GivenName, Picture = payload.Picture };
                    user.EmailConfirmed = true;
                    var resultCreate = await _userManager.CreateAsync(user);
                    if (resultCreate.Succeeded)
                    {
                        var resultLogin = await _userManager.AddLoginAsync(user, info);
                    }
                }
                else
                {
                    var resultFindByLoginExternal = await _userManager.FindByLoginAsync("Google", payload.Subject);
                    if (resultFindByLoginExternal == null)
                    {
                        var resultLogin = await _userManager.AddLoginAsync(user, info);
                        await _signInManager.UpdateExternalAuthenticationTokensAsync(info);
                    }

                    user = await _userManager.FindByEmailAsync(payload.Email);
                    await _signInManager.SignInAsync(user, false);
                }

                var tokenString = jwtService.GenerateSecurityToken(user.Email);
                return new OkObjectResult(tokenString);
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }
            return BadRequest("Error !");
        }

        [HttpPost(ApiRoutes.Identity.LoginFacebook)]
        public async Task<IActionResult> LoginFacebook(string token)
        {
            try
            {
                var userInfoResponse = await Client.GetStringAsync(
                $"https://graph.facebook.com/v2.8/me?fields=id,email,first_name,last_name,name,gender,locale,birthday,picture&access_token={token}");
                var userInfo = JsonConvert.DeserializeObject<FacebookUserData>(userInfoResponse);

                var info = new ExternalLoginInfo(null, "Facebook", userInfo.Id, "Facebook");

                var user = await _userManager.FindByEmailAsync(userInfo.Email);

                if (user == null)
                {
                    user = new AppUser { UserName = userInfo.Email, Email = userInfo.Email, Picture = userInfo.Picture.Data.Url, LastName = userInfo.Last_Name, FirstName = userInfo.First_Name };
                    user.EmailConfirmed = true;
                    var resultCreate = await _userManager.CreateAsync(user);
                    if (resultCreate.Succeeded)
                    {
                        var resultLogin = await _userManager.AddLoginAsync(user, info);
                    }
                }
                else
                {
                    var resultFindByLoginExternal = await _userManager.FindByLoginAsync("Google", info.ProviderKey);
                    if (resultFindByLoginExternal == null)
                    {
                        var resultLogin = await _userManager.AddLoginAsync(user, info);
                        await _signInManager.UpdateExternalAuthenticationTokensAsync(info);
                    }

                    user = await _userManager.FindByEmailAsync(userInfo.Email);
                    await _signInManager.SignInAsync(user, false);
                }
                var tokenString = jwtService.GenerateSecurityToken(user.Email);
                return new OkObjectResult(tokenString);
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }
            return BadRequest("Error !");
        }
    }
}