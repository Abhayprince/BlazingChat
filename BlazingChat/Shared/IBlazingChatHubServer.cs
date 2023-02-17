using BlazingChat.Shared.DTOs;

namespace BlazingChat.Shared
{
    public interface IBlazingChatHubServer
    {
        Task ConnectUser(UserDto user);
    }
}
