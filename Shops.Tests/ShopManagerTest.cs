using System;
using System.Collections.Generic;
using NUnit.Framework;
using Shops.Managers;
using Shops.Models;
using Shops.Stuff;
using Shops.Tools;
using Shops.Wrappers;

namespace Shops.Tests
{
    public class Tests
    {
        private ShopManager _shopManager;

        [SetUp]
        public void Setup()
        {
            _shopManager = new ShopManager();
        }
        [Test]
        public void TransferProductsToShop()
        {
            Shop shop = _shopManager.Create("shop1", "adress1");
            Product bread = _shopManager.RegisterProduct("Bread");
            Product milk = _shopManager.RegisterProduct("Milk");
            Product apple = _shopManager.RegisterProduct("Apples");
            var listOfProduct = new List<ShopProductInfo>();
            listOfProduct.Add(new ShopProductInfo(bread, 2, 100));
            listOfProduct.Add(new ShopProductInfo(milk, 3, 200));
            listOfProduct.Add(new ShopProductInfo(apple, 1, 300));
            _shopManager.AddProductsToShop(shop, listOfProduct);
            var listOfPersonProduct = new List<PersonProductInfo>();
            listOfPersonProduct.Add(new PersonProductInfo(bread, 1));
            var person = new Person(1000,"Ivan");
            person.BuyProducts(shop, listOfPersonProduct);
            Assert.AreEqual(listOfProduct[0].Product.Name, person.Products[0].Product.Name);
        }
        [Test]
        public void ChangeCostOfProduct()
        {
            Shop shop = _shopManager.Create("shop1", "adress1");
            Product bread = _shopManager.RegisterProduct("Bread");
            Product milk = _shopManager.RegisterProduct("Milk");
            Product apple = _shopManager.RegisterProduct("Apples");
            var listOfProduct = new List<ShopProductInfo>();
            listOfProduct.Add(new ShopProductInfo(bread, 2, 100));
            listOfProduct.Add(new ShopProductInfo(milk, 3, 200));
            listOfProduct.Add(new ShopProductInfo(apple, 1, 300));
            _shopManager.AddProductsToShop(shop, listOfProduct);
            var listOfPersonProduct = new List<PersonProductInfo>();
            listOfPersonProduct.Add(new PersonProductInfo(bread, 1));
            var person = new Person(1000, "Ivan");
            var person2 = new Person(1000, "Vasiliy");
            person.BuyProducts(shop, listOfPersonProduct);
            shop.ChangeCost(bread, 50);
            person2.BuyProducts(shop, listOfPersonProduct);
            Assert.AreEqual(50, person2.Balance.Money - person.Balance.Money);
        }
        [Test]
        public void FindShopWithLowestPrice()
        {
            Shop shop = _shopManager.Create("shop1", "adress1");
            Shop shop2 = _shopManager.Create("shop2", "address2");
            Product bread = _shopManager.RegisterProduct("Bread");
            Product milk = _shopManager.RegisterProduct("Milk");
            Product apple = _shopManager.RegisterProduct("Apples");

            var listOfProduct = new List<ShopProductInfo>();
            listOfProduct.Add(new ShopProductInfo(bread, 2, 100));
            listOfProduct.Add(new ShopProductInfo(milk, 3, 200));
            listOfProduct.Add(new ShopProductInfo(apple, 1, 300));

            _shopManager.AddProductsToShop(shop, listOfProduct);
            var listOfProduct2 = new List<ShopProductInfo>();
            listOfProduct2.Add(new ShopProductInfo(bread, 2, 10));
            listOfProduct2.Add(new ShopProductInfo(milk, 3, 30));
            listOfProduct2.Add(new ShopProductInfo(apple, 1, 200));
            _shopManager.AddProductsToShop(shop2, listOfProduct2);

            var badListOfPersonProduct = new List<PersonProductInfo>();
            badListOfPersonProduct.Add(new PersonProductInfo(bread, 1));
            badListOfPersonProduct.Add(new PersonProductInfo(milk, 10));

            Assert.Catch<ShopException>(() =>
            {
                Shop shopWithLowestCost = _shopManager.FindShop(badListOfPersonProduct);
            });

            var listOfPersonProduct = new List<PersonProductInfo>();
            listOfPersonProduct.Add(new PersonProductInfo(bread, 2));
            listOfPersonProduct.Add(new PersonProductInfo(milk, 2));

            Shop shopWithLowestCost2 = _shopManager.FindShop(listOfPersonProduct);

            var person = new Person(1000, "Ivan");
            person.BuyProducts(shopWithLowestCost2, listOfPersonProduct);
            Assert.AreEqual(person.Balance.Money, 920);
        }
        [Test]
        public void BuySomepProducts()
        {
            Shop shop = _shopManager.Create("shop1", "adress1");
            Shop shop2 = _shopManager.Create("shop2", "address2");
            Product bread = _shopManager.RegisterProduct("Bread");
            Product milk = _shopManager.RegisterProduct("Milk");
            Product apple = _shopManager.RegisterProduct("Apples");

            var listOfProduct = new List<ShopProductInfo>();
            listOfProduct.Add(new ShopProductInfo(bread, 2, 100));
            listOfProduct.Add(new ShopProductInfo(milk, 3, 200));
            listOfProduct.Add(new ShopProductInfo(apple, 1, 300));

            _shopManager.AddProductsToShop(shop, listOfProduct);
            var listOfProduct2 = new List<ShopProductInfo>();
            listOfProduct2.Add(new ShopProductInfo(bread, 2, 10));
            listOfProduct2.Add(new ShopProductInfo(milk, 3, 30));
            listOfProduct2.Add(new ShopProductInfo(apple, 1, 200));
            _shopManager.AddProductsToShop(shop2, listOfProduct2);

            var listOfPersonProduct = new List<PersonProductInfo>();
            listOfPersonProduct.Add(new PersonProductInfo(bread,2));
            listOfPersonProduct.Add(new PersonProductInfo(milk, 2));

            var person = new Person(100, "Ivan");
            
            Assert.Catch<ShopException>(() =>
            {
                person.BuyProducts(shop, listOfPersonProduct);
            });
            person.BuyProducts(shop2, listOfPersonProduct);
            Assert.AreEqual(person.Balance.Money, 100 - 2 * 10 - 2 * 30);
        }
    }
}