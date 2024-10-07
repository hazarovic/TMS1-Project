using System.Collections.Generic;
using TMS1.Model.Entity;

namespace TMS1.DataAccess.Interfaces
{
    public interface IAccountRepository
    {
        int CreateAccount(Users users);
        bool VerifyAccount(Users users);
        IEnumerable<Users> GetAllAccount(string username);
        Users? GetUserDetails(string username); // 
        List<string> GetRolesByUsername(string username);
    }
}

