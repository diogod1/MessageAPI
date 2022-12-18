using Message_API.Data;
using Message_API.Models;
using System;

namespace Message_API.Repositories
{
    public interface IMessageRepository
    {
        public bool Send(PostMessage mensagem);
        public List<Message> GetALLMESSAGE();
        public List<Chats> GetAllChats();
    }

    public class MessageRepository : IMessageRepository
    {
        private readonly  APIDbContext db;

        public MessageRepository(APIDbContext _db) 
        {
            db = _db;
        }

        public bool Send(PostMessage mensagem)
        {
            try
            {
                var send_message = new Message()
                {
                    userid = mensagem.userid,
                    chatid = mensagem.chatid,
                    content = mensagem.content,
                    sentAt = mensagem.sentAt,
                };
                db.messages.Add(send_message);  
                db.SaveChanges();
                
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Message> GetALLMESSAGE() => db.messages.ToList();

        public List<Chats> GetAllChats() => db.chats.ToList();
    }
}
