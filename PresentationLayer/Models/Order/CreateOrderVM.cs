using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models
{
    public class CreateOrderVM
    {
        public string? UserId { get; set; }

        [Required]
        [Display(Name = "First Name", Prompt = "John Doe")]
        public string? FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name", Prompt = "John Doe")]
        public string? LastName { get; set; }

        [Required]
        [Display(Name = "Address", Prompt = "Boston street No: 12")]
        public string? Address { get; set; }
        
        [Required]
        [Display(Name = "City", Prompt = "Boston")]
        public string? City { get; set; }

        [Required]
        [Display(Name = "Country", Prompt = "United States")]
        public string? Country { get; set; }

        [Required]
        [Display(Name = "Zip Code", Prompt = "02108")]
        public string? ZipCode { get; set; }

        [Required]
        [Display(Name = "Phone Number", Prompt = "5555551234")]
        public string? Phone { get; set; }
        
        [Required]
        [Display(Name = "E-Mail", Prompt = "john@email.com")]
        public string? Email { get; set; }
        
        [Required]
        [Display(Name = "Card Owner", Prompt = "John Doe")]
        public string? CardName { get; set; }
        
        [Required]
        [Display(Name = "Card Number", Prompt= "5528790000000008")]
        public string? CardNumber { get; set; }
        
        [Required]
        [Display(Name = "Expiration Year", Prompt= "2023")]
        public string? ExpirationYear { get; set; }
        
        [Required]
        [Display(Name = "Expiration Month", Prompt= "12")]

        public string? ExpirationMonth { get; set; }
       
        [Required]
        [Display(Name = "CVC", Prompt= "123")]
        public string? Cvc { get; set; }

        [Required]
        public bool TermsAndConditions { get; set; }

        public CartModel? CartModel { get; set; }
        public List<double>? StoreIds { get; set; }
    }
}
