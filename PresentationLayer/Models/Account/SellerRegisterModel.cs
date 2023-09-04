using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models  
{
    public class SellerRegisterModel
    {
        public string? StoreName { get; set; }
        public string? SellerId { get; set; }
        public string? SellerFirstName { get; set; }
        public string? SellerLastName { get; set; }
        public string? SellerEmail { get; set; }
        public string? SellerPhone { get; set; }
    }
}
