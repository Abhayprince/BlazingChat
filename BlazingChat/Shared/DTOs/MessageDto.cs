namespace BlazingChat.Shared.DTOs
{
    public record MessageDto(int ToUserId, int FromUserId, string Message, DateTime SentOn);
}
