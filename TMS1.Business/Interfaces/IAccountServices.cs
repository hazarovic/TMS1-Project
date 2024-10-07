using System.Collections.Generic;
using TMS1.Model.Dtos;

namespace TMS1.Business.Interfaces
{
    public interface IAccountServices
    {
        //add By id 
        IEnumerable<UserDto> GetAllAccount(string username); 

        int CreateAccount(UserDto userDto);

        bool VerifyAccount(UserDto userDto);

        UserDto GetUserDetails(string username);
    }
}
