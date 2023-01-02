using System.ComponentModel.DataAnnotations;

namespace Message_API.Models
{
    public class RequestUserRegister
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string name { get; set; }
    }
}
