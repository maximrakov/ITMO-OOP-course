using Banks.BanksStuff;

namespace Banks.ObjectStuff
{
    public class MoneyTransfer
    {
        public Account SubmitterAccount { get; set; }
        public Account RecipientAccount { get; set; }
        public int Amount { get; set; }
        public MoneyTransfer(Account submitter, Account recipient, int amount)
        {
            SubmitterAccount = submitter;
            RecipientAccount = recipient;
            Amount = amount;
        }
    }
}
