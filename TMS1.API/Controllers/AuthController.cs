using Microsoft.AspNetCore.Mvc;
using TMS1.API.Services;
using TMS1.Model.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace TMS1.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly HttpClient _httpClient;

        public AuthController(ITokenService tokenService, HttpClient httpClient)
        {
            _tokenService = tokenService;
            _httpClient = httpClient;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (loginDto == null)
            {
                return BadRequest("Invalid login request.");
            }

            var content = new StringContent(JsonConvert.SerializeObject(loginDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://localhost:7282/api/Account/login", content);

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(responseData);
                if (tokenResponse != null && !string.IsNullOrEmpty(tokenResponse.Token))
                {
                    HttpContext.Session.SetString("Token", tokenResponse.Token);
                    return Ok(new { Token = tokenResponse.Token });
                }
                return Unauthorized("Invalid login response.");
            }
            return Unauthorized("Login failed. Please check your credentials.");
        }

        private UserDto AuthenticateUser(LoginDto loginDto)
        {
            // Example user authentication
            if (loginDto.Username == "admin" && loginDto.Password == "admin")
            {
                return new UserDto
                {
                    Username = loginDto.Username,
                    Roles = new List<string> { "Admin" }
                };
            }
            else if (loginDto.Username == "user" && loginDto.Password == "password")
            {
                return new UserDto
                {
                    Username = loginDto.Username,
                    Roles = new List<string> { "User" }
                };
            }
            return null;
        }
    }
}