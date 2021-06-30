using System;

namespace Zenkata
{
    public class CatalogueService
    {
        public Item GetItemWithCode(string skuCode)
        {
            return skuCode switch
            {
                "A" => new Item { Sku = "A", Price = new Price { Amount = 10 } },
                "B" => new Item { Sku = "B", Price = new Price { Amount = 20 } },
                "C" => new Item { Sku = "C", Price = new Price { Amount = 30 } },
                _ => throw new Exception($"Item with Sku {skuCode} not found")
            };
        }
    }
}