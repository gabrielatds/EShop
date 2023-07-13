using EShop.Core.Domain.Models;

namespace EShop.Core.Domain.Interfaces
{
    public interface IReaderRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    }
}
