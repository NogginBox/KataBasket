using System;

namespace KataBasket.Services
{
    public class CatalogueService
    {
        public Item GetItemWithCode(string skuCode)
        {
            return skuCode switch
            {
                "A" => new Item { Sku = "A", Price = 10 },
                "B" => new Item { Sku = "B", Price = 20 },
                "C" => new Item { Sku = "C", Price = 30 },
                _ => throw new Exception($"Item with Sku {skuCode} not found")
            };
        }
    }
}