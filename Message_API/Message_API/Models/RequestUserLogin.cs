using System.ComponentModel.DataAnnotations;

namespace Message_API.Models
{
    public class RequestUserLogin
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
    }
}
