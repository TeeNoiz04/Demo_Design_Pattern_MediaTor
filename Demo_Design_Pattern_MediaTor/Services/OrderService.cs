using Demo_Design_Pattern_MediaTor.Domain.Dtos.OrderDto;
using Demo_Design_Pattern_MediaTor.Domain.Entities;
using Demo_Design_Pattern_MediaTor.Domain.Interfaces.IRepository;
using Demo_Design_Pattern_MediaTor.Domain.Interfaces.IService;
using Demo_Design_Pattern_MediaTor.Domain.Models;

namespace Demo_Design_Pattern_MediaTor.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> CreateOrderAsync(CreateOrderModel model, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(model.CustomerName))
                throw new ArgumentException("Tên khách hàng không được để trống");

            var order = new Order
            {
                Id = Guid.NewGuid(),
                CustomerName = model.CustomerName,
                TotalAmount = model.TotalAmount,
                CreatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(order, cancellationToken);
            return order.Id;
        }
        public async Task<List<OrderDto>> GetAllOrdersAsync(CancellationToken cancellationToken)
        {
            var orders = await _repository.GetAllAsync(cancellationToken);

            return orders.Select(o => new OrderDto
            {
                Id = o.Id,
                CustomerName = o.CustomerName,
                TotalAmount = o.TotalAmount,
                CreatedAt = o.CreatedAt
            }).ToList();
        }

        public async Task<OrderDto?> GetOrderByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var order = await _repository.GetByIdAsync(id, cancellationToken);
            return order == null ? null : new OrderDto
            {
                Id = order.Id,
                CustomerName = order.CustomerName,
                TotalAmount = order.TotalAmount,
                CreatedAt = order.CreatedAt
            };
        }

        public async Task<bool> UpdateOrderAsync(OrderDto orderDto, CancellationToken cancellationToken)
        {
            var existing = await _repository.GetByIdAsync(orderDto.Id, cancellationToken);
            if (existing == null) return false;

            existing.CustomerName = orderDto.CustomerName;
            existing.TotalAmount = orderDto.TotalAmount;
            await _repository.UpdateAsync(existing, cancellationToken);
            return true;
        }

        public async Task<bool> DeleteOrderAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _repository.DeleteAsync(id, cancellationToken);
        }
    }
}
