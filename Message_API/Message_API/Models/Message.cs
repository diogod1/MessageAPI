using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    }
}
