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
        private List<Product> shoppingCart = new List<Product>();

        //ctor
        public Order(string store, Customer cust, List<Product> cart)
        {
            storeLocation = store;
            customer = cust;
            shoppingCart = cart;
        }

        private bool checkout(List<Product> shoppingCart, StoreLocation store, Customer cust)
        {

            bool orderCompleted = false;
            
            //remove items in cart from storeInventory
            foreach(Product p in shoppingCart)
            {
                
            }

            //set the orderTime for when the order processes
            orderTime = new DateTime();

            //add order to the orderHistory of the Customer and the StoreLocation

            //return true if the order completed successfully. return false if not
            return orderCompleted;
        }

    }
}