using Demo_Design_Pattern_MediaTor.Application.Queries;
using Demo_Design_Pattern_MediaTor.Domain.Dtos.OrderDto;
using Demo_Design_Pattern_MediaTor.Domain.Interfaces.IService;
using MediatR;

namespace Demo_Design_Pattern_MediaTor.Application.Handlers
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, List<OrderDto>>
    {
        private readonly IOrderService _orderService;

        public GetAllOrdersQueryHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<List<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _orderService.GetAllOrdersAsync(cancellationToken);
        }
    }
}
