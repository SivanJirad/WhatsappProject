using WebWhatsappApi.Hubs.Clients;
using WebWhatsappApi.Models;

using Microsoft.AspNetCore.SignalR;

namespace WebWhatsappApi.Hubs

{
    public class ChatHub : Hub<IChatClient>
    {
        public async Task SendMessage(Transfer message)
        {
            await Clients.All.ReceiveMessage(message);
        }
    }
}
