using System;
using System.Collections.Generic;

namespace Project0
{
    class Order
    {
        //orderID
        public string OrderId {get;}
        private string StoreId { get; }
        private string CustomerId { get; set; }
        private DateTime OrderTime { get; set; }

        public Dictionary<Product, int> shoppingCart;

        //ctor
        public Order()
        {
            shoppingCart = new Dictionary<Product, int>();
        }
        public Order(string store, string cust)
        {
            StoreId = store;
            CustomerId = cust;
            shoppingCart = new Dictionary<Product, int>();
        }

        /// <summary>
        /// Finish shopping and process the items in the cart. 
        /// </summary>
        /// <param name="store"></param>
        /// <param name="cust"></param>
        /// <returns></returns>
        public bool Checkout(StoreLocation store, Customer cust)
        {
            bool checkoutSuccessful;
            //set the orderTime for when the order processes
            OrderTime = new DateTime();

            checkoutSuccessful = store.FulfillOrder(shoppingCart);

                       
            if(checkoutSuccessful)
            {
                //add order to history if successful

            }

            return checkoutSuccessful;
        }

        /// <summary>
        /// Add an item by quantity to the cart. If the item is already in the cart, it should just be incremented by the quantity instead.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="qty"></param>
        public void AddToCart(Product item, int qty)
        {
            //get the ID or description of the product and the quantity desired. Add those values to to the cart 
            shoppingCart.Add(item, qty);
        }

        internal void PlaceNewOrder()
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Display all items and quantities in the order.
        /// </summary>
        internal void DisplayOrderDetails()
        {
            throw new NotImplementedException();
        }
        //public void RemoveFromCart(Product item, int qty){}
    }
}