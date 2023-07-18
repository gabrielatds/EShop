using EShop.Core.Domain.Interfaces;
using EShop.Domain.Models;

namespace EShop.Domain.Interfaces
{
    public interface IProductRepository : IReaderRepository<Product>, IWriterRepository<Product>
    {
    }
}
