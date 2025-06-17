using Demo_Design_Pattern_MediaTor.Application.Queries;
using Demo_Design_Pattern_MediaTor.Domain.Dtos.OrderDto;
using Demo_Design_Pattern_MediaTor.Domain.Interfaces.IService;
using MediatR;

namespace Demo_Design_Pattern_MediaTor.Application.Handlers
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDto?>
    {
        private readonly IOrderService _orderService;

        public GetOrderByIdQueryHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<OrderDto?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            return await _orderService.GetOrderByIdAsync(request.Id, cancellationToken);
        }
    }
}
