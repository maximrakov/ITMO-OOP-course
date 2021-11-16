namespace Banks.BanksStuff
{
    public class DepositAccountFactory : IAccountFactory
    {
        public Account CreateAccount()
        {
            return new DepositAccount();
        }
    }
}
