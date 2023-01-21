using Message_API.Models;
using Message_API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Message_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageRepository repos;

        public MessageController(IMessageRepository _repos)
        {
            repos = _repos;
        }

        [HttpGet("get-chatid")]
        public IActionResult GetMessageChatid(int _chatid, DateTime _lastchecked)
        {
            List<Message> messages = repos.GetMessages(_chatid, _lastchecked);
            if (messages.Count > 0)
            {
                return Ok(messages);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("get-all-chats")]
        public IActionResult GetAllChat()
        {
            List<Chats> chats = repos.GetAllChats();
            if (chats.Count > 0)
            {
                return Ok(chats);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("get-all")]
        public IActionResult GetMessage()
        {
            List<Message> messages = repos.GetALLMESSAGE();
            if (messages.Count > 0)
            {
                return Ok(messages);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("Send")]
        public IActionResult Post(PostMessage mensagem)
        {
            if (repos.Send(mensagem))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
