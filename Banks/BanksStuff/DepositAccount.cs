using System;

namespace Banks.BanksStuff
{
    public class DepositAccount : Account
    {
        public DepositAccount(int lowProcent, int mediumProcent, int highProcent, int lowBorder, int mediumBorder, int highBorder)
        {
            LowProcent = lowProcent;
            MediumProcent = mediumProcent;
            HightProcent = highProcent;
            LowBorder = lowBorder;
            MediumBorder = mediumBorder;
            HighBorder = highBorder;
            AccountId = GlobalId + 1;
            Money = 100;
            GlobalId++;
            Earn = 0;
            Type = "deposit";
        }

        public override void FixProfit()
        {
            Money += Earn;
            Earn = 0;
        }

        public override void AddDought()
        {
            Console.WriteLine(Money);
            if (Money <= LowBorder)
            {
                Earn += (Money / 100) * LowProcent;
            }
            else
            {
                if (Money <= MediumBorder)
                {
                    Earn += (Money / 100) * MediumProcent;
                }
                else
                {
                    if (Money <= HighBorder)
                    {
                        Earn += (Money / 100) * HightProcent;
                    }
                }
            }

            Console.WriteLine(Earn);
        }

        public int Earn { get; set; }
    }
}
