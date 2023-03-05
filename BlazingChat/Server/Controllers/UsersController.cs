using BlazingChat.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BlazingChat.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : BaseController
    {
        private readonly ChatContext _chatContext;

        public UsersController(ChatContext chatContext)
        {
            _chatContext = chatContext;

        }

        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetUsers() =>
            await _chatContext.Users
                        .AsNoTracking()
                        .Where(u => u.Id != UserId)
                        .Select(u => new UserDto(u.Id, u.Name, false))
                        .ToListAsync();

        [HttpGet("chats")]
        public async Task<IEnumerable<UserDto>> GetUserChats(CancellationToken cancellationToken)
        {
            IEnumerable<UserDto> chatUsers = new List<UserDto>();
            var uniqueUsers = await _chatContext.Messages
                       .AsNoTracking()
                       .Where(m => m.FromId == UserId || m.ToId == UserId)
                       .Select(m => new { From = m.FromId, To = m.ToId })
                       .Distinct()
                       .ToListAsync(cancellationToken);

            var uniqueUserIds = new HashSet<int>();
            uniqueUsers.ForEach(u =>
            {
                if (u.From != UserId)
                    uniqueUserIds.Add(u.From);
                if (u.To != UserId)
                    uniqueUserIds.Add(u.To);
            });
            if (uniqueUserIds.Count > 0)
            {
                chatUsers = await _chatContext.Users
                                    .AsNoTracking()
                                    .Where(u => uniqueUserIds.Contains(u.Id))
                                    .Select(u => new UserDto(u.Id, u.Name, false))
                                    .ToListAsync(cancellationToken);
            }
            return chatUsers;
        }

    }
}
