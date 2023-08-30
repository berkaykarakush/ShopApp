namespace EntityLayer
{
    public class Comment
    {
        public Comment()
        {
            CommentId = new Random().Next(111111111, 999999999);
        }
        public double CommentId { get; set; }
        public double ProductId { get; set; }
        public Product? Product { get; set; }
        public string? UserId { get; set; }
        public string? UserFirstname { get; set; }
        public string? UserLastname { get; set; }
        public string? Description { get; set; }
        public string? CreatedDate { get; set; }
        public string? UpdatedDate { get; set; }
    }
}
