using KataBasket.Services;
using System.Collections.Generic;
using System.Linq;

namespace KataBasket
{
    public class Basket
    {
        private readonly CatalogueService _catalogueService;
        private readonly PricingService _pricingService;

        public Basket(CatalogueService catalogueService, PricingService pricingService)
        {
            _catalogueService = catalogueService;
            _pricingService = pricingService;
        }

        public decimal TotalPrice => _lineItems.Sum(i => i.Value.TotalPrice);

        public void AddSku(string skuCode)
        {
            var item = _catalogueService.GetItemWithCode(skuCode);
            var pricingCalulator = _pricingService.GetLineItemPricingCalculator(item);
            
            if(_lineItems.ContainsKey(item.Sku))
            {
                _lineItems[item.Sku].AddItem();
            }
            else
            {
                _lineItems.Add(item.Sku, new LineItem(item, pricingCalulator));
            }
        }

        private readonly Dictionary<string, LineItem> _lineItems = new();
    }
}
