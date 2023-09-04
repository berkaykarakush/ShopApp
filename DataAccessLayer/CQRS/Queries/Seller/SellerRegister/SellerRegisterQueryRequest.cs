using MediatR;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.CQRS.Queries  
{
    public class SellerRegisterQueryRequest : IRequest<SellerRegisterQueryResponse>
    {
        public string? SellerId { get; set; }
        public string? SellerFirstName { get; set; }
        public string? SellerLastName { get; set; }
        public string? SellerEmail { get; set; }
        public string? SellerPhone { get; set; }
    }
}