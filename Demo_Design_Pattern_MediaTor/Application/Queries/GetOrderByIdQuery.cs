using Demo_Design_Pattern_MediaTor.Domain.Dtos.OrderDto;
using MediatR;

namespace Demo_Design_Pattern_MediaTor.Application.Queries
{
    public class GetOrderByIdQuery : IRequest<OrderDto?>
    {
        public Guid Id { get; }

        public GetOrderByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
