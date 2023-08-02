using Microsoft.AspNetCore.Identity;

namespace PresentationLayer.Identity
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
