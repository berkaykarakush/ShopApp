using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models
{
    public class ResetPasswordModel
    {
        [Required]
        public string? Token { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Prompt = "john@email.com")]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Prompt = "********")]
        public string? Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Prompt = "********")]
        public string? RePassword { get; set; }
    }
}
