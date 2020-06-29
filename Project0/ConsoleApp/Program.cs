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

            //Sample data
            List<Product> products = new List<Product>();
            List<Customer> customers = new List<Customer>();
            List<Order> orders = new List<Order>();
            List<StoreLocation> stores = new List<StoreLocation>();

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
            stores.Add(store1);

            Order order = new Order();
            // bool isSuccessful;
            // isSuccessful = firstOrder.Checkout(store1, cust1);

            bool runProgram = true;

            while(runProgram)
            {
                DisplayMenu();
                Console.Write("What would you like to do today? ");
                var userInput = Console.ReadLine().ToLower();

                if(ValidateMenuSelectionInput(userInput))
                {
                    switch(userInput)
                    {
                        case "a":
                            Console.Write("You have chosen to Add a new customer");
                            AddCustomer();
                            break;
                        case "d":
                            Console.Write("You have chosen to display order details");
                            order.DisplayOrderDetails();
                            break;
                        case "p":
                            Console.Write("You have chosen to place a new order");
                            //order.Checkout();
                            break;
                        case "s":
                            Console.Write("You have chosen to search for a customer");
                            SearchForCustomer();
                            break;
                        case "x":
                            Console.Write("You have chosen to Exit the program");
                            runProgram = false;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nSorry, that is not a valid input. Please enter a valid option.");
                }
            }

            GoodbyeMessage();

            //place order
            //add customer
            //search customers
            //display order details
            //display order history of store
            //display order history of customer
            
        }

        private static void GoodbyeMessage()
        {
            Console.WriteLine("\nThank you for visting our store. Please come again!");
        }

        private static void SearchForCustomer()
        {
            throw new NotImplementedException();
        }

        private static void AddCustomer()
        {
            throw new NotImplementedException();
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("\n\nOperations available are: ");
            Console.WriteLine("-------------------------");
            Console.Write("a | Add a new customer\n");
            Console.Write("d | Display order details\n");
            Console.Write("p | Place a new order\n");
            Console.Write("s | Search for a customer\n");
            Console.Write("x | Exit the program\n");
        }

        private static void WelcomeMessage()
        {
            Console.WriteLine("\nWelcome to our Store!\n");
        }
        private static bool ValidateMenuSelectionInput(string input)
        {
            bool isValid;

            switch(input)
            {
                case "a":
                    isValid = true;
                    break;
                case "d": 
                    isValid = true;
                    break;
                case "p":
                    isValid = true;
                    break;
                case "s":
                    isValid = true;
                    break;
                case "x":
                    isValid = true;
                    break;
                default:
                    isValid = false;
                    break;
            }

            return isValid;
        }
        private static int ChooseStoreLocation(List<StoreLocation> stores)
        {
            string storeChoice;
            //display available stores
            Console.Write("Which store would you like to place your order from? ");
            storeChoice = Console.ReadLine();

            foreach(var store in stores)
            {

            }

            return 0;
        }

    }
}
