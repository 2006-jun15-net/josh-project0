using System;

namespace Project0.Library
{
    public class Customer : ICustomer
    {

        //Create a Customer interface, and extend two types of Customers from it, StandardCustomer and ValuedCustomer
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Customer(int _id, string _first, string _last)
        {
            CustomerId = _id;
            FirstName = _first;
            LastName = _last;
        }
        public Customer(string newCustFirstName, string newCustLastName)
        {
            CustomerId = 0;
            FirstName = newCustFirstName;
            LastName = newCustLastName;
        }

    }
}