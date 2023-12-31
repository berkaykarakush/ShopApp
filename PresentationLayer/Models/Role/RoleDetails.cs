﻿using Microsoft.AspNetCore.Identity;
using PresentationLayer.Identity;

namespace PresentationLayer.Models
{
    public class RoleDetails
    {
        public IdentityRole? Role { get; set; }
        public IEnumerable<User>? Members { get; set; }
        public IEnumerable<User>? NonMembers { get; set; }
    }
}
