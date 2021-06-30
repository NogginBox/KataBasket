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

        [Fact]
        public void Add3ItemsGivesDiscount()
        {
            // Arrange
            const decimal discountedPrice = 25m;

            // Act
            _basket.AddSku("A");
            _basket.AddSku("A");
            _basket.AddSku("A");

            // Assert
            Assert.Equal(discountedPrice, _basket.TotalPrice);
        }
    }

    
}