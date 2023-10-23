using EShop.Domain.Models;
using EShop.Domain.ValueObjects;
using System;
using Xunit;

namespace EShop.Domain.Test.Models
{
    public class ItemTests
    {
        [Fact]
        public void CreateItem_Success()
        {
            //Arrange
            var product = BuildProduct();
            var amount = 5;

            //Act
            var item = new Item(product, amount);

            //Assert
            Assert.NotNull(item);
            Assert.Equal(product, item.Product);
            Assert.Equal(amount, item.Amount);
        }

        [Fact]
        public void CreateItem_Error_NullProduct()
        {
            //Arrange
            Product product = null;
            var amount = 5;

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => new Item(product, amount));
        }

        [Fact]
        public void GetSubtotal_Success()
        {
            //Arrange
            var product = BuildProduct();
            var amount = 5;
            var subtotal = product.Price.Value * amount;

            //Act
            var item = new Item(product, amount);

            //Assert
            Assert.Equal(subtotal, item.Subtotal.Value);

        }

        private Product BuildProduct()
        {
            return new Product("Product Test", "Description For Test Product", "Eletronic", 100);
        }
    }
}
