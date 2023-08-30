using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models  
{
    public class SellerRegisterModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Prompt = "John")]
        public string? FirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Prompt = "Deo")]
        public string? LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Prompt = "john@email.com")]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Prompt = "********")]
        public string? Password { get; set; }

        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        [Display(Prompt = "********")]
        public string? RePassword { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Prompt = "05554443322")]
        public string? Phone { get; set; }

        public string? RegistrationDate { get; set; }
    }
}
