using System.Collections.Generic;
using Shops.Wrappers;

namespace Shops.Models
{
    public class Person
    {
        public Person(int balance, string name)
        {
            Products = new List<PersonProductInfo>();
            Balance = balance;
            Name = name;
        }

        public int Balance { get; set; }
        public string Name { get; set; }
        public List<PersonProductInfo> Products { get; set; }
    }
}