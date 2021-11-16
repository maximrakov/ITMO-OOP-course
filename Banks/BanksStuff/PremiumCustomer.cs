using System;

namespace Banks.BanksStuff
{
    public class PremiumCustomer : CustomerDecorator
    {
        public PremiumCustomer(ICustomer customer, string passwordData, string adress)
        {
            Customer = customer;
            customer.SetAdress(adress);
            customer.SetPassword(passwordData);
        }

        public override void MakeTransfer(int accountId, int accountToId, int amount)
        {
            foreach (Account account in Customer.GetAccounts())
            {
                if (account.AccountId == accountId)
                {
                    account.MakeTransfer(accountToId, amount);
                }
            }
        }

        public void Kek()
        {
            Console.WriteLine("kek");
        }
    }
}
