using AdvancedProgramming_Lesson4.Data;
using lab4.Models;
using System.Collections.Generic;
using System.Linq;

namespace lab4.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public UserRepository(ApplicationDbContext context)
        {
            _dbcontext = context;
        }

        public List<ApplicationUser> GetUserList()
        {
            return _dbcontext.Users.ToList();
        }
    }
}
