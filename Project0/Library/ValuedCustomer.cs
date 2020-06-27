namespace Project0
{
    class ValuedCustomer : ICustomer
    {

        //Create a Customer interface, and extend two types of Customers from it, StandardCustomer and ValuedCustomer
        public string customerId { get;}
        public string firstName { get; set; }
        public string lastName { get; set; }
        // public int defaultStore { get; set; }
        public int valuedCustomerDiscount { get; set; }//percentage discount

        public ValuedCustomer(string newCustFirstName, string newCustLastName)
        {
            customerId = IdFactory.generateNewId();
            firstName = newCustFirstName;
            lastName = newCustLastName;
            valuedCustomerDiscount = 10;
        }

    }
}