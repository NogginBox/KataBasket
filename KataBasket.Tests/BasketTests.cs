using Xunit;

namespace KataBasket.Tests
{
    public class BasketTests
    {
        private Basket _basket;

        public BasketTests()
        {
            // Arrange
            var catalogueService = new CatalogueService();
            _basket = new Basket(catalogueService);
        }

        [Fact]
        public void EmptyBasketHasZeroTotal()
        {
            // Act / Assert
            Assert.Equal(0, _basket.Total);
        }

        [Fact]
        public void AddSingleItemShowsTotalForItem()
        {
            // Arrange
            const decimal priceOfA = 10m;

            // Act
            _basket.AddSku("A");

            // Assert
            Assert.Equal(priceOfA, _basket.Total);

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
            Assert.Equal(priceOfAAndB, _basket.Total);

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
            Assert.Equal(discountedPrice, _basket.Total);
        }
    }

    
}