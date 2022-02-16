using Fine.Data;
using Fine.Services;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ApplicationDbContext _context;
        private readonly ChatService _chatService;

        public ChatHub(ApplicationDbContext context, ChatService chatService)
        {
            _context = context;
            _chatService = chatService;
        }

        public async Task SendMessage(string user, string message)
        {
            await _chatService.ArchiveMessageAsync(message, user);
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public string GetCurrentUser()
        {
            var currentUser = Context.User.Identity.Name;
            return currentUser;
        }
    }
}