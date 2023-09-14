using EntityLayer;

namespace DataAccessLayer.CQRS.Queries
{
    public class CheckoutQueryResponse
    {
        public bool IsSuccess { get; set; }     
        public string? UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? ZipCode { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Note { get; set; }
        public string? CardName { get; set; }
        public string? CardNumber { get; set; }
        public string? ExpirationYear { get; set; }
        public string? ExpirationMonth { get; set; }
        public string? Cvc { get; set; }
        public Cart? Cart { get; set; }

        public List<double> StoreIds { get; set; }
    }
}