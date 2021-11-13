using System;
using System.Collections.Generic;
using Banks.BanksStuff;
using Banks.ObjectStuff;

namespace Banks.Banks
{
    public class Bank
    {
        private List<Account> accounts;
        private List<Customer> customers;
        private List<MoneyTransfer> moneyTransfers;
        public int Limit { get; set; }
        public Bank()
        {
            accounts = new List<Account>();
            customers = new List<Customer>();
            moneyTransfers = new List<MoneyTransfer>();
            Limit = 1000;
        }

        public Account AddCreditAccount(int penalty)
        {
            Account account = new CreditAccount(penalty);
            accounts.Add(account);
            return account;
        }

        public Account AddDebitAccount(int procent)
        {
            Account account = new DebitAccount(procent);
            accounts.Add(account);
            return account;
        }

        public Account AddDepositAccount(int lowProcent, int mediumProcent, int highProcent, int lowBorder, int mediumBorder, int highBorder)
        {
            Account account = new DepositAccount(lowProcent, mediumProcent, highProcent, lowBorder, mediumBorder, highBorder);
            accounts.Add(account);
            return account;
        }

        public void ChangeCreditPenalty(int penalty)
        {
            foreach (Account account in accounts)
            {
                if (account.Type == "credit")
                {
                    account.Penalty = penalty;
                }
            }

            foreach (Customer customer in customers)
            {
                if (customer.HasThisType("credit"))
                {
                    customer.Notice = true;
                    customer.Messages.Add("Penalty of your credit card has been changed");
                }
            }
        }

        public void ChangeDebitProcent(int procent)
        {
            foreach (Account account in accounts)
            {
                if (account.Type == "debit")
                {
                    account.Procent = procent;
                }
            }

            foreach (Customer customer in customers)
            {
                if (customer.HasThisType("debit"))
                {
                    customer.Notice = true;
                    customer.Messages.Add("Procent of your debit card has been changed");
                }
            }
        }

        public void ChangeDepositProcent(int lowProcent, int mediumProcent, int highProcent)
        {
            foreach (Account account in accounts)
            {
                if (account.Type == "deposit")
                {
                    account.LowProcent = lowProcent;
                    account.MediumProcent = mediumProcent;
                    account.HightProcent = highProcent;
                }
            }

            foreach (Customer customer in customers)
            {
                if (customer.HasThisType("deposit"))
                {
                    customer.Notice = true;
                    customer.Messages.Add("Procent of your deposit card has been changed");
                }
            }
        }

        public void MoneyTransfer(int submitterAccountId, int recipientAccountId, int amount)
        {
            Account submitterAccount = null;
            Account recipientAccount = null;
            foreach (Account account in accounts)
            {
                if (account.AccountId == submitterAccountId)
                {
                    submitterAccount = account;
                }
            }

            foreach (Account account in accounts)
            {
                if (account.AccountId == recipientAccountId)
                {
                    recipientAccount = account;
                }
            }

            submitterAccount.Money -= amount;
            recipientAccount.Money += amount;
            moneyTransfers.Add(new MoneyTransfer(submitterAccount, recipientAccount, amount));
        }

        public void GetComission()
        {
            foreach (Account account in accounts)
            {
                account.FixProfit();
            }
        }

        public void FixDailySpend()
        {
            foreach (Account account in accounts)
            {
                account.AddDought();
            }
        }

        public void AddCustomer(Customer customer)
        {
            customers.Add(customer);
        }

        public bool HasAccount(int accountId)
        {
            foreach (Account account in accounts)
            {
                if (account.AccountId == accountId)
                {
                    return true;
                }
            }

            return false;
        }

        public void CancelTransfer(int submitterAccountId, int recipientAccountId, int amount)
        {
            foreach (MoneyTransfer moneyTransfer in moneyTransfers)
            {
                if (moneyTransfer.SubmitterAccount.AccountId == submitterAccountId && moneyTransfer.RecipientAccount.AccountId == recipientAccountId && moneyTransfer.Amount == amount)
                {
                    moneyTransfer.SubmitterAccount.Money += amount;
                    moneyTransfer.RecipientAccount.Money -= amount;
                }
            }
        }

        public void AddMoneyToAcc(int accountId, int money)
        {
            foreach (Account account in accounts)
            {
                if (account.AccountId == accountId)
                {
                    account.Money += money;
                }
            }
        }
    }
}
