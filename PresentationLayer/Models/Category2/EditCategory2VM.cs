using EntityLayer;
using PresentationLayer.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models
{
    public class EditCategory2VM
    {
        public double Category2Id { get; set; }

        [Required]
        [Display(Prompt = "Phone", Name = "Category Name")]

        public string? Name { get; set; }

        public string? Url { get; set; }

        [Display(Name = "Main Category")]
        public List<CategoryVM>? Categories { get; set; }

        [Required]
        public double CategoryId { get; set; }
        public Category? Category { get; set; }

        public string? CreatedDate { get; set; }

        public string? UpdatedDate { get; set; }
    }
}
