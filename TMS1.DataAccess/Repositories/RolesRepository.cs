using System.Collections.Generic;
using TMS1.DataAccess.Interfaces;

namespace TMS1.DataAccess.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        public List<string> GetRolesByUsername(string username)
        {
            // Example logic to fetch roles from the database
            // This should be replaced with actual database access code
            return new List<string> { "Admin", "User" };
        }
    }
}
