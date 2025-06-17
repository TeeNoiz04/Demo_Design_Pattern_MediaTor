using Demo_Design_Pattern_MediaTor.Domain.Dtos.OrderDto;
using Demo_Design_Pattern_MediaTor.Domain.Models;

namespace Demo_Design_Pattern_MediaTor.Domain.Interfaces.IService
{
    public interface IOrderService
    {
        Task<Guid> CreateOrderAsync(CreateOrderModel model, CancellationToken cancellationToken);
        Task<List<OrderDto>> GetAllOrdersAsync(CancellationToken cancellationToken);
        Task<OrderDto?> GetOrderByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<bool> UpdateOrderAsync(OrderDto orderDto, CancellationToken cancellationToken);
        Task<bool> DeleteOrderAsync(Guid id, CancellationToken cancellationToken);
    }
}
