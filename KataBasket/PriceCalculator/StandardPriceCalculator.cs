using System;

namespace KataBasket.PriceCalculator
{

    public class StandardPriceCalculator : IPriceCalculator
    {
        private decimal _unitPrice;

        public StandardPriceCalculator(decimal unitPrice)
        {
            _unitPrice = unitPrice;
        }

        public decimal Calculate(int itemCount)
        {
            if(itemCount < 0)
            {
                throw new ArgumentException("Must be zero or greater", nameof(itemCount));
            }
            return _unitPrice * itemCount;
        }
    }
}
