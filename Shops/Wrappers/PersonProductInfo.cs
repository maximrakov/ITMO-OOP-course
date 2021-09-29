using Shops.Stuff;

namespace Shops.Wrappers
{
    public class PersonProductInfo : ProductInfo
    {
        public PersonProductInfo(Product product, int count)
            : base(product, count)
        {
        }
    }
}