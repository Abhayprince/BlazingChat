using BlazingChat.Server.Data;
using BlazingChat.Server.Data.Entities;
using BlazingChat.Server.Hubs;
using BlazingChat.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace BlazingChat.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : BaseController
    {
        private readonly ChatContext _chatContext;
        private readonly IHubContext<BlazingChatHub, IBlazingChatHubClient> _hubContext;

        public MessagesController(ChatContext chatContext, IHubContext<BlazingChatHub, IBlazingChatHubClient> hubContext)
        {
            _chatContext = chatContext;
            _hubContext = hubContext;
        }

        // /api/messages
        [HttpPost("")]
        public async Task<IActionResult> SendMessage(MessageSendDto messageDto, CancellationToken cancellationToken)
        {
            if (messageDto.ToUserId <= 0 || string.IsNullOrWhiteSpace(messageDto.Message))
                return BadRequest();

            var message = new Message
            {
                FromId = base.UserId,
                ToId = messageDto.ToUserId,
                Content = messageDto.Message,
                SentOn = DateTime.Now
            };
            await _chatContext.Messages.AddAsync(message, cancellationToken);
            if(await _chatContext.SaveChangesAsync(cancellationToken) > 0)
            {
                await _hubContext.Clients.User(messageDto.ToUserId.ToString())
                            .MessageRecieved(base.UserId, messageDto.Message);
                return Ok();
            }
            else
            {
                return StatusCode(500, "Unable to send message");
            }
        }
    }
}
