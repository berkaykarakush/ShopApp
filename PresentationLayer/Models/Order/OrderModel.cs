using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models
{
    public class OrderModel
    {
        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? Address { get; set; }
        
        [Required]
        public string? City { get; set; }
        
        [Required]
        public string? Phone { get; set; }
        
        [Required]
        public string? Email { get; set; }
        
        public string? Note { get; set; }
        
        [Required]
        public string? CardName { get; set; }
        
        [Required]
        public string? CardNumber { get; set; }
        
        [Required]
        public string? ExpirationYear { get; set; }
        
        [Required]
        public string? ExpirationMonth { get; set; }
       
        [Required]
        public string? Cvc { get; set; }
        public CartModel? CartModel { get; set; }
    }
}
