using System;
using System.Collections.Generic;
using System.Text;

namespace Banks.BanksStuff
{
    public class CustomerDirector
    {
        public CustomerBuilder CustomerBuilder { get; set; }

        public ICustomer BuildCustomer(string name, string surname)
        {
            CustomerBuilder.BuildName(name);
            CustomerBuilder.BuildSurname(surname);
            return CustomerBuilder.GetCustomer();
        }

        public ICustomer BuildCustomer(string name, string surname, string address, string passwordData)
        {
            CustomerBuilder.BuildName(name);
            CustomerBuilder.BuildSurname(surname);
            CustomerBuilder.BuildAddress(address);
            CustomerBuilder.BuildPassportData(passwordData);
            return CustomerBuilder.GetCustomer();
        }
    }
}
