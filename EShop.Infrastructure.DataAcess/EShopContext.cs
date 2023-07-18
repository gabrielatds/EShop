using EShop.Core.Domain;
using EShop.Domain.Models;
using EShop.Infrastructure.DataAcess.Configurations;
using Microsoft.EntityFrameworkCore;

namespace EShop.Infrastructure.DataAcess
{
    public class EShopContext : DbContext
    {
        public EShopContext(DbContextOptions options) : base(options) { }
        public DbSet<Product> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.Ignore<Event>();
        }
    }
}
