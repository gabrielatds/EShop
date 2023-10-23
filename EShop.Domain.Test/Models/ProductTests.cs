using EShop.Core.Domain;
using EShop.Domain.Models;
using EShop.Domain.ValueObjects;
using System;
using Xunit;

namespace EShop.Domain.Test.Models
{
    public class ProductTests
    {
        [Fact]
        public void CreateProduct_Success()
        {
            //Arrange
            var name = "Name";
            var description = "Description";
            var category = "Eletronic";
            var price = 10;

            //Act
            var product = new Product(name, description, category, price);

            //Assert
            Assert.NotNull(product);
            Assert.Equal(name, product.Name);
            Assert.Equal(description, product.Description);
            Assert.Equal(Category.Eletronic, product.Category);
            Assert.Equal(price, product.Price.Value);
            Assert.Equal(ProductStatus.Active, product.ProductStatus);
        }

        [Fact]
        public void CreateProduct_Error_NullName()
        {
            //Arrange
            var description = "Description";
            var category = "Eletronic";
            var price = 10;

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Product(null, description, category, price));
        }

        [Fact]
        public void CreateProduct_Error_NullDescription()
        {
            //Arrange
            var name = "Name";
            var category = "Eletronic";
            var price = 10;

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Product(name, null, category, price));
        }

        [Fact]
        public void ActivateProduct_Success()
        {
            //Arrange
            var name = "Name";
            var description = "Description";
            var category = "Eletronic";
            var price = 10;
            var product = new Product(name, description, category, price);
            product.Suspend();

            //Act
            product.Activate();

            //Assert
            Assert.Equal(ProductStatus.Active, product.ProductStatus);
        }

        [Fact]
        public void SuspendProduct_Success()
        {
            //Arrange
            var name = "Name";
            var description = "Description";
            var category = "Eletronic";
            var price = 10;
            var product = new Product(name, description, category, price);

            //Act
            product.Suspend();

            //Assert
            Assert.Equal(ProductStatus.Suspended, product.ProductStatus);
        }

        [Fact]
        public void UpdatePrice_Success()
        {
            //Arrange
            var name = "Name";
            var description = "Description";
            var category = "Eletronic";
            var price = 10;
            var product = new Product(name, description, category, price);

            //Act
            var newPrice = 20;
            product.UpdatePrice(newPrice);

            //Assert
            Assert.Equal(newPrice, product.Price.Value);
            Assert.NotEmpty(product.Events);
        }

        [Fact]
        public void UpdatePrice_Error_SuspendedProduct()
        {
            //Arrange
            var name = "Name";
            var description = "Description";
            var category = "Eletronic";
            var price = 10;
            var product = new Product(name, description, category, price);
            product.Suspend();

            //Act & Assert
            var newPrice = 20;
           
            Assert.Throws<BusinessRuleException>(() => product.UpdatePrice(newPrice));
        }
    }
}