using System;
using System.Collections.Generic;

namespace Banks.BanksStuff
{
    public class Customer
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string PassportData { get; set; }
        public bool Notice { get; set; }
        private List<Account> accounts;
        public List<string> Messages { get; set; }
        public Customer(string name, string surname, string address, string passwordData)
        {
            Name = name;
            Surname = surname;
            Address = address;
            PassportData = passwordData;
            accounts = new List<Account>();
            Messages = new List<string>();
            Notice = false;
        }

        public void MakeTransfer(int accountId, int accountToId, int amount)
        {
            foreach (Account account in accounts)
            {
                if (account.AccountId == accountId)
                {
                    if ((Address.Length <= 1 || PassportData.Length <= 1) && (account.GetLimit() < amount))
                    {
                        Console.WriteLine("Limit is exceeded");
                    }
                    else
                    {
                        account.MakeTransfer(accountToId, amount);
                    }
                }
            }
        }

        public List<int> GetUserAccounts()
        {
            var vs = new List<int>();
            foreach (Account account in accounts)
            {
                vs.Add(account.AccountId);
            }

            return vs;
        }

        public List<int> GetUserMoney()
        {
            var vs = new List<int>();
            foreach (Account account in accounts)
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
            accounts.Add(account);
        }

        public void CancelTransfer(int accountId, int accountToId, int amount)
        {
            foreach (Account account in accounts)
            {
                if (account.AccountId == accountId)
                {
                    account.CancelTransfer(accountToId, amount);
                }
            }
        }

        public void AddMoney(int accountId, int amount)
        {
            foreach (Account account in accounts)
            {
                if (account.AccountId == accountId)
                {
                    account.AddMoney(amount);
                }
            }
        }

        public void TakeMoney(int accountId, int amount)
        {
            foreach (Account account in accounts)
            {
                if (account.AccountId == accountId)
                {
                    account.TakeMoney(amount);
                }
            }
        }

        public bool HasThisType(string type)
        {
            foreach (Account account in accounts)
            {
                if (account.Type == type)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
