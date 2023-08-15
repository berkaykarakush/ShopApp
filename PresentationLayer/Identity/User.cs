using Microsoft.AspNetCore.Identity;
using System.Net;

namespace PresentationLayer.Identity
{
    public class User:IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? RegistrationDate { get; set; }
        public string? ConfirmEmailDate { get; set; }
        public string? IpAddress { get; set; }
        public string? ResetPasswordDate { get; set; }
        public string? LastLoginDate { get; set; }
        public string? LastLogoutDate { get; set; }
        public string? FirstOrderDate { get; set; }
        public string? LastOrderDate { get; set; }
    }
}
