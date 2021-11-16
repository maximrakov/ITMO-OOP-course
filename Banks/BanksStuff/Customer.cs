using System;
using System.Collections.Generic;

namespace Banks.BanksStuff
{
    public class Customer : ICustomer
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string PassportData { get; set; }
        public bool Notice { get; set; }
        public List<Account> Accounts { get; set; }
        public List<string> Messages { get; set; }
        public Customer()
        {
            Accounts = new List<Account>();
            Messages = new List<string>();
        }

        public Customer(string name, string surname, string address, string passwordData)
        {
            Name = name;
            Surname = surname;
            Address = address;
            PassportData = passwordData;
            Accounts = new List<Account>();
            Messages = new List<string>();
            Notice = false;
        }

        public void MakeTransfer(int accountId, int accountToId, int amount)
        {
            foreach (Account account in Accounts)
            {
                if (account.AccountId == accountId)
                {
                    account.MakeTransfer(accountToId, amount);
                }
            }
        }

        public List<int> GetUserAccounts()
        {
            var vs = new List<int>();
            foreach (Account account in Accounts)
            {
                vs.Add(account.AccountId);
            }

            return vs;
        }

        public List<int> GetUserMoney()
        {
            var vs = new List<int>();
            foreach (Account account in Accounts)
            {
                vs.Add(account.Money);
            }

            return vs;
        }

        public void AddMoreInformation(string address, string passport)
        {
            if (address is null)
            {
                throw new ArgumentNullException(nameof(address));
            }

            if (passport is null)
            {
                throw new ArgumentNullException(nameof(passport));
            }

            Address = address;
            PassportData = passport;
        }

        public void AddAccount(Account account)
        {
            Accounts.Add(account);
        }

        public void CancelTransfer(int accountId, int accountToId, int amount)
        {
            foreach (Account account in Accounts)
            {
                if (account.AccountId == accountId)
                {
                    account.CancelTransfer(accountToId, amount);
                }
            }
        }

        public void AddMoney(int accountId, int amount)
        {
            foreach (Account account in Accounts)
            {
                if (account.AccountId == accountId)
                {
                    account.AddMoney(amount);
                }
            }
        }

        public void TakeMoney(int accountId, int amount)
        {
            foreach (Account account in Accounts)
            {
                if (account.AccountId == accountId)
                {
                    account.TakeMoney(amount);
                }
            }
        }

        public List<Account> GetAccounts()
        {
            return Accounts;
        }

        public bool HasThisType(string type)
        {
            foreach (Account account in Accounts)
            {
                if (account.Type == type)
                {
                    return true;
                }
            }

            return false;
        }

        public string GetName()
        {
            return Name;
        }

        public bool GetNotice()
        {
            return Notice;
        }

        public List<string> GetMessages()
        {
            return Messages;
        }

        public void SetPassword(string password)
        {
            PassportData = password;
        }

        public void SetAdress(string adress)
        {
            Address = adress;
        }
    }
}
