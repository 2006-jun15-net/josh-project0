using System;
using System.Collections.Generic;

namespace Project0
{
    class Order
    {
        //orderID
        private string storeLocation { get; }
        private Customer customer { get; set; }
        private DateTime orderTime { get; set; }
        private List<Product> shoppingCart { get; set; }

        //ctor
        public Order()
        {
            
        }

        private bool checkout()
        {
            return false;
        }

    }
}