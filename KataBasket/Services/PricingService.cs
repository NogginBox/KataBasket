using KataBasket.PriceCalculator;

namespace KataBasket.Services
{
    public class PricingService
    {
        public IPriceCalculator GetLineItemPricingCalculator(Item item)
        {
            return item.Sku switch
            {
                "A" => new MultiBuyDiscountPriceCalculator(item.Price, 3, 25),
                "B" => new MultiBuyDiscountPriceCalculator(item.Price, 2, 30),
                _ => new StandardPriceCalculator(item.Price)
            };
        }
    }
}
