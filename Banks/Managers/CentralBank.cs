using System;
using System.Collections.Generic;
using Banks.Banks;

namespace Banks.Managers
{
    public class CentralBank
    {
        private List<Bank> banks = new List<Bank>();

        public Bank FindBankByAcccountId(int accountId)
        {
            foreach (Bank bank in banks)
            {
                if (bank.HasAccount(accountId))
                {
                    return bank;
                }
            }

            return null;
        }

        public Bank NewBank()
        {
            var bank = new Bank();
            banks.Add(bank);
            return bank;
        }

        public void AddMoney()
        {
            foreach (Bank bank in banks)
            {
                bank.FixDailySpend();
            }
        }

        public void Charge()
        {
            foreach (Bank bank in banks)
            {
                bank.GetComission();
            }
        }
    }
}
