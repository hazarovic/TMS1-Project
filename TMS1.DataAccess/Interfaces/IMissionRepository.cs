using System.Collections.Generic;
using TMS1.Model.Entity;

namespace TMS1.DataAccess.Interfaces
{
    public interface IMissionRepository
    {
        IEnumerable<Mission> GetAllMissions();
        IEnumerable<Mission> GetAllMissions(int userId); //Remove this
        IEnumerable<Mission> GetAllMissions(string username);
        Mission GetMission(int missionId);
        int CreateMission(Mission mission);
        int UpdateMission(Mission mission);
        int DeleteMission(int missionId);
    }
}
