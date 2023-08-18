using EntityLayer;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.CQRS.Commands
{
    public class EditCategoryCommandResponse
    {
        public EditCategoryCommandResponse()
        {
            Name = "";
            Url = "";
            Products = new List<Product>();
        }
        public double CategoryId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public List<Product> Products { get; set; }
        public bool IsSuccess { get; set; }
    }
}