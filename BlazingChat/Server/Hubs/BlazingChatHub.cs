using Microsoft.AspNetCore.SignalR;

namespace BlazingChat.Server.Hubs
{
    public interface IBlazingChatHubClient
    {
        void RecieveMessage(string message);
    }

    public class BlazingChatHub: Hub<IBlazingChatHubClient>
    {
        public BlazingChatHub()
        {

        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
    }
}
