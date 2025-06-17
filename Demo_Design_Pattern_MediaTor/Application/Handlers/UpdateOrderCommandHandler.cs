using Demo_Design_Pattern_MediaTor.Application.Commands;
using Demo_Design_Pattern_MediaTor.Common;
using Demo_Design_Pattern_MediaTor.Domain.Dtos.OrderDto;
using Demo_Design_Pattern_MediaTor.Domain.Interfaces.IService;
using MediatR;

namespace Demo_Design_Pattern_MediaTor.Application.Handlers
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, BaseResponse<bool>>
    {
        private readonly IOrderService _orderService;

        public UpdateOrderCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<BaseResponse<bool>> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var dto = new OrderDto
            {
                Id = request.Id,
                CustomerName = request.CustomerName,
                TotalAmount = request.TotalAmount
            };

            var success = await _orderService.UpdateOrderAsync(dto, cancellationToken);

            return new BaseResponse<bool>
            {
                Success = success,
                Data = success,
                Message = success ? "Cập nhật đơn hàng thành công" : "Không tìm thấy đơn hàng để cập nhật",
                Errors = success ? new List<string>() : new List<string> { "Order not found" }
            };
        }
    }
}
