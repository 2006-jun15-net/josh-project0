using System;

namespace Project0
{
    class Customer : ICustomer
    {

        //Create a Customer interface, and extend two types of Customers from it, StandardCustomer and ValuedCustomer
        public string customerId { get;}
        public string firstName { get; set; }
        public string lastName { get; set; }

        public Customer(string newCustFirstName, string newCustLastName)
        {
            customerId = IdFactory.generateNewId();
            firstName = newCustFirstName;
            lastName = newCustLastName;
        }

    }
}