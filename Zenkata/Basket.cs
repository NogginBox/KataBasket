using System;
using System.Collections.Generic;

namespace Zenkata
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

    public class LineItem
    {
        public Item Item { get; set; }

        public int Count { get; set; }
    }
}
