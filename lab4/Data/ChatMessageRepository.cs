using AdvancedProgramming_Lesson4.Data;
using lab4.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab4.Data
{
    public class ChatMessageRepository : IChatMessageRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public ChatMessageRepository(ApplicationDbContext context)
        {
            _dbcontext = context;
        }

        public async Task AddChatMessageAsync(string userId, Message message)
        {
            var user = await _dbcontext.Users.FirstOrDefaultAsync(user => user.Id == userId);

            message.MessageOwner = user;
            message.DateSent = DateTime.Now;

             await _dbcontext.Messages.AddAsync(message);
             await _dbcontext.SaveChangesAsync();
        }

        public async Task<List<Message>> GetUserChatMessageListAsync(string userId)
        {
            return await _dbcontext.Messages.Where(message => message.MessageOwner.Id == userId).ToListAsync();
        }
    }
}
