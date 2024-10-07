using System.Collections.Generic;

namespace TMS1.DataAccess.Interfaces
{
    public interface IRoleRepository
    {
        List<string> GetRolesByUsername(string username);
    }
}
