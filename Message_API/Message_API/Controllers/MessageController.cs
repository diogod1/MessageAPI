﻿using Message_API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Message_API.Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Message_API.Repositories;

namespace Message_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageRepository repos;
        private Timer _timer;
        private DateTime _lastChecked;

        public MessageController(IMessageRepository _repos) 
        {
            repos = _repos;
        }

        [HttpGet("get-message-chatid")]
        public IActionResult GetMessageChatid(int _chatid, DateTime _lastchecked)
        {
            var count_messages = repos.GetMessages(_chatid, _lastchecked);
            if (count_messages != null)
            {
                return Ok(count_messages);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("get-all-chats")]
        public IActionResult GetAllChat()
        {
            var chats = repos.GetAllChats();
            if (chats != null)
            {
                return Ok(chats);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("get-all-messages")]
        public IActionResult GetMessage()
        {
            var message = repos.GetALLMESSAGE();
            if (message != null) 
            {
                return Ok(message);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
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
