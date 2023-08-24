using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models
{
    public class ForgotPasswordModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Prompt = "john@email.com")]
        public string? Email { get; set; }
    }
}
