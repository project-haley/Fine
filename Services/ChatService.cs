using Fine.Data;
using Fine.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fine.Services
{
    public class ChatService
    {
        private readonly ApplicationDbContext _context;

        public ChatService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task ArchiveMessageAsync(string message, string user)
        {
            var chatUser = await _context.Users
                .Where(u => u.UserName == user)
                .FirstOrDefaultAsync();

            var archivedMessage = new Message(message);
            //archivedMessage.ChatUser = chatUser;
            //archivedMessage.ChatUserId = chatUser.Id;
            //archivedMessage.ChatUserId = chatUser.Id;

            chatUser.Messages.Add(archivedMessage);

            //Remove oldest message if stored messages exceed 50
            if (_context.Messages.Count() >= 50)
            {
                var oldestMessage = await _context.Messages.FirstOrDefaultAsync();

                _context.Remove(oldestMessage);
                _context.Add(archivedMessage);

                await _context.SaveChangesAsync();
                return;
            }

            _context.Add(archivedMessage);
            await _context.SaveChangesAsync();

            return;
        }
    }
}
