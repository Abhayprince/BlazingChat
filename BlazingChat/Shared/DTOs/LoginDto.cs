using System.ComponentModel.DataAnnotations;

namespace BlazingChat.Shared.DTOs
{
    public class LoginDto
    {
        [Required, MaxLength(50)]
        public string Username { get; set; }

        [Required, MaxLength(20), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
