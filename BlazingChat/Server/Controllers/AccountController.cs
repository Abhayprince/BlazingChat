using BlazingChat.Server.Data;
using BlazingChat.Server.Data.Entities;
using BlazingChat.Server.Hubs;
using BlazingChat.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace BlazingChat.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ChatContext _chatContext;
        private readonly TokenService _tokenService;
        private readonly IHubContext<BlazingChatHub, IBlazingChatHubClient> _hubContext;

        public AccountController(ChatContext chatContext, TokenService tokenService, IHubContext<BlazingChatHub, IBlazingChatHubClient> hubContext)
        {
            _chatContext = chatContext;
            _tokenService = tokenService;
            _hubContext = hubContext;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto, CancellationToken cancellationToken)
        {
            var usernameExists = await _chatContext.Users
                                        .AsNoTracking()
                                        .AnyAsync(u => u.Username == dto.Username, cancellationToken);

            if (usernameExists)
            {
                return BadRequest($"[{nameof(dto.Username)}] already exists");
            }

            var user = new User
            {
                Username = dto.Username,
                AddedOn = DateTime.Now,
                Name = dto.Name,
                Password = dto.Password, // Plain Password.  Implement your own secure password mechanism
            };

            await _chatContext.Users.AddAsync(user, cancellationToken);
            await _chatContext.SaveChangesAsync(cancellationToken);

            await _hubContext.Clients.All.UserConnected(new UserDto(user.Id, user.Name));

            return Ok(GenerateToken(user));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto, CancellationToken cancellationToken)
        {
            var user = await _chatContext.Users.FirstOrDefaultAsync(u=> u.Username == dto.Username && u.Password == dto.Password, cancellationToken);
            if(user is null)
            {
                return BadRequest("Incorrect credentials");
            }

            return Ok(GenerateToken(user));
        }

        private AuthResponseDto GenerateToken(User user)
        {
            var token = _tokenService.GenerateJWT(user);
            return new AuthResponseDto(new UserDto(user.Id, user.Name), token);
        }
    }
}
