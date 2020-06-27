using System;
using System.Collections.Generic;

namespace Project0
{
    class Order
    {
        //orderID
        private string orderId {get;}
        private string storeId { get; }
        private string customerId { get; set; }
        private DateTime orderTime { get; set; }
        private Dictionary<string, int> shoppingCart;// Change to Dictionary<string, int> too

        //ctor
        public Order(string store, string cust)
        {
            storeId = store;
            customerId = cust;
            shoppingCart = new Dictionary<string, int>();//Change the List to take a dictionary of <string, int> instead.
        }

        //The way that this method signature currently is suggests refactoring is needed
        public bool checkout(StoreLocation store, Customer cust, Order order)
        {
            bool checkoutSuccessful = false;
            //set the orderTime for when the order processes
            orderTime = new DateTime();

            //remove items in cart from storeInventory
            //add order details to the orderHistory             
            return checkoutSuccessful;
            /*
            store.fulfillOrder(shoppingCart, order);
            */
        }

        public void addToCart(Product item, int qty)
        {
            //get the ID or description of the product and the quantity desired. Add those values to to the cart 
            shoppingCart.Add(item.productDescription, qty);
        }

    }
}