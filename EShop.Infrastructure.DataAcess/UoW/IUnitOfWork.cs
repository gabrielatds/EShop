namespace EShop.Infrastructure.DataAcess.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
