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
        public bool EmailConfirmed { get; set; }
        public IEnumerable<string>? SelectedRoles { get; set; }
        public string? UserDetailId { get; set; }
        public string? ResetPasswordDate { get; set; }
        public string? LastLoginDate { get; set; }
        public string? LastLogoutDate { get; set; }
        public string? FirstOrderDate { get; set; }
        public string? LastOrderDate { get; set; }
    }
}
