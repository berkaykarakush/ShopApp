using MediatR;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.CQRS.Commands
{
    public class CreateCategory2CommandRequest: IRequest<CreateCategory2CommandResponse>
    {
        [Required]
        public string? Name { get; set; }
        public string? Url { get; set; }
        [Required]
        public double CategoryId { get; set; }
    }
}