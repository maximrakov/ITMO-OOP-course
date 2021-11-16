using System;
using Banks.Banks;
using Banks.Util;

namespace Banks.BanksStuff
{
    public abstract class Account
    {
        public static int GlobalId { get; set; }
        public int Money { get; set; }
        public int AccountId { get; set; }
        public string Type { get; set; }
        public int Penalty { get; set; }
        public int Procent { get; set; }

        public int GetLimit()
        {
            Bank bank = BankUtils.FindByAccount(AccountId);
            return bank.Limit;
        }

        public void AddMoney(int amount)
        {
            Money += amount;
        }

        public void TakeMoney(int amount)
        {
            Money -= amount;
        }

        public abstract void MakeTransfer(int recipientAccountId, int amount);

        public virtual void CancelTransfer(int recipientAccountId, int amount)
        {
            Bank bank = BankUtils.FindByAccount(recipientAccountId);
            bank.CancelTransfer(AccountId, recipientAccountId, amount);
        }

        public abstract void FixProfit();
        public abstract void AddDought();

        public int LowProcent { get; set; }
        public int MediumProcent { get; set; }
        public int HightProcent { get; set; }
        public int LowBorder { get; set; }
        public int MediumBorder { get; set; }
        public int HighBorder { get; set; }
    }
}
