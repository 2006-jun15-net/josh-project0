using System;
using System.Collections.Generic;

namespace Project0
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://github.com/2006-jun15-net/trainer-code/wiki/Project-0-requirements

            WelcomeMessage();

            List<Product> products = new List<Product>();
            List<Customer> customers = new List<Customer>();

            Product product1 = new Product("Pencils", 0.75);
            Product product2 = new Product("Eraser", 0.50);
            Product product3 = new Product("Pencil Case", 1.50);

            products.Add(product1);
            products.Add(product2);
            products.Add(product3);

            Customer cust1 = new Customer("Josh", "Bertrand");

            customers.Add(cust1);

            Dictionary<Product, int> sampleProductInv = new Dictionary<Product, int>();
            sampleProductInv.Add(product1, 2);
            sampleProductInv.Add(product2, 1);

            StoreLocation store1 = new StoreLocation("Bookstore", "123 Here Street", sampleProductInv);

            Order newOrder = new Order(store1.StoreId, cust1.customerId);

            Order firstOrder = new Order(store1.StoreId, cust1.customerId);

            bool isSuccessful;
            isSuccessful = firstOrder.Checkout(store1, cust1);

            //place order
            //add customer
            //search customers
            //display order details
            //display order history of store
            //display order history of customer
            
        }

        public static void WelcomeMessage()
        {
            Console.WriteLine("\nWelcome to our Store!\n");
        }

        //add new customer

        //
        

    }
}
