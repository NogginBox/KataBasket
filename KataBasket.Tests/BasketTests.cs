using KataBasket.Services;
using Xunit;

namespace KataBasket.Tests
{
    public class BasketTests
    {
        private readonly Basket _basket;

        public BasketTests()
        {
            // Arrange
            var catalogueService = new CatalogueService();
            var pricingService = new PricingService();
            _basket = new Basket(catalogueService, pricingService);
        }

        [Fact]
        public void EmptyBasketHasZeroTotal()
        {
            // Act / Assert
            Assert.Equal(0, _basket.TotalPrice);
        }

        [Fact]
        public void AddSingleItemShowsTotalForItem()
        {
            // Arrange
            const decimal priceOfA = 10m;

            // Act
            _basket.AddSku("A");

            // Assert
            Assert.Equal(priceOfA, _basket.TotalPrice);

        }

        [Fact]
        public void AddTwoDifferentItemShowsTotalForAllItems()
        {
            // Arrange
            const decimal priceOfAAndB = 30m;

            // Act
            _basket.AddSku("A");
            _basket.AddSku("B");

            // Assert
            Assert.Equal(priceOfAAndB, _basket.TotalPrice);

        }

        [Theory]
        [InlineData("A", 3, 25)]
        [InlineData("B", 2, 30)]
        public void AddExactItemsGivesDiscount(string sku, int itemCount, decimal expectedPrice)
        {
            HasCorrectPrice(sku, itemCount, expectedPrice);
        }

        [Theory]
        [InlineData("A", 4, 35)]
        [InlineData("B", 3, 50)]
        public void AddMoreItemsGivesDiscountOnlyOnMultiBuyItems(string sku, int itemCount, decimal expectedPrice)
        {
            HasCorrectPrice(sku, itemCount, expectedPrice);
        }

        private void HasCorrectPrice(string sku, int itemCount, decimal expectedPrice)
        {
            // Act
            for(var i=0; i<itemCount; i++)
            {
                _basket.AddSku(sku);
            }

            // Assert
            Assert.Equal(expectedPrice, _basket.TotalPrice);
        }
    }

    
}