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
        private List<ShopProductInfo> products;

        public Shop(int balance, string name, string adress)
        {
            Id = globalID++;
            Name = name;
            Adress = adress;
            products = new List<ShopProductInfo>();
            Balance = balance;
        }

        public int Balance { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }

        public List<ShopProductInfo> F()
        {
            return products;
        }

        public int TakeSomeProducts(PersonProductInfo productInfo, bool take)
        {
            int cost = 0;
            foreach (ShopProductInfo shopProductInfo in products)
            {
                if (shopProductInfo.Product.Name == productInfo.Product.Name)
                {
                    if (shopProductInfo.Count < productInfo.Count)
                    {
                        throw new ShopException("Shop does not have required amount of product");
                    }

                    cost += productInfo.Count * shopProductInfo.Cost;
                    if (take)
                    {
                        shopProductInfo.Count -= productInfo.Count;
                    }
                }
            }

            return cost;
        }

        public void BuyProducts(Person person, List<PersonProductInfo> productInfo)
        {
            int cost = 0;
            foreach (PersonProductInfo personProductInfo in productInfo)
            {
                cost += TakeSomeProducts(personProductInfo, true);
            }

            if (person.Balance - cost < 0)
            {
                throw new ShopException("Person does not have money");
            }

            foreach (PersonProductInfo personProductInfo in productInfo)
            {
                person.Products.Add(personProductInfo);
            }

            person.Balance -= cost;
        }

        public int TryToBuy(List<PersonProductInfo> productInfo)
        {
            int cost = 0;
            foreach (PersonProductInfo personProductInfo in productInfo)
            {
                cost += TakeSomeProducts(personProductInfo, false);
            }

            return cost;
        }

        public void AddProducts(ShopProductInfo newProducts)
        {
            foreach (ShopProductInfo curProducts in products)
            {
                if (curProducts.Product.Name == newProducts.Product.Name)
                {
                    curProducts.Count += newProducts.Count;
                    curProducts.Cost = newProducts.Cost;
                    return;
                }
            }

            products.Add(newProducts);
        }

        public void ChangeCost(Product product, int newCost)
        {
            if (product is null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            foreach (ShopProductInfo productInfo in products)
            {
                productInfo.Cost = newCost;
            }
        }
    }
}