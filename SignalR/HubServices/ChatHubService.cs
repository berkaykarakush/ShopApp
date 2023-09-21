using BusinessLayer.Abstract.Hubs;
using Microsoft.AspNetCore.SignalR;
using SignalR.Hubs;

namespace SignalR.HubServices
{
    public class ChatHubService : IChatHubService
    {
        readonly IHubContext<ChatHub> _hubContext;

        public ChatHubService(IHubContext<ChatHub> hubContext)
            => _hubContext = hubContext;

        public async Task SendMessage(string user, string message)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
