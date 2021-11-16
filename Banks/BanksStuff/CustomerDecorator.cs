using System;
using System.Collections.Generic;

namespace Banks.BanksStuff
{
    public class CustomerDecorator : ICustomer
    {
        public ICustomer Customer { get; set; }

        public CustomerDecorator(ICustomer customer)
        {
            Customer = customer;
        }

        public CustomerDecorator()
        {
        }

        public virtual void MakeTransfer(int accountId, int accountToId, int amount)
        {
            Console.WriteLine("PPP");
            Customer.MakeTransfer(accountId, accountToId, amount);
        }

        public List<int> GetUserAccounts()
        {
            return Customer.GetUserAccounts();
        }

        public List<int> GetUserMoney()
        {
            return Customer.GetUserMoney();
        }

        public void AddMoreInformation(string address, string passport)
        {
            Customer.AddMoreInformation(address, passport);
        }

        public void AddAccount(Account account)
        {
            Customer.AddAccount(account);
        }

        public void CancelTransfer(int accountId, int accountToId, int amount)
        {
            Customer.CancelTransfer(accountId, accountToId, amount);
        }

        public void AddMoney(int accountId, int amount)
        {
            Customer.AddMoney(accountId, amount);
        }

        public void TakeMoney(int accountId, int amount)
        {
            Customer.TakeMoney(accountId, amount);
        }

        public bool HasThisType(string type)
        {
            return Customer.HasThisType(type);
        }

        public List<Account> GetAccounts()
        {
            return Customer.GetAccounts();
        }

        public string GetName()
        {
            return Customer.GetName();
        }

        public bool GetNotice()
        {
            return GetNotice();
        }

        public List<string> GetMessages()
        {
            return GetMessages();
        }

        public void SetPassword(string password)
        {
            SetPassword(password);
        }

        public void SetAdress(string adress)
        {
            SetAdress(adress);
        }
    }
}
