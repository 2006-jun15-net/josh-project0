﻿using System;
using System.Collections.Generic;

namespace Project0
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://github.com/2006-jun15-net/trainer-code/wiki/Project-0-requirements

            Product product1 = new Product("Pencils", 0.75);
            Product product2 = new Product("Eraser", 0.50);
            Product product3 = new Product("Pencil Case", 1.50);

            Customer cust1 = new Customer("Josh", "Bertrand");

            Dictionary<Product, int> sampleProductInv = new Dictionary<Product, int>();
            sampleProductInv.Add(product1, 1);

            StoreLocation store1 = new StoreLocation("Revature", "123 Here Street", sampleProductInv);

            List<Product> orderList = new List<Product>();
            orderList.Add(product1);
            orderList.Add(product2);

            Order firstOrder = new Order(store1.storeName, cust1, orderList);

            WelcomeMessage();
        }

        public static void WelcomeMessage()
        {
            Console.WriteLine("\nWelcome to our Store!\n");
        }
    }
}