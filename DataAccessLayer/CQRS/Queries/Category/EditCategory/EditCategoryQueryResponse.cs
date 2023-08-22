using EntityLayer;

namespace DataAccessLayer.CQRS.Queries
{
    public class EditCategoryQueryResponse
    {
        public EditCategoryQueryResponse()
        {
            Name = "";
            Url = "";
            Products = new List<Product>(); 
        }
        public double CategoryId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public List<Product> Products { get; set; }
        public bool IsSuccess { get; set; } = false;
    }
}