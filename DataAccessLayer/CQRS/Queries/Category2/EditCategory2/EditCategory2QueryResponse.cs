using EntityLayer;

namespace DataAccessLayer.CQRS.Queries
{
    public class EditCategory2QueryResponse
    {
        public double Category2Id { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public string? CreatedDate { get; set; }
        public string? UpdatedDate { get; set; }
        public double CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<Category>? Categories { get; set; }
        public bool IsSuccess { get; set; }
    }
}