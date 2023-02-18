namespace ATLabProject.Services.Models
{
    public class UserResponse
    {
        private long id;
        public string username { get; set; } = string.Empty;
        public string firstname { get; set; } = string.Empty;
        public string lastname { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string phone { get; set; } = string.Empty;
        public long userStatus { get; set; }
        public long Id { get => id; set => id = value; }
    }
}