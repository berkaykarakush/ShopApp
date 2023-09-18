namespace PresentationLayer.Areas.Seller.Models
{
    public class SellerCommentVM
    {
        public double CommentId { get; set; }   
        public string? UserId { get; set; }
        public string? UserFirstname { get; set; }
        public string? UserLastname { get; set; }
        public string? Description { get; set; }
        public string? SellerAnswer { get; set; }
        public int CommentRate { get; set; }
        public double StoreId { get; set; }
        public double? ProductId { get; set; }
    }
}
