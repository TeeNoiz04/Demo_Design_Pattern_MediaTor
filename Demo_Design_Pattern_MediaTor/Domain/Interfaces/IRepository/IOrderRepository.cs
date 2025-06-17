using Demo_Design_Pattern_MediaTor.Domain.Entities;

namespace Demo_Design_Pattern_MediaTor.Domain.Interfaces.IRepository
{
    public interface IOrderRepository
    {
        Task AddAsync(Order order, CancellationToken cancellationToken);
        Task<List<Order>> GetAllAsync(CancellationToken cancellationToken);
        Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task UpdateAsync(Order order, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
