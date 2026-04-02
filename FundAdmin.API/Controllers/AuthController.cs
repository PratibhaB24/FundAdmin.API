using FundAdmin.API.DTOs.Auth;
using FundAdmin.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FundAdmin.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public AuthController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        /// <summary>
        /// Authenticates a user and returns a JWT token if credentials are valid.
        /// Use mock credentails: Username = "admin" and Password = "password"
        /// </summary>
        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            // Mock validation
            if (dto.Username != "admin" || dto.Password != "password")
                return Unauthorized("Invalid credentials");

            var token = _tokenService.GenerateToken(dto.Username);

            return Ok(new { token });
        }
    }
}
