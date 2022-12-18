namespace Message_API.Models
{
    public class RequestUserUpdate
    {
        public string name { get; set; }
        public string? bio { get; set; }
        public string? status { get; set; }
        public string? photo_path { get; set; }
    }
}
