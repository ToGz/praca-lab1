using lab4.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace lab4.Data
{
    public interface IChatMessageRepository
    {
        Task<List<Message>> GetUserChatMessageListAsync(string userId);
        Task AddChatMessageAsync(string userId, Message message);
    }
}