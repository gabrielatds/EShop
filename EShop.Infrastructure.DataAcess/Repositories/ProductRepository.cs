using EShop.Domain.Interfaces;
using EShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Infrastructure.DataAcess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly EShopContext _context;

        public async Task AddAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
