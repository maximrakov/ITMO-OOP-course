namespace Banks.BanksStuff
{
    public class CustomerCreator
    {
        public CommonCustomerBuilder CommonCustomerBuilder { get; set; }
        public CustomerDirector CustomerDirector { get; set; }

        public ICustomer Creator(string name, string surname)
        {
            CommonCustomerBuilder = new CommonCustomerBuilder(new Customer());
            CustomerDirector = new CustomerDirector();
            CustomerDirector.CustomerBuilder = CommonCustomerBuilder;
            return CustomerDirector.BuildCustomer(name, surname);
        }

        public ICustomer Creator(string name, string surname, string passwordData, string adress)
        {
            CommonCustomerBuilder = new CommonCustomerBuilder(new Customer());
            CustomerDirector = new CustomerDirector();
            CustomerDirector.CustomerBuilder = CommonCustomerBuilder;
            return CustomerDirector.BuildCustomer(name, surname, passwordData, adress);
        }

        public PremiumCustomer ImproveAccount(ICustomer customer, string passwordData, string adress)
        {
            var premium = new PremiumCustomer(customer, passwordData, adress);
            premium.Kek();
            return premium;
        }
    }
}
