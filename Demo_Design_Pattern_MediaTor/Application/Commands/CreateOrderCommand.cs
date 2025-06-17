using MediatR;

namespace Demo_Design_Pattern_MediaTor.Application.Commands
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        public string CustomerName { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
    }
}
