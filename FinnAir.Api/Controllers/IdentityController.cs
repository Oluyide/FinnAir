using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinnAir.Api.Contracts;
using FinnAir.Api.Contracts.Request;
using FinnAir.Api.Options;
using FinnAir.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinnAir.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        public readonly IIdentityService _identityService;
        public readonly JwtSettings _jwtSettings;
        public IdentityController(IIdentityService identityService, JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
            _identityService = identityService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest request)
        {
            var authResponse = await _identityService.RegisterAsync(request.Email, request.Password, _jwtSettings.Secret);
            if (!authResponse.Success)
            {
                return BadRequest(new FailResponse
                {
                    Errors = authResponse.Errors
                });
            }
            return Ok(new AuthSuccessResponse
            {
                Token = authResponse.Token
            });

        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            var authResponse = await _identityService.LoginAsync(request.Email, request.Password, _jwtSettings.Secret);
            if (!authResponse.Success)
            {
                return BadRequest(new FailResponse
                {
                    Errors = authResponse.Errors
                });
            }
            return Ok(new AuthSuccessResponse
            {
                Token = authResponse.Token
            });

        }

    }
}