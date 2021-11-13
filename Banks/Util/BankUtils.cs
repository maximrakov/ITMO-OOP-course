using Banks.Banks;
using Banks.Managers;

namespace Banks.Util
{
    public static class BankUtils
    {
        public static CentralBank CentralBank { get; set; }

        public static Bank FindByAccount(int accountId)
        {
            return CentralBank.FindBankByAcccountId(accountId);
        }
    }
}
