using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models  
{
    public class RegisterModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string? FirstName { get; set; }
        
        [Required]
        [DataType(DataType.Text)]
        public string? LastName { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string? RePassword { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }

        public string? RegistrationDate { get; set; }
    }
}
