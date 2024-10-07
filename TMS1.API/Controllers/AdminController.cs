using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using TMS1.Business.Interfaces;
using TMS1.Model.Dtos;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace TMS1.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize()]
    public class AdminController : ControllerBase
    {
        private readonly IAccountServices _accountServices;
        private readonly IMissionServices _missionServices;
        private readonly IMapper _mapper;
        private readonly ILogger<AdminController> _logger;

        public AdminController(IAccountServices accountServices, IMissionServices missionServices, IMapper mapper, ILogger<AdminController> logger)
        {
            _accountServices = accountServices;
            _missionServices = missionServices;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("accounts")]
        [Authorize(Roles = "Admin")]
        public ActionResult<IEnumerable<UserDto>> GetAllAccounts(string username)
        {
            var accounts = _accountServices.GetAllAccount(username);
            var accountDtos = _mapper.Map<IEnumerable<UserDto>>(accounts);
            return Ok(accountDtos);
        }

        [HttpPost("accounts")]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateAccount([FromBody] UserDto userDto)
        {
            try
            {
                if (_accountServices.GetUserDetails(userDto.Username) != null)
                {
                    return BadRequest("Account creation failed. Username already exists.");
                }

                var result = _accountServices.CreateAccount(userDto);
                if (result > 0)
                {
                    return Ok();
                }
                return BadRequest("Account creation failed.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating an account.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("missions")]
        [Authorize(Roles = "Admin")]
        public ActionResult<IEnumerable<MissionDto>> GetAllMissions()
        {
            try
            {
                var missions = _missionServices.GetAllMissions();
                var missionDtos = _mapper.Map<IEnumerable<MissionDto>>(missions);
                return Ok(missionDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all missions");
                return StatusCode(500, "Internal server error");
            }
        }

        //post mission
        [HttpPost("missions/save")]
        [Authorize(Roles = "Admin")]
        public ActionResult PostMission([FromBody] MissionDto missionDto)
        {
            try
            {
                if (missionDto.MissionId == 0)
                {
                    _missionServices.CreateMission(missionDto);
                    return Ok("Mission created successfully");
                }
                else
                {
                    _missionServices.UpdateMission(missionDto);
                    return Ok("Mission updated successfully");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while saving the mission");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("missions/{missionId}")]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteMission(int missionId)
        {
            try
            {
                _missionServices.DeleteMission(missionId);
                return Ok("Mission Deleted successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the mission");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("admin-assign-mission")]
        [Authorize(Roles = "Admin")]
        public ActionResult SomeAdminAction()
        {
            // Admin action 
            return Ok("Admin assigned mission to user successfully");
        }
    }
}
