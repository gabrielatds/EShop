using MediatR;

namespace EShop.Core.Domain
{
    public abstract class Event : INotification
    {
        public DateTime OcurrencyDate => DateTime.Now;
    }
}
