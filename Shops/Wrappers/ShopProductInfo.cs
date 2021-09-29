using Shops.Stuff;

namespace Shops.Wrappers
{
    public class ShopProductInfo : ProductInfo
    {
        public ShopProductInfo(Product product, int count, int cost)
            : base(product, count)
        {
            Cost = cost;
        }

        public int Cost { get; set; }
    }
}