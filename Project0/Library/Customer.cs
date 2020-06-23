using System.Collections.Generic;

namespace Project0
{
    class Customer 
    {

        //Create a Customer interface, and extend two types of Customers from it, StandardCustomer and ValuedCustomer

        private string firstName { get; }
        private string lastName { get; }
        // public int defaultStore { get; set; }

        public List<Order> orderHistory 
        { 
            get{return orderHistory;} 
            set
            {
                {
                    
                } 
            }
        }

        public Customer(string newCustFirstName, string newCustLastName)
        {
            firstName = newCustFirstName;
            lastName = newCustLastName;
            orderHistory = new List<Order>();
        }

        //Add the 
        public bool addOrderToHistory(Order order)
        {

            orderHistory.Add(order);
            return true;
        }

    }
}