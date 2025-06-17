using Demo_Design_Pattern_MediaTor.Domain.Dtos.OrderDto;
using MediatR;

namespace Demo_Design_Pattern_MediaTor.Application.Queries
{
    public class GetAllOrdersQuery : IRequest<List<OrderDto>> { }
  
}
