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

        //The way that this method signature currently is suggests refactoring is needed
        public bool checkout(StoreLocation store, Customer cust, Order order)
        {

            bool orderCompleted = false;
            
            //remove items in cart from storeInventory
            store.fulfillOrder(shoppingCart, order);

            //set the orderTime for when the order processes
            orderTime = new DateTime();

            //add order to the orderHistory of the Customer and the StoreLocation
            // store.addOrderToHistory(order);
            // cust.addOrderToHistory(order);

            //return true if the order completed successfully. return false if not
            return orderCompleted;
        }

    }
}