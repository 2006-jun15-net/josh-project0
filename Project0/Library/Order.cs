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
        private List<Product> shoppingCart;

        //ctor
        public Order(string store, Customer cust)
        {
            storeLocation = store;
            customer = cust;
            shoppingCart = new List<Product>();
        }

        //The way that this method signature currently is suggests refactoring is needed
        public bool checkout(StoreLocation store, Customer cust, Order order)
        {

            bool orderCompleted = false;
            
            //set the orderTime for when the order processes
            orderTime = new DateTime();

            //remove items in cart from storeInventory
            //add order to the orderHistory of the Customer and the StoreLocation
            store.fulfillOrder(shoppingCart, order);
            cust.addOrderToHistory(order);

            // if there are no errors, set orderCompleted to true
            
            //return true if the order completed successfully. return false if not
            return orderCompleted;
        }

        public void addToCart(Product item)
        {
            shoppingCart.Add(item);
        }

    }
}