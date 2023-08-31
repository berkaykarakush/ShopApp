using PresentationLayer.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models
{
    public class CreateCategory2VM
    {
        [Required]
        [Display(Prompt = "Phone", Name ="Category Name")]
        public string? Name { get; set; }
        public string? Url { get; set; }
        [Display(Name = "Main Category")]
        public List<CategoryVM>? Categories { get; set; }
        [Required]
        public double CategoryId { get; set; }
    }
}
