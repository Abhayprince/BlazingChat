namespace BlazingChat.Shared.DTOs
{
    public class UserDto
    {
        public UserDto(int id, string name, bool isOnline = false)
        {
            Id = id;
            Name = name;
            IsOnline = isOnline;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsOnline { get; set; }
        public bool IsSelected { get; set; }
    }
}
