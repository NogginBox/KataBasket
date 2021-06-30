using KataBasket.PriceCalculator;
using System;
using Xunit;

namespace KataBasket.Tests.PriceCalculator
{
    public class MultiBuyDisountPriceCalculatorTests
    {
        [Fact]
        public void ZeroItemsHaveZeroPrice()
        {
            // Arrange
            var priceCalc = new MultiBuyDiscountPriceCalculator(9.0m, 3, 5.1m);

            // Act
            var price = priceCalc.Calculate(0);

            // Assert
            Assert.Equal(0, price);
        }

        [Theory]
        [InlineData(2, 4.1, 2, 3.5, 3.5)]
        [InlineData(4, 4.1, 2, 3.5, 7)]
        [InlineData(9, 8.1, 3, 3.1, 9.3)]
        public void MultibuyExactSizeMatchHasCorrectPrice(int itemCount, decimal unitPrice, int multiCount, decimal multiPrice, decimal expectedPrice)
        {
            HasCorrectPrice(itemCount, unitPrice, multiCount, multiPrice, expectedPrice);
        }

        [Theory]
        [InlineData(1, 4.1, 2, 3.5, 4.1)]
        [InlineData(5, 4.1, 2, 3.5, 11.1)]
        [InlineData(11, 8.1, 3, 3.1, 25.5)]
        public void MultibuyWithUndiscountedItemsHasCorrectPrice(int itemCount, decimal unitPrice, int multiCount, decimal multiPrice, decimal expectedPrice)
        {
            HasCorrectPrice(itemCount, unitPrice, multiCount, multiPrice, expectedPrice);
        }

        private void HasCorrectPrice(int itemCount, decimal unitPrice, int multiCount, decimal multiPrice, decimal expectedPrice)
        {
            // Arrange
            var priceCalc = new MultiBuyDiscountPriceCalculator(unitPrice, multiCount, multiPrice);

            // Act
            var price = priceCalc.Calculate(itemCount);

            // Assert
            Assert.Equal(expectedPrice, price);
        }

        [Fact]
        public void NegatveItemCountThrowsBadArgException()
        {
            // Arrange
            var priceCalc = new MultiBuyDiscountPriceCalculator(9.0m, 3, 5.1m);

            // Act / Assert
            Assert.Throws<ArgumentException>(() => priceCalc.Calculate(-1));
        }
    }
}
