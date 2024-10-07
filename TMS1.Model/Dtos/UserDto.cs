using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS1.Model.Entity;

namespace TMS1.Model.Dtos
{
    public class UserDto
    {
        public int UserId { get; set; }     
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }   
        public int RoleId { get; set; }     
        public List<string> Roles { get; set; } = new List<string>(); // 
        //role_name here 
    }
}
