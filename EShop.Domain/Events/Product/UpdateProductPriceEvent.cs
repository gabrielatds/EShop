using EShop.Core.Domain;

namespace EShop.Domain.Events.Product
{
    public class UpdateProductPriceEvent : Event
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }

        public UpdateProductPriceEvent(Guid id, decimal price)
        {
            Id = id;
            Price = price;
        }
    }
}
