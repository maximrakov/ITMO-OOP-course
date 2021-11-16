namespace Banks.BanksStuff
{
    public class DebitAccountFactory : IAccountFactory
    {
        public Account CreateAccount()
        {
            return new DebitAccount();
        }
    }
}
