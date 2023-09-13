using MediatR;
using System.Xml.Serialization;

namespace DataAccessLayer.CQRS.Queries
{
    public class ShopStoreHomeQueryRequest: IRequest<ShopStoreHomeQueryResponse>
    {
        public string? Store { get; set; }
    }
}