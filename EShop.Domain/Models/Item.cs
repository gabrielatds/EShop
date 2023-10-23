using EShop.Core.Domain.Models;
using EShop.Domain.ValueObjects;

namespace EShop.Domain.Models
{
    public class Item : Entity
    {
        public Product Product { get; private set; }
        public int Amount { get; private set; }

        public Money Subtotal => GetSubtotal();

        public Item(Product product, int amount)
        {
            Product = product ?? throw new ArgumentNullException(nameof(Item.Product));
            Amount = amount;
        }

        public Item()
        {

        }

        private Money GetSubtotal()
        {
            return new Money(Product.Price.Value * Amount);
        }
    }
}
