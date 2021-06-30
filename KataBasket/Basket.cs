using System.Collections.Generic;

namespace KataBasket
{
    public class Basket
    {
        private readonly CatalogueService _catalogueService;

        public Basket(CatalogueService catalogueService)
        {
            _catalogueService = catalogueService;
        }

        public int Total { get; private set; }

        public void AddSku(string skuCode)
        {
            var item = _catalogueService.GetItemWithCode(skuCode);

            _lineItems.Add(item.Sku, item);
        }

        private Dictionary<string, LineItem> _lineItems = new Dictionary<string, LineItem>();
    }
}
