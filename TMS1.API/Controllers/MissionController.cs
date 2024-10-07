using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using TMS1.Business.Interfaces;
using TMS1.Model.Dtos;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System;

namespace TMS1.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MissionController : ControllerBase
    {
        private readonly IMissionServices _missionServices;
        private readonly IMapper _mapper;
        private readonly ILogger<MissionController> _logger;

        public MissionController(IMissionServices missionServices, IMapper mapper, ILogger<MissionController> logger)
        {
            _missionServices = missionServices;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
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

        [HttpGet("{missionId}")]
        public ActionResult<MissionDto> GetMissionById(int missionId)
        {
            try
            {
                var mission = _missionServices.GetMissionById(missionId);
                if (mission != null)
                {
                    var missionDto = _mapper.Map<MissionDto>(mission);
                    return Ok(missionDto);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting the mission by ID");
                return StatusCode(500, "Internal server error");
            }
        }

        //post mission
        [HttpPost("missions/save")]
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

        [HttpDelete("{missionId}")]
        public ActionResult DeleteMission(int missionId)
        {
            try
            {
                _missionServices.DeleteMission(missionId);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the mission");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("user/{userId}")]
        public ActionResult<IEnumerable<MissionDto>> GetMissionByUser(int userId)
        {
            try
            {
                var missions = _missionServices.GetMissionByUser(userId);
                var missionDtos = _mapper.Map<IEnumerable<MissionDto>>(missions);
                return Ok(missionDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting missions by user ID");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
