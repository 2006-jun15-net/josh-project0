using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Project0.DataAccess;
using Project0.DataAccess.Model;
using Project0.Library;

namespace Project0.ConsoleApp
{
    class Program
    {

        public static readonly DbContextOptions<project0Context> options = new DbContextOptionsBuilder<project0Context>()
                .UseSqlServer(SecretConfiguration.ConnectionString)
                .Options;


        static void Main(string[] args)
        {
            //https://github.com/2006-jun15-net/trainer-code/wiki/Project-0-requirements

            WelcomeMessage();

            List<Library.Product> products = new List<Library.Product>();
            List<Library.Customer> customers = new List<Library.Customer>();
            List<Order> orders = new List<Order>();
            List<StoreLocation> stores = new List<StoreLocation>();

            using var context = new project0Context(options);
            var custs = context.Customer.ToList();
            var prods = context.Product.ToList();
            var stor = context.Store.ToList();

            foreach(var entry in custs)
            {
                customers.Add(Mapper.MapDbEntryToCustomer(entry));
            }
            foreach(var entry in prods)
            {
                products.Add(Mapper.MapDbEntrytoProduct(entry));
            }
            foreach(var entry in stor)
            {
                stores.Add(Mapper.MapDbEntryToStoreLocation(entry));
            }
            foreach(var store in stores)
            {
                foreach (var prod in products)
                {
                    store.Inventory.Add(prod, 5);
                }
            }    


            Order currentOrder = new Order();
            Library.Customer currentCustomer = null ;
            StoreLocation currentStore = null;

            bool runProgram = true;

            while (runProgram)
            {
                DisplayMenu();
                Console.Write("What would you like to do today? ");
                var userInput = Console.ReadLine().ToLower();

                if (ValidateMenuSelectionInput(userInput))
                {
                    switch (userInput)
                    {
                        case "a":
                            Console.Write("You have chosen to Add a new customer");
                            customers.Add(AddCustomer());
                            break;
                        case "c":
                            Console.WriteLine("You have chosen to checkout");
                            currentOrder.Checkout(currentStore, currentCustomer);
                            break;
                        case "cc":
                            Console.WriteLine("Please choose the customer placing the order");
                            currentCustomer = ChooseCustomer(customers);
                            Console.WriteLine("Please choose the store you will place the order from");
                            currentStore = ChooseStoreLocation(stores);
                            break;
                        case "d":
                            Console.Write("You have chosen to display order details");
                            currentOrder.DisplayOrderDetails();
                            break;
                        case "p":
                            try
                            {
                                Console.Write("You have chosen to place a new order");
                                PlaceOrder(currentCustomer, currentStore, currentOrder, products);
                            }
                            catch (NullReferenceException)
                            {
                                Console.WriteLine("You must first choose a customer and store");
                            }
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
            //search customers
            //display order details
            //display order history of store
            //display order history of customer

        }

        private static void PlaceOrder(Library.Customer cust, StoreLocation store, Order order, List<Library.Product> products)
        {
            int prodChoice, qtyChoice = -1;
            try
            {
                Console.WriteLine($"{store.StoreName} has in stock: \n");
                store.DisplayInventoryCatalog();

                //ask if they would like to purchase an item
                Console.WriteLine("Please select an item to purchase");
                prodChoice = int.Parse(Console.ReadLine());
                Console.WriteLine("Please enter a quantity you would like purchase");
                qtyChoice = int.Parse(Console.ReadLine());

                order.AddToCart(products[prodChoice], qtyChoice);
            }
            catch (FormatException)
            {
                Console.WriteLine("You have selected an invalid option. Please allow an associate to assist you with your transaction.");
            }
        }

        private static void GoodbyeMessage()
        {
            Console.WriteLine("\nThank you for visting our store. Please come again!");
        }

        private static void SearchForCustomer()
        {
            throw new NotImplementedException();
        }

        private static Library.Customer AddCustomer()
        {
            //get first and last name
            using var context = new project0Context(options);
            var custRepo = new CustomerRepository(context);


            Console.Write("\nPlease enter the given name of the new customer: ");
            string firstName = Console.ReadLine();
            Console.Write("\nPlease enter the surname of the new customer: ");
            string lastName = Console.ReadLine();

            Project0.Library.Customer newCustomer = new Project0.Library.Customer(firstName, lastName);

            try
            {
                custRepo.Insert(newCustomer);
                Console.Write("New customer successfully added.");
                Console.WriteLine($"We welcome you as a valued customer {newCustomer.FirstName} {newCustomer.LastName}");
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine(e);

                Console.WriteLine("There was an error processing your request.");
            }

            return newCustomer;
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("\n\nOperations available are: ");
            Console.WriteLine("----------------------------");
            Console.Write("a  | Add a new customer\n");
            Console.Write("c  | Checkout\n");
            Console.Write("cc | Select customer and store\n");
            Console.Write("d  | Display order details\n");
            Console.Write("p  | Place a new order\n");
            Console.Write("s  | Search for a customer\n");
            Console.Write("x  | Exit the program\n");
        }

        private static void WelcomeMessage()
        {
            Console.WriteLine("\nWelcome to our Store!\n");
        }
        private static bool ValidateMenuSelectionInput(string input)
        {
            bool isValid;

            switch (input)
            {
                case "a":
                    isValid = true;
                    break;
                case "cc":
                    isValid = true;
                    break;
                case "c":
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
        private static StoreLocation ChooseStoreLocation(List<StoreLocation> stores)
        {
            StoreLocation storeChoice = null;
            int userInput = -1;
            //display available stores
            bool validStore = false;
            List<int> storeIds = new List<int>();

            if (stores.Count > 0)
            {
                do
                {
                    foreach (var store in stores)
                    {
                        Console.WriteLine($"{store.StoreId} | {store.StoreName}");
                        storeIds.Add(store.StoreId);
                    }

                    Console.Write("Which store would you like to place your order from? ");
                    try
                    {
                        userInput = int.Parse(Console.ReadLine());
                    

                        if (storeIds.Contains(userInput))
                        {
                            validStore = true;
                            storeChoice = stores[userInput - 1];
                        }
                        else
                        {
                            Console.WriteLine("Invalid store selected.");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("You have entered an invalid store ID.");
                        continue;
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("Invalid customer");
                    }

                } while (!validStore);
            }
            else
            {
                Console.WriteLine("There are no stores to order from");
            }
            return storeChoice;
        }
        private static Library.Customer ChooseCustomer(List<Library.Customer> customers)
        {
            Library.Customer customerChoice = null;
            bool validCustomer = false;
            int userInput = -1;
            List<int> customerIds = new List<int>();

            foreach(var cust in customers)
            {
                Console.WriteLine($"\n{cust.CustomerId} | {cust.FirstName} {cust.LastName}");
                customerIds.Add(cust.CustomerId);
            }

            do
            {
                Console.WriteLine("Please select a valid customer ID");
                try
                {
                    userInput = int.Parse(Console.ReadLine());
               

                    if (customerIds.Contains(userInput))
                    {
                        validCustomer = true;
                        customerChoice = customers[userInput - 1];
                    }
                    else
                    {
                        Console.WriteLine("Invalid customer selection");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid entry");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Invalid customer");
                }

            } while (!validCustomer);

            return customerChoice;
        }
    }
}
