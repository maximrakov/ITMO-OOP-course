namespace Banks.BanksStuff
{
    public class CommonCustomerBuilder : CustomerBuilder
    {
        public CommonCustomerBuilder(Customer customer)
        {
            Customer = customer;
        }

        public override void BuildAddress(string adress)
        {
            Customer.Address = adress;
        }

        public override void BuildName(string name)
        {
            Customer.Name = name;
        }

        public override void BuildNotice(bool notice)
        {
            Customer.Notice = notice;
        }

        public override void BuildPassportData(string passportData)
        {
            Customer.PassportData = passportData;
        }

        public override void BuildSurname(string surname)
        {
            Customer.Surname = surname;
        }
    }
}
