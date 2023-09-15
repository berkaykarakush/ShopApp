using PresentationLayer.Identity;

namespace PresentationLayer.Models
{
    public class UserDetailsModel
    {
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public bool EmailConfirmed { get; set; }
        public IEnumerable<string>? SelectedRoles { get; set; }
        public string? UserDetailId { get; set; }
        public DateTime? ResetPasswordDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? LastLogoutDate { get; set; }
        public DateTime? FirstOrderDate { get; set; }
        public DateTime? LastOrderDate { get; set; }
    }
}
