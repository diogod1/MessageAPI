using System.ComponentModel.DataAnnotations;

namespace Message_API.Models
{
    public class Users
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        public string name { get; set; }
        public string? bio { get; set; }
        public string? status { get; set; }
        public string? photo_path { get; set; }
    }
}
