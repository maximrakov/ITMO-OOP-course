using System;
using Banks.Banks;
using Banks.Util;

namespace Banks.BanksStuff
{
    public class CreditAccount : Account
    {
        public CreditAccount()
        {
            Penalty = 20;
            AccountId = GlobalId + 1;
            GlobalId++;
            Money = 100;
            Type = "credit";
        }

        public override void MakeTransfer(int recipientAccountId, int amount)
        {
            if (Money < amount)
            {
                Money -= Penalty;
            }

            Bank bank = BankUtils.FindByAccount(recipientAccountId);
            bank.MoneyTransfer(AccountId, recipientAccountId, amount);
        }

        public override void FixProfit()
        {
        }

        public override void AddDought()
        {
        }
    }
}
