using Microsoft.AspNetCore.Identity;
using System.Net;

namespace PresentationLayer.Identity
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? IpAddress { get; set; }
    }
}
