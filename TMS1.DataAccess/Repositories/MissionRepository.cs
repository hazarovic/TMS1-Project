using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TMS1.DataAccess.Interfaces;
using TMS1.DataAcess.Context;
using TMS1.Model.Entity;

namespace TMS1.DataAccess.Repositories
{
    public class MissionRepository : IMissionRepository
    {
        private readonly TMS1DataContext dbContext;

        public MissionRepository(TMS1DataContext context)
        {
            dbContext = context;
        }

        // Get All Missions
        public IEnumerable<Mission> GetAllMissions()
        {
            return dbContext.Mission.Include(m => m.User).ToList();
        }

        // Get All Missions through user id
        public IEnumerable<Mission> GetAllMissions(int userId)
        {
            return dbContext.Mission.Where(x => x.UserId == userId).Include(m => m.User).ToList();
        }

        // Get All Missions through username
        public IEnumerable<Mission> GetAllMissions(string username)
        {
            var user = dbContext.Users.SingleOrDefault(s => s.Username == username);
            if (user == null)
                return new List<Mission>();
            return dbContext.Mission.Where(x => x.UserId == user.UserId).Include(m => m.User).ToList();
        }

        // Get Single Mission
        public Mission GetMission(int missionId)
        {
            return dbContext.Mission.Include(m => m.User).SingleOrDefault(x => x.MissionId == missionId);
        }

        // Create New Mission
        public int CreateMission(Mission mission)
        {
            
            dbContext.Mission.Add(mission);
            return dbContext.SaveChanges();
        }

        // Update Mission
        public int UpdateMission(Mission mission)
        {
            if (dbContext.Mission.Any(m => m.MissionId == mission.MissionId))
            {
                dbContext.Entry(mission).State = EntityState.Modified;
                return dbContext.SaveChanges();
            }
            throw new KeyNotFoundException("Mission not found");
        }

        // Delete Mission
        public int DeleteMission(int missionId)
        {
            var mission = GetMission(missionId);
            if (mission == null)
                throw new KeyNotFoundException("Mission not found");

            dbContext.Entry(mission).State = EntityState.Deleted;
            return dbContext.SaveChanges();
        }
    }
}

