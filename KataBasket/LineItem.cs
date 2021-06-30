using KataBasket.PriceCalculator;

namespace KataBasket
{
    public class LineItem
    {
        private readonly IPriceCalculator _priceCalculator;
        
        public LineItem(Item item, IPriceCalculator priceCalculator)
        {
            Item = item;
            Count = 1;
            _priceCalculator = priceCalculator;
        }

        public Item Item { get; init; }

        public int Count { get; private set; }

        public decimal TotalPrice => _priceCalculator.Calculate(Count);
    }
}