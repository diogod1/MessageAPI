using Microsoft.EntityFrameworkCore.Storage;

namespace Message_API.Models
{
    public class PostMessage
    {
        public int userid { get; set; }
        public int chatid { get; set; }
        public string content { get; set; }
        public DateTime sentAt { get; set; }
    }
}
