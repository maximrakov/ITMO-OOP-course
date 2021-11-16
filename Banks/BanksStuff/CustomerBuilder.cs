namespace Banks.BanksStuff
{
    public abstract class CustomerBuilder
    {
        protected Customer Customer { get; set; }

        public CustomerBuilder(Customer customer)
        {
            Customer = customer;
        }

        public CustomerBuilder()
        {
        }

        public abstract void BuildName(string name);
        public abstract void BuildSurname(string surname);
        public abstract void BuildAddress(string adress);
        public abstract void BuildPassportData(string passportData);
        public abstract void BuildNotice(bool notice);
        public Customer GetCustomer()
        {
            return Customer;
        }
    }
}
