using System;
using System.Collections.Generic;

namespace Project0.Library
{
    public class Order
    {
        //orderID
        public int OrderId { get; set; }
        private int StoreId { get; set; }
        private int CustomerId { get; set; }
        //private DateTime OrderTime { get; set; }

        public Dictionary<Product, int> shoppingCart;

        //ctor
        public Order()
        {
            shoppingCart = new Dictionary<Product, int>();
        }
        public Order(int store, int cust)
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
            double totalCost = 0;
            bool checkoutSuccessful = false;
            //set the orderTime for when the order processes

            if (shoppingCart.Count > 0)
            {
                //OrderTime = new DateTime();

                foreach(var item in shoppingCart)
                {
                    totalCost += item.Key.ProductPrice;
                }

                checkoutSuccessful = store.FulfillOrder(shoppingCart);


                if (checkoutSuccessful)
                {
                    //create the order through the repo
                    //add order to history if successful
                    Console.WriteLine("Checkout successful");
                    Console.Write($"Your total cost today is: {totalCost}");
                    shoppingCart.Clear();
                }
                else
                {
                    shoppingCart.Clear();
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
            Console.WriteLine($"{item.ProductDescription} added to cart");
        }

        /// <summary>
        /// Display all items and quantities in the order.
        /// </summary>
        public void DisplayOrderDetails()
        {

            if (shoppingCart.Count > 0)
            {
                Console.WriteLine($"\nItems in your shopping cart:\nProduct \t | quantity");
                foreach (var item in shoppingCart)
                {
                    Console.WriteLine($"{item.Key.ProductDescription}\t |{item.Value}");
                }
            }
            else
            {
                Console.WriteLine("\nYou have no items in your shopping cart.");
            }
        }
    }
}