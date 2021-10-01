using Shops.Tools;

namespace Shops.Models
{
    public class Balance
    {
        public Balance(int money)
        {
            Money = money;
        }

        public void Spend(int amount)
        {
            if (Money < amount)
            {
                throw new ShopException("Person does not have money");
            }

            Money -= amount;
        }

        public void Receive(int amount)
        {
            Money += amount;
        }

        public int Money { get; set; }
    }
}
