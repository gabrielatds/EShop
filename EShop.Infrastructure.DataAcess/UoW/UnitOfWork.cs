using System;

namespace EShop.Infrastructure.DataAcess.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EShopContext eShopContext;

        public UnitOfWork(EShopContext context)
        {
            eShopContext = context;
        }

        public bool Commit()
        {
            return eShopContext.SaveChanges() > 0;
        }

        public void Dispose()
        {
            eShopContext.Dispose();
        }
    }
}
