namespace Message_API.Models
{
    public class PutChangePassword
    {
        public int userid { get; set; }
        public string new_password { get; set; }
        public string old_password { get; set; }
    }
}
