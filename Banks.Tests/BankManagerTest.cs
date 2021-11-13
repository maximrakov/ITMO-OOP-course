using Banks.Banks;
using Banks.BanksStuff;
using Banks.Managers;
using Banks.Util;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
namespace Banks.Tests
{
    public class Tests
    {
        public CentralBank centralBank;
        public Customer customer;
        public Bank bank;
        [SetUp]
        public void Setup()
        {
            centralBank = new CentralBank();
            BankUtils.CentralBank = centralBank;
            bank = centralBank.NewBank();
            customer = new Customer("Name", "Surname", "Adress", "Passport");
            bank.AddCustomer(customer);
        }
        [Test]
        public void TrasnferMoneyAndCheckPenalty()
        {
            customer.AddAccount(bank.AddDebitAccount(10));
            customer.AddAccount(bank.AddCreditAccount(20));
            customer.MakeTransfer(1, 2, 50);
            Assert.AreEqual(customer.GetUserMoney()[0], 50);
            Assert.AreEqual(customer.GetUserMoney()[1], 150);
            customer.AddAccount(bank.AddDebitAccount(10));
            customer.AddAccount(bank.AddCreditAccount(20));
            customer.MakeTransfer(4, 3, 200);
            Assert.AreEqual(customer.GetUserMoney()[3], -120);
        }
    }
}
