using EntityLayer;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.CQRS.Commands
{
    public class EditCategoryCommandResponse
    {
        public double CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public List<Product>? Products { get; set; } = new List<Product>();
        public bool IsSuccess { get; set; }     
    }
}