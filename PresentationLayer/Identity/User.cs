using Microsoft.AspNetCore.Identity;
using PresentationLayer.Models;
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
        public string? FirstOrderDate { get; set; }
        public List<UserAddress>? UserAddresses { get; set; } = new List<UserAddress>();
        public List<UserDetail>? UserDetails { get; set; } = new List<UserDetail>();

    }
}
