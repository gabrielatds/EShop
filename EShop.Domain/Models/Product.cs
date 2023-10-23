using EShop.Core.Domain;
using EShop.Core.Domain.Models;
using EShop.Domain.Events.Product;
using EShop.Domain.ValueObjects;

namespace EShop.Domain.Models
{
    public class Product : Entity
    {
        public Category Category { get; private set; }
        public Money Price { get; private set; }
        public string Description { get; private set; }
        public string Name { get; private set; }
        public ProductStatus ProductStatus { get; private set; }

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
            ProductStatus = ProductStatus.Active;
        }

        public void Activate()
        {
            ProductStatus = ProductStatus.Active;
        }

        public void Suspend()
        {
            ProductStatus = ProductStatus.Suspended;
        }

        public void UpdatePrice(decimal preco)
        {
            if (ProductStatus != ProductStatus.Active) throw new BusinessRuleException("Product has to be active!");

            Price = new Money(preco);

            AddEvent(new UpdateProductPriceEvent(Id, Price.Value));
        }
    }
}
