using Demo_Design_Pattern_MediaTor.Common;
using MediatR;

namespace Demo_Design_Pattern_MediaTor.Application.Commands
{
    public class UpdateOrderCommand : IRequest<BaseResponse<bool>>
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
    }
}
