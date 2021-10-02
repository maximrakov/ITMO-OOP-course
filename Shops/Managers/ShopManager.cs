using System.Collections.Generic;
using Shops.Models;
using Shops.Stuff;
using Shops.Tools;
using Shops.Wrappers;

namespace Shops.Managers
{
    public class ShopManager
    {
        private List<Shop> _shops = new List<Shop>();
        private List<Product> _products = new List<Product>();
        public Shop Create(string name, string adress)
        {
            var newShop = new Shop(0, name, adress);
            _shops.Add(newShop);
            return newShop;
        }

        public Product RegisterProduct(string productName)
        {
            var newProduct = new Product(productName);
            _products.Add(newProduct);
            return newProduct;
        }

        public void AddProductsToShop(Shop shop, List<ShopProductInfo> products)
        {
            foreach (ShopProductInfo product in products)
            {
                shop.AddProducts(product);
            }
        }

        public Shop FindShop(List<PersonProductInfo> productInfo)
        {
            Shop cheapest = null;
            int minCost = int.MaxValue;
            foreach (Shop shop in _shops)
            {
                if (shop.IsBuyPossible(productInfo))
                {
                    if (shop.GetCostOfProducts(productInfo) < minCost)
                    {
                        minCost = shop.GetCostOfProducts(productInfo);
                        cheapest = shop;
                    }
                }
            }

            if (cheapest == null)
            {
                throw new ShopException("Required shop does not exist");
            }

            return cheapest;
        }
    }
}