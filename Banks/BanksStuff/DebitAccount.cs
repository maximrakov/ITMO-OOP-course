using System;
using Banks.Banks;
using Banks.Util;

namespace Banks.BanksStuff
{
    public class DebitAccount : Account
    {
        public DebitAccount()
        {
            Procent = 10;
            AccountId = GlobalId + 1;
            GlobalId++;
            Money = 100;
            Consumption = 0;
            Penalty = 0;
            Type = "debit";
        }

        public int CurrentSuppl { get; set; }
        public int Consumption { get; set; }

        public override void MakeTransfer(int recipientAccountId, int amount)
        {
            Bank bank = BankUtils.FindByAccount(recipientAccountId);
            bank.MoneyTransfer(AccountId, recipientAccountId, amount);
        }

        public override void FixProfit()
        {
            Money += Consumption;
            Consumption = 0;
        }

        public override void AddDought()
        {
            Consumption += (Money / 100) * Procent;
        }
    }
}
