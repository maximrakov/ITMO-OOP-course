using Shops.Stuff;

namespace Shops.Wrappers
{
    public abstract class ProductInfo
    {
        public ProductInfo(Product product, int count)
        {
            Product = product;
            Count = count;
        }

        public Product Product { get; }
        public int Count { get; set; }
    }
}