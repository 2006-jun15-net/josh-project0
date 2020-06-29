using System;
using System.Collections.Generic;

namespace Project0
{
    class Order
    {
        //orderID
        public string OrderId { get; }
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
            bool checkoutSuccessful = false;
            //set the orderTime for when the order processes

            if (shoppingCart.Count > 0)
            {
                OrderTime = new DateTime();

                checkoutSuccessful = store.FulfillOrder(shoppingCart);


                if (checkoutSuccessful)
                {
                    //add order to history if successful

                }
            }
            else
            {
                Console.WriteLine("There are no items in your shopping cart.");
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

        /// <summary>
        /// Display all items and quantities in the order.
        /// </summary>
        internal void DisplayOrderDetails()
        {

            if (shoppingCart.Count > 0)
            {
                Console.WriteLine($"Product \t | quantity");
                foreach (var item in shoppingCart)
                {
                    Console.WriteLine($"{item.Key.ProductDescription}\t |{item.Value}");
                }
            }
            else
            {
                Console.WriteLine("You have no items in your shopping cart.");
            }
        }
        //public void RemoveFromCart(Product item, int qty){}
    }
}