using System.Collections.Generic;
using Shops.Wrappers;
namespace Shops.Models
{
    public class Person
    {
        public Person(int balance, string name)
        {
            Products = new List<PersonProductInfo>();
            Balance = new Balance(balance);
            Name = name;
        }

        public void BuyProducts(Shop shop, List<PersonProductInfo> personProduct)
        {
            int cost = shop.GetCostOfProducts(personProduct);
            Balance.Spend(cost);
            shop.MakePurchase(personProduct);

            foreach (PersonProductInfo productInfo in personProduct)
            {
                Products.Add(productInfo);
            }
        }

        public Balance Balance { get; set; }
        public string Name { get; set; }
        public List<PersonProductInfo> Products { get; set; }
    }
}