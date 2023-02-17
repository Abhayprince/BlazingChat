using BlazingChat.Shared.DTOs;

namespace BlazingChat.Shared
{
    public interface IBlazingChatHubClient
    {
        Task UserConnected(UserDto user);
        Task ConnectedUsersList(IEnumerable<UserDto> users);
    }
}
