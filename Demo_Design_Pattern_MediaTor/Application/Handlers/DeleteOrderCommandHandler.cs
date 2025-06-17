using Demo_Design_Pattern_MediaTor.Application.Commands;
using Demo_Design_Pattern_MediaTor.Common;
using Demo_Design_Pattern_MediaTor.Domain.Interfaces.IService;
using MediatR;

namespace Demo_Design_Pattern_MediaTor.Application.Handlers
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, BaseResponse<bool>>
    {
        private readonly IOrderService _orderService;

        public DeleteOrderCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<BaseResponse<bool>> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var success = await _orderService.DeleteOrderAsync(request.Id, cancellationToken);

            return new BaseResponse<bool>
            {
                Success = success,
                Data = success,
                Message = success ? "Xóa đơn hàng thành công" : "Không tìm thấy đơn hàng để xóa",
                Errors = success ? new List<string>() : new List<string> { "Order not found" }
            };
        }
    }
}
