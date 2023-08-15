﻿namespace PresentationLayer.Identity
{
    public class UserDetail
    {
        public UserDetail()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string UserId{ get; set; }
        public User User { get; set; }
        public string? LastOrderDate { get; set; }
    }
}
