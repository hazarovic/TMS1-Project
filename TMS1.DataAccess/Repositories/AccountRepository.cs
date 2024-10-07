using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TMS1.DataAcess.Context;
using TMS1.Model.Entity;
using TMS1.DataAccess.Interfaces;

namespace TMS1.DataAccess.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly TMS1DataContext dbContext;

        public AccountRepository(DbContextOptions<TMS1DataContext> options)
        {
            dbContext = new TMS1DataContext(options);
        }

        public int CreateAccount(Users users)
        {
            dbContext.Users.Add(users);
            return dbContext.SaveChanges();
        }

        public bool VerifyAccount(Users users)
        {
            return dbContext.Users.Any(x => x.Username == users.Username && x.Password == users.Password);
        }

        public IEnumerable<Users> GetAllAccount(string username)
        {
            var users = dbContext.Users.Where(x => x.Username.Contains(username)).ToList();
            return users;
        }

        public Users? GetUserDetails(string username)
        {
            return dbContext.Users
                .Include(u => u.Role)
                .FirstOrDefault(x => x.Username == username);
        }

        public List<string> GetRolesByUsername(string username)//delete this
        {
            var user = dbContext.Users
                .Include(u => u.Role)
                .FirstOrDefault(x => x.Username == username);

            return user != null ? new List<string> { user.Role.RoleName } : new List<string>();
        }
    }
}

