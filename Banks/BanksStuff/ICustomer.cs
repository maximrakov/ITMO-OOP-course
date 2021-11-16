using System.Collections.Generic;

namespace Banks.BanksStuff
{
    public interface ICustomer
    {
        public void MakeTransfer(int accountId, int accountToId, int amount);

        public List<int> GetUserAccounts();

        public List<int> GetUserMoney();

        public void AddMoreInformation(string address, string passport);

        public void AddAccount(Account account);

        public void CancelTransfer(int accountId, int accountToId, int amount);

        public void AddMoney(int accountId, int amount);

        public void TakeMoney(int accountId, int amount);

        public bool HasThisType(string type);

        public List<Account> GetAccounts();

        public string GetName();

        public bool GetNotice();

        public List<string> GetMessages();

        public void SetPassword(string password);

        public void SetAdress(string adress);
    }
}
