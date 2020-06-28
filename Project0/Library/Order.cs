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
        private Dictionary<Product, int> shoppingCart;// Change to Dictionary<string, int> too

        //ctor
        public Order(string store, string cust)
        {
            storeId = store;
            customerId = cust;
            shoppingCart = new Dictionary<Product, int>();//Change the List to take a dictionary of <string, int> instead.
        }

        //The way that this method signature currently is suggests refactoring is needed
        public bool checkout(StoreLocation store, Customer cust, Order order)
        {
            bool checkoutSuccessful = false;
            //set the orderTime for when the order processes
            orderTime = new DateTime();

            checkoutSuccessful = store.fulfillOrder(shoppingCart);

                       
            if(checkoutSuccessful)
            {
                //add order to history if successful
            }

            return checkoutSuccessful;
        }

        public void addToCart(Product item, int qty)
        {
            //get the ID or description of the product and the quantity desired. Add those values to to the cart 
            shoppingCart.Add(item, qty);
        }
        public void removeFromCart(Product item, int qty)
        {
            
        }

    }
}