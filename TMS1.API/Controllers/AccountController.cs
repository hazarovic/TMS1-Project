using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using TMS1.Business.Interfaces;
using TMS1.Model.Dtos;
using TMS1.API.Services;
using TMS1.Business.Services;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace TMS1.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IAccountServices _accountServices;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IAccountServices accountServices, IMapper mapper, ITokenService tokenService, ILogger<AccountController> logger)
        {
            _accountServices = accountServices;
            _mapper = mapper;
            _tokenService = tokenService;
            _logger = logger;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public ActionResult Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogWarning("Invalid model state for register");
                    return BadRequest(ModelState);
                }

                var userDto = _mapper.Map<UserDto>(registerDto);
                var result = _accountServices.CreateAccount(userDto);
                if (result > 0)
                {
                    _logger.LogInformation("User registered successfully");
                    return Ok("Registration successful");
                }
                _logger.LogWarning("Registration failed");
                return BadRequest("Registration failed");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during registration");
                return BadRequest($"An error occurred during registration: {ex.Message}");
            }
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult Login(LoginDto loginDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogWarning("Invalid model state for login");
                    return BadRequest(ModelState);
                }

                var userDto = _mapper.Map<UserDto>(loginDto); // Correctly map LoginDto to UserDto
                var result = _accountServices.VerifyAccount(userDto);
                if (result)
                {
                    var token = _tokenService.GenerateToken(userDto);
                    _logger.LogInformation("User logged in successfully");
                    return Ok(new { Token = token });
                }
                _logger.LogWarning("Invalid username or password");
                return Unauthorized("Invalid username or password");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during login");
                return BadRequest($"An error occurred during login: {ex.Message}");
            }
        }
    }
}

