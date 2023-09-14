namespace EntityLayer
{
    public class Comment : BaseEntity
    {
        public double CommentId { get; set; } = new Random().Next(111111111, 999999999);
        public string? UserId { get; set; }
        public string? UserFirstname { get; set; }
        public string? UserLastname { get; set; }
        public string? Description { get; set; }
        public int CommentRate { get; set; }

        public double? ProductId { get; set; }
        public Product? Product { get; set; }

    }
}
