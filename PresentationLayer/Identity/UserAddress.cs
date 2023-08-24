﻿using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Identity
{
    public class UserAddress
    {
        public UserAddress()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string? Id { get; set; }
        public string? UserId { get; set; }
        public User? User { get; set; }
        public string? AddressName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? ZipCode { get; set; }
    }
}
