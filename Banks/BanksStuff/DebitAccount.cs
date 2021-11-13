using System;

namespace Banks.BanksStuff
{
    public class DebitAccount : Account
    {
        public DebitAccount(int procent)
        {
            Procent = procent;
            AccountId = GlobalId + 1;
            GlobalId++;
            Money = 100;
            Consumption = 0;
            Type = "debit";
        }

        public int CurrentSuppl { get; set; }
        public int Consumption { get; set; }

        public override void FixProfit()
        {
            Money += Consumption;
            Consumption = 0;
        }

        public override void AddDought()
        {
            Console.WriteLine(Money);
            Consumption += (Money / 100) * Procent;
            Console.WriteLine(Consumption);
        }
    }
}
