using System.Collections.Generic;
using System.Threading.Tasks;
using lab4.Data;
using lab4.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab4.Pages
{
    public class MessageHistoryModel : PageModel
    {  
        readonly IChatMessageRepository _chatMessageRepository;
        readonly UserManager<ApplicationUser> _userManager;

        public List<Message> ChatMessages { get; set; }

        public MessageHistoryModel(IChatMessageRepository chatMessageRepository, UserManager<ApplicationUser> userManager)
        {
            _chatMessageRepository = chatMessageRepository;
            _userManager = userManager;
        }
        public async Task OnGet()
        {
            var userId = _userManager.GetUserId(User);
            ChatMessages = await _chatMessageRepository.GetUserChatMessageListAsync(userId);
        }
    }
}
