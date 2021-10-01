using System;
using System.Collections.Generic;
using Shops.Stuff;
using Shops.Tools;
using Shops.Wrappers;

namespace Shops.Models
{
    public class Shop
    {
        private static int globalID;
        private List<ShopProductInfo> _products;

        public Shop(int balance, string name, string adress)
        {
            Id = globalID++;
            Name = name;
            Adress = adress;
            _products = new List<ShopProductInfo>();
            Balance = new Balance(balance);
        }

        public Balance Balance { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }

        public bool CanBuy(List<PersonProductInfo> personProductInfo)
        {
            foreach (PersonProductInfo personProduct in personProductInfo)
            {
                foreach (ShopProductInfo shopProduct in _products)
                {
                    if (shopProduct.Product.Name == personProduct.Product.Name && shopProduct.Count < personProduct.Count)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public int GetCostOfProducts(List<PersonProductInfo> personProductInfo)
        {
            int cost = 0;
            foreach (PersonProductInfo personProduct in personProductInfo)
            {
                foreach (ShopProductInfo shopProduct in _products)
                {
                    if (shopProduct.Product.Name == personProduct.Product.Name)
                    {
                        cost += shopProduct.Cost * personProduct.Count;
                    }
                }
            }

            return cost;
        }

        public void RemoveSoldStuff(List<PersonProductInfo> personProductInfo)
        {
            foreach (PersonProductInfo personProduct in personProductInfo)
            {
                foreach (ShopProductInfo shopProduct in _products)
                {
                    if (shopProduct.Product.Name == personProduct.Product.Name && shopProduct.Count < personProduct.Count)
                    {
                        shopProduct.Count -= personProduct.Count;
                    }
                }
            }
        }

        public int MakePurchase(List<PersonProductInfo> personProductInfo)
        {
            if (!CanBuy(personProductInfo))
            {
                throw new ShopException("Shop does not have required amount of product");
            }

            RemoveSoldStuff(personProductInfo);
            Balance.Receive(GetCostOfProducts(personProductInfo));
            return GetCostOfProducts(personProductInfo);
        }

        public void AddProducts(ShopProductInfo newProducts)
        {
            foreach (ShopProductInfo curProducts in _products)
            {
                if (curProducts.Product.Name == newProducts.Product.Name)
                {
                    curProducts.Count += newProducts.Count;
                    curProducts.Cost = newProducts.Cost;
                    return;
                }
            }

            _products.Add(newProducts);
        }

        public void ChangeCost(Product product, int newCost)
        {
            if (product is null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            foreach (ShopProductInfo productInfo in _products)
            {
                productInfo.Cost = newCost;
            }
        }
    }
}