using EShop.Core.Domain.Models;
using EShop.Domain.ValueObjects;

namespace EShop.Domain.Models
{
    public class BuyRequest : Entity
    {
        public RequestUser RequestUser { get; set; }
        public IList<Item> Itens { get; set; }
        public DateTime Date { get; set; }
        public Money Total { get; set; }
        public BuyRequestStatus BuyRequestStatus { get; set; }

        public BuyRequest()
        {

        }

        public BuyRequest(RequestUser requestUser, IList<Item> itens, DateTime date, Money total, BuyRequestStatus buyRequestStatus)
        {
            Id = Guid.NewGuid();
            
        }
    }
}
