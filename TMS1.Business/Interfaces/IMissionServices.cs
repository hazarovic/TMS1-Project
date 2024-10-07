using System.Collections.Generic;
using TMS1.Model.Dtos;

namespace TMS1.Business.Interfaces
{
    public interface IMissionServices
    {
        List<MissionDto> GetAllMissions();
        List<MissionDto> GetAllMissionsByUsername(string username);
        MissionDto? GetMissionById(int missionId);
        void CreateMission(MissionDto missionDto);
        void UpdateMission(MissionDto missionDto);
        void DeleteMission(int missionId);
        List<MissionDto> GetMissionByUser(int userId);
    }
}
