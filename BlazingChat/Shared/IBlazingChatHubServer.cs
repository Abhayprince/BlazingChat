using BlazingChat.Shared.DTOs;

namespace BlazingChat.Shared
{
    public interface IBlazingChatHubServer
    {
        Task SetUserOnline(UserDto user);
    }
}
