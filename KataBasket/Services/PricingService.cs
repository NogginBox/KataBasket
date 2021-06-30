using KataBasket.PriceCalculator;

namespace KataBasket.Services
{
    public class PricingService
    {
        public IPriceCalculator GetLineItemPricingCalculator(Item item)
        {
            return item.Sku switch
            {
                _ => new StandardPriceCalculator(item.Price)
            };
        }
    }
}
