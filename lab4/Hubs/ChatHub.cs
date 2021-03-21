using System.Threading.Tasks;
using lab4.Data;
using lab4.Models;
using Microsoft.AspNetCore.SignalR;

namespace AdvancedProgramming_Lesson4.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IChatMessageRepository _userPreferencesRepository;

        public ChatHub(IChatMessageRepository userPreferencesRepository)
        {
            _userPreferencesRepository = userPreferencesRepository;
        }

        public async Task SendMessage(string user, string message, string userId)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);

            if(!string.IsNullOrEmpty(userId))
            {
                var chatMessage = new Message()
                {
                    UserName = user,
                    Content = message
                };

                await _userPreferencesRepository.AddChatMessageAsync(userId, chatMessage);
            }
        }
    }
}
