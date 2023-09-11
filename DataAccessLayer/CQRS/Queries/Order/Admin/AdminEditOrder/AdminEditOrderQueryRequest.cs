using MediatR;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;

namespace DataAccessLayer.CQRS.Queries  
{
    public class AdminEditOrderQueryRequest : IRequest<AdminEditOrderQueryResponse>
    {
        public double OrderId { get; set; }
    }
}