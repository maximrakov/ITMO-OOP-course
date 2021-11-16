namespace Banks.BanksStuff
{
    public class CreditAccountFactory : IAccountFactory
    {
        public Account CreateAccount()
        {
            return new CreditAccount();
        }
    }
}
