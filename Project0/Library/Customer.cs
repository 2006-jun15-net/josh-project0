using System.Collections.Generic;

namespace Project0
{
    class Customer 
    {

        private string firstName { get; }
        private string lastName { get; }
        private bool valuedCustomer { get; set; }
        // public int defaultStore { get; set; }

        public List<Order> orderHistory 
        { 
            get{return orderHistory;} 
            set
            {
                {
                    orderHistory = new List<Order>();
                } 
            }
        }

        public Customer(string newCustFirstName, string newCustLastName)
        {
            firstName = newCustFirstName;
            lastName = newCustLastName;
            valuedCustomer = false;
        }

        //Add the 
        public bool addOrderToHistory(Order order)
        {

            orderHistory.Add(order);
            return true;
        }

    }
}