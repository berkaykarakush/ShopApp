namespace PresentationLayer.Identity
{
    public class UserDetail
    {
        public string? Id { get; set; } = Guid.NewGuid().ToString(); 
        public string? UserId{ get; set; }
        public User? User { get; set; }
        public DateTime? LastOrderDate { get; set; }
        public DateTime? ResetPasswordDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? LastLogoutDate { get; set; }
    }
}
