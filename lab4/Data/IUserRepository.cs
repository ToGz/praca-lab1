using lab4.Models;
using System.Collections.Generic;

namespace lab4.Data
{
    public interface IUserRepository
    {
        List<ApplicationUser> GetUserList();
    }
}