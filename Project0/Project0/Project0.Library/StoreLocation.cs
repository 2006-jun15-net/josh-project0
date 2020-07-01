using Project0.Library;
using System;
using System.Collections.Generic;

namespace Project0.Library
{
    public class StoreLocation
    {
        /// <summary>
        /// Unique Id for the store
        /// </summary>
        public int StoreId {get; set; }
        /// <summary>
        /// Name of the store
        /// </summary>
        public string StoreName { get; set; }
        /// <summary>
        /// Address of the store
        /// </summary>
        public string StoreAddress { get; set; }
        /// <summary>
        /// Current store inventory
        /// </summary>
        public Dictionary<Product, int> Inventory { get; set; }//current inventory. A Set may work a little better here. 

        /// <summary>
        /// Constructor for a store without an inventory
        /// </summary>
        /// <param name="name"></param>
        /// <param name="address"></param>
        public StoreLocation(string name, string address)
        {
            StoreName = name;
            StoreAddress = address;
            Inventory = new Dictionary<Product, int>();
        }

        /// <summary>
        /// Constructor for a store with a pre-defined inventory
        /// </summary>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="inv"></param>
        public StoreLocation(string name, string address, Dictionary<Product, int> inv)
        {
            StoreName = name;
            StoreAddress = address;
            Inventory = inv;
        }

        /// <summary>
        /// Constructor for importing store data from the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="address"></param>
        public StoreLocation(int id, string name, string address)
        {
            StoreId = id;
            StoreName = name;
            StoreAddress = address;
            Inventory = new Dictionary<Product, int>();
        }

        /// <summary>
        /// Process the order, ensure it is valid, and the store can fulfill the requested amount of products with its current stock
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public bool FulfillOrder(Dictionary<Product, int> cart)
        {
            bool orderFulfilled = false;

            
            if(OrderValid(cart))
            {
                foreach(var prod in cart)
                {
                    RemoveItemFromInventory(prod.Key, prod.Value);
                    orderFulfilled = true;
                }
            }
            else
            {
                Console.WriteLine("Invalid order. Your order could not be processed at our store.");
                return orderFulfilled = false;
            }
        
           
            return orderFulfilled;
        }

        /// <summary>
        /// Display the items and quantities in the shop inventory
        /// </summary>
        public void DisplayInventoryCatalog()
        {
            int prodCounter = 0;
            foreach(var prod in Inventory)
            {
                //print out the description (item name) and quantity
                Console.WriteLine($"{prodCounter}|\t{prod.Key.ProductDescription}\t\t|\t{prod.Value} |\t {prod.Key.ProductPrice}");
                prodCounter++;
            }
        }
        /// <summary>
        /// Helper method to check if the order is valid and the store can fulfill the order
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        private bool OrderValid(Dictionary<Product, int> cart)
        {
            bool isValid = false;

            //check if the items in the cart are in the inventory and if there is a reasonable number of those items in the cart

            foreach(var prod in cart)
            {
                if(Inventory.ContainsKey(prod.Key) && prod.Value <= 5)// checks if the item is in the inventory, and if a reasonable amount is being ordered.
                {
                    isValid = true;
                }
                else
                {
                    return isValid = false;
                }
            }

            return isValid;
        }
        /// <summary>
        /// Remove an item from the inventory. If there are more than one of that item, decrement its quantity. If there is only one, remove it from the inventory completely.
        /// </summary>
        /// <param name="key"></param>
        private void RemoveItemFromInventory(Product key, int qty)
        {
            try
            {
                if (Inventory.TryGetValue(key, out int value))//Item has more than one in stock
                {
                    if(value > 0) 
                    {
                        //decrement
                        value -= qty;
                        Inventory[key] = value;
                    }
                    //else
                    //{
                        //remove
                    //    Inventory.Remove(key);
                    //}
                }
                else//item not in inventory
                {
                    Console.WriteLine($"Sorry, we appear to be out of stock of {key.ProductDescription}"); 
                }
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine($"Error processing request. \n{e}");
            }
        }
        // private void addItemToInventory(Product prod, int quantity)
        // {

        // }
    }
}