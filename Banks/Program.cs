using System;
using System.Collections.Generic;
using Banks.Banks;
using Banks.BanksStuff;
using Banks.Managers;
using Banks.Util;

namespace Banks
{
    internal static class Program
    {
        private static CentralBank centralBank;
        public static Customer RegisterUser(Bank bank)
        {
            Console.WriteLine("Input Name Surname Adress Passport");
            string name = Console.ReadLine();
            string surname = Console.ReadLine();
            string adress = Console.ReadLine();
            string passport = Console.ReadLine();
            var customer = new Customer(name, surname, adress, passport);
            bank.AddCustomer(customer);
            return customer;
        }

        public static void MoreInfo(Customer customer)
        {
            string address = Console.ReadLine();
            string passport = Console.ReadLine();
            customer.AddMoreInformation(address, passport);
        }

        public static void GetState(Customer customer)
        {
            List<int> names = customer.GetUserAccounts();
            List<int> money = customer.GetUserMoney();
            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine(names[i] + " " + money[i]);
            }
        }

        private static void Main()
        {
            centralBank = new CentralBank();
            BankUtils.CentralBank = centralBank;
            Bank bank = centralBank.NewBank();
            Customer customer = RegisterUser(bank);
            int procent = 10;
            int sum = 1000;
            int penalty = 20;
            while (true)
            {
                bank.ChangeCreditPenalty(50);
                string cmd;
                cmd = Console.ReadLine();
                if (customer.Notice)
                {
                    List<string> news = customer.Messages;
                    foreach (string curNews in news)
                    {
                        Console.WriteLine(curNews);
                    }

                    customer.Notice = false;
                }

                if (cmd == "view")
                {
                    GetState(customer);
                }

                if (cmd == "newAccount")
                {
                    string tp = Console.ReadLine();
                    if (tp == "debit")
                    {
                        customer.AddAccount(bank.AddDebitAccount(procent));
                    }

                    if (tp == "deposit")
                    {
                        customer.AddAccount(bank.AddDepositAccount(procent, procent * 2, procent * 3, sum, sum * 2, sum * 3));
                    }

                    if (tp == "credit")
                    {
                        customer.AddAccount(bank.AddCreditAccount(penalty));
                    }
                }

                if (cmd == "sal")
                {
                    centralBank.AddMoney();
                }

                if (cmd == "month")
                {
                    centralBank.Charge();
                }

                if (cmd == "transfer")
                {
                    string val = Console.ReadLine();
                    int senderId = Convert.ToInt32(val);
                    val = Console.ReadLine();
                    int takerId = Convert.ToInt32(val);
                    val = Console.ReadLine();
                    int amount = Convert.ToInt32(val);
                    customer.MakeTransfer(senderId, takerId, amount);
                }

                if (cmd == "cnl")
                {
                    string val = Console.ReadLine();
                    int senderId = Convert.ToInt32(val);
                    val = Console.ReadLine();
                    int takerId = Convert.ToInt32(val);
                    val = Console.ReadLine();
                    int amount = Convert.ToInt32(val);
                    customer.CancelTransfer(senderId, takerId, amount);
                }

                if (cmd == "put")
                {
                    string val = Console.ReadLine();
                    int amount = Convert.ToInt32(val);
                    val = Console.ReadLine();
                    int accountId = Convert.ToInt32(val);
                    customer.AddMoney(accountId, amount);
                }

                if (cmd == "take")
                {
                    string val = Console.ReadLine();
                    int amount = Convert.ToInt32(val);
                    val = Console.ReadLine();
                    int accountId = Convert.ToInt32(val);
                    customer.TakeMoney(accountId, amount);
                }

                if (cmd == "mInfo")
                {
                    MoreInfo(customer);
                }
            }
        }
    }
}
