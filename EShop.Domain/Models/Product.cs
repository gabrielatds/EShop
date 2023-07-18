using EShop.Core.Domain;
using EShop.Core.Domain.Models;
using EShop.Domain.Events.Product;
using EShop.Domain.ValueObjects;

namespace EShop.Domain.Models
{
    public class Product : Entity
    {
        public Category Category { get; set; }
        public Money Price { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public Status Status { get; set; }

        private Product()
        {
        }

        public Product(string name, string description, string category, decimal price)
        {
            Id = Guid.NewGuid();
            Name = name ?? throw new ArgumentNullException(nameof(Name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Price = new Money(price);
            Category = (Category)Enum.Parse(typeof(Category), category);
            Status = Status.Active;
        }

        public void Activate()
        {
            Status = Status.Active;
        }

        public void Suspend()
        {
            Status = Status.Suspended;
        }

        public void UpdatePrice(decimal preco)
        {
            if (Status != Status.Active) throw new BusinessRuleException("Product has to be active!");

            Price = new Money(preco);

            AddEvent(new UpdateProductPriceEvent(Id, Price.Value));
        }
    }
}
