using Demo_Design_Pattern_MediaTor.Application.Commands;
using Demo_Design_Pattern_MediaTor.Domain.Interfaces.IService;
using Demo_Design_Pattern_MediaTor.Domain.Models;
using MediatR;

namespace Demo_Design_Pattern_MediaTor.Application.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IOrderService _orderService;

        public CreateOrderCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var model = new CreateOrderModel
            {
                CustomerName = request.CustomerName,
                TotalAmount = request.TotalAmount
            };

            return await _orderService.CreateOrderAsync(model, cancellationToken);
        }
    }
}
