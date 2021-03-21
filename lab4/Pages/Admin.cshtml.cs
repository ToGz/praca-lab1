using lab4.Data;
using lab4.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace lab4.Pages
{
    public class AdminModel : PageModel
    {
        readonly IUserRepository _userRepository;

        public List<ApplicationUser> Users { get; set; }

        public AdminModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void OnGet()
        {
            Users = _userRepository.GetUserList().Where(user => user.UserName != "admin@email.com").ToList();
        }
    }
}
