using EShop.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EShop.Infrastructure.DataAcess
{
    public class EShopContext : DbContext
    {
        public EShopContext(DbContextOptions options) : base(options) { }
        public DbSet<Product> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
                optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=EShop;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
