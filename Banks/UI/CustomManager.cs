using System;
using System.Collections.Generic;
using Banks.Banks;
using Banks.BanksStuff;
using Banks.Managers;
using Banks.Util;

namespace Banks.UI
{
    public class CustomManager
    {
        private CentralBank centralBank;
        private Bank bank;
        private ICustomer customer;
        public CustomManager()
        {
            centralBank = new CentralBank();
            bank = centralBank.NewBank();
            BankUtils.CentralBank = centralBank;
        }

        public void RegisterAccount(string name, string surname)
        {
            var customerCreator = new CustomerCreator();
            customer = customerCreator.Creator(name, surname);
            bank.AddCustomer(customer);
        }

        public void MakeAccount(string tp)
        {
            customer.AddAccount(bank.CreateAccount(tp));
        }

        public void RegisterAccount(string name, string surname, string passwordData, string adress)
        {
            var customerCreator = new CustomerCreator();
            customer = customerCreator.Creator(name, surname, passwordData, adress);
            bank.AddCustomer(customer);
        }

        public void GetState()
        {
            List<int> names = customer.GetUserAccounts();
            List<int> money = customer.GetUserMoney();
            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine(names[i] + " " + money[i]);
            }
        }

        public void Improve(string password, string adress)
        {
            var customerCreator = new CustomerCreator();
            PremiumCustomer premium = customerCreator.ImproveAccount(customer, password, adress);
            customer = customerCreator.ImproveAccount(customer, password, adress);
        }

        public void Put(int amount, int accountId)
        {
            customer.AddMoney(accountId, amount);
        }

        public void Take(int amount, int accountId)
        {
            customer.TakeMoney(amount, accountId);
        }

        public void Transfer(int sender, int taker, int amount)
        {
            customer.MakeTransfer(sender, taker, amount);
        }

        public void CancelTransfer(int senderId, int takerId, int amount)
        {
            customer.CancelTransfer(senderId, takerId, amount);
        }
    }
}