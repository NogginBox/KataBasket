using KataBasket.PriceCalculator;
using System;
using Xunit;

namespace KataBasket.Tests.PriceCalculator
{
    public class StandardPriceCalculatorTests
    {
        [Fact]
        public void ZeroItemsHaveZeroPrice()
        {
            // Arrange
            var priceCalc = new StandardPriceCalculator(5.0m);

            // Act
            var price = priceCalc.Calculate(0);

            // Assert
            Assert.Equal(0, price);
        }

        [Theory]
        [InlineData(1, 4.1, 4.1)]
        [InlineData(2, 4.1, 8.2)]
        [InlineData(999, 20.9, 20879.1)]
        public void PositiveCountOfItemHasCorrectPrice(int itemCount, decimal unitPrice, decimal expectedPrice)
        {
            // Arrange
            var priceCalc = new StandardPriceCalculator(unitPrice);

            // Act
            var price = priceCalc.Calculate(itemCount);

            // Assert
            Assert.Equal(expectedPrice, price);
        }

        [Fact]
        public void NegatveItemCountThrowsBadArgException()
        {
            // Arrange
            var priceCalc = new StandardPriceCalculator(10m);

            // Act / Assert
            Assert.Throws<ArgumentException>(() => priceCalc.Calculate(-1));
        }
    }
}
