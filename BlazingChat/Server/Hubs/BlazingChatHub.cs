using BlazingChat.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace BlazingChat.Server.Hubs
{
    [Authorize]
    public class BlazingChatHub: Hub<IBlazingChatHubClient>, IBlazingChatHubServer
    {
        private static readonly IDictionary<int, UserDto> _connectedUsers = new Dictionary<int, UserDto>();

        public BlazingChatHub()
        {

        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public async Task ConnectUser(UserDto user)
        {
            await Clients.Caller.ConnectedUsersList(_connectedUsers.Values);
            if (!_connectedUsers.ContainsKey(user.Id))
            {
                _connectedUsers.Add(user.Id, user);

                await Clients.Others.UserConnected(user);
            }
        }
    }
}
