using System;

namespace KataBasket.PriceCalculator
{
    public class MultiBuyDiscountPriceCalculator : IPriceCalculator
    {
        private readonly StandardPriceCalculator _multiPriceCalculator;
        private readonly StandardPriceCalculator _singlePriceCalculator;
        private readonly int _multiBuySize;

        public MultiBuyDiscountPriceCalculator(decimal unitPrice, int multiBuySize, decimal multiBuyPrice)
        {
            if (multiBuySize <= 1)
            {
                throw new ArgumentException("Must be two or greater", nameof(multiBuySize));
            }

            _multiPriceCalculator = new StandardPriceCalculator(multiBuyPrice);
            _singlePriceCalculator = new StandardPriceCalculator(unitPrice);
            _multiBuySize = multiBuySize;
        }

        public decimal Calculate(int itemCount)
        {
            if (itemCount < 0)
            {
                throw new ArgumentException("Must be zero or greater", nameof(itemCount));
            }

            var numberOfDiscountGroups = itemCount / _multiBuySize;
            var undiscountedItemCount = itemCount % _multiBuySize;

            var totalPrice = _multiPriceCalculator.Calculate(numberOfDiscountGroups);
            if(undiscountedItemCount > 0)
            {
                totalPrice += _singlePriceCalculator.Calculate(undiscountedItemCount);
            }

            return totalPrice;
        }
    }
}
