using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FD.API.JWTAuthentication;
using FD.BLL.JsonModels;
using FD.BLL.Models.Response;
using FD.BLL.Models.User;
using FD.BLL.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Serilog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FD.API.Controllers
{
    [Route("api/authenticate")]
    [ApiController]
    public class Authentication : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly AppSettings _appSettings;
        public Authentication(IUserService userService, IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _appSettings = appSettings.Value;
        }


        // POST api/authenticate/user
        [AllowAnonymous]
        [HttpPost("user")]
        public ActionResult Post([FromBody] UserLogIn user)
        {
            try
            {
                var userResult = _userService.GetUser(user);

                if (userResult == null)
                    return BadRequest(new { message = "Email or password is incorrect" });
                var response = Authenticate.AuthenticateUser(userResult, _appSettings);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorModel = new Status()
                {
                    Message = ex.Message
                };
                Log.Error(ex, ex.Message);
                return StatusCode(500, errorModel);
            }
        }

      
    }
}
