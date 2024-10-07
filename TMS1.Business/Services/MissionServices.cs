using AutoMapper;
using TMS1.Business.Interfaces;
using TMS1.DataAccess.Repositories;
using TMS1.Model.Dtos;
using TMS1.Model.Entity;
using System.Collections.Generic;
using System.Linq;
using TMS1.DataAccess.Interfaces;

namespace TMS1.Business.Services
{
    public class MissionServices : IMissionServices
    {
        private readonly IMapper _mapper;
        private readonly IMissionRepository _missionRepository;

        public MissionServices(IMapper mapper, IMissionRepository missionRepository)
        {
            _mapper = mapper;
            _missionRepository = missionRepository;
        }

        // Get All Missions
        public List<MissionDto> GetAllMissions()
        {
            var missions = _missionRepository.GetAllMissions();
            return _mapper.Map<List<MissionDto>>(missions);
        }

        // Get Missions by Username
        public List<MissionDto> GetAllMissionsByUsername(string username)
        {
            var missions = _missionRepository.GetAllMissions(username);
            return _mapper.Map<List<MissionDto>>(missions);
        }

        // Get Mission by ID
        public MissionDto? GetMissionById(int missionId)
        {
            var mission = _missionRepository.GetMission(missionId);
            return _mapper.Map<MissionDto>(mission);
        }

        // Create New Mission
        public void CreateMission(MissionDto missionDto)
        {
            var mission = _mapper.Map<Mission>(missionDto);
            mission.UserId = missionDto.UserId; 
            _missionRepository.CreateMission(mission);
        }

        // Update Mission
        public void UpdateMission(MissionDto missionDto)
        {
            var mission = _mapper.Map<Mission>(missionDto);
            mission.UserId = missionDto.UserId; // 
            _missionRepository.UpdateMission(mission);
        }

        // Delete Mission
        public void DeleteMission(int missionId)
        {
            _missionRepository.DeleteMission(missionId);
        }

        // Get Mission by User
        public List<MissionDto> GetMissionByUser(int userId)
        {
            var missions = _missionRepository.GetAllMissions(userId);
            return _mapper.Map<List<MissionDto>>(missions);
        }
    }
}
