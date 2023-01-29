using System.ComponentModel.DataAnnotations;

namespace Message_API.Models
{
    public class Message
    {
        [Key]
        public int id { get; set; }
        public int userid { get; set; }
        public int chatid { get; set; }
        public string content { get; set; }
        public DateTime sentAt { get; set; }
        public string senderUsername { get; set; }
    }
}
