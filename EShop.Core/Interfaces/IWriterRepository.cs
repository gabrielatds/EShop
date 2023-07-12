using EShop.Core.Domain.Models;

namespace EShop.Core.Domain.Interfaces
{
    public interface IWriterRepository<in TEntity> where TEntity : Entity
    {
        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
