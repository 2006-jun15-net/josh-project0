using Project0.Library;
using System;
using System.Collections.Generic;

namespace Project0.Library
{
    public class StoreLocation
    {

        public string StoreId {get; set; }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }
        private Dictionary<Product, int> Inventory { get; set; }//current inventory. A Set may work a little better here. 

        /// <summary>
        /// Constructor for a store without an inventory
        /// </summary>
        /// <param name="name"></param>
        /// <param name="address"></param>
        public StoreLocation(string name, string address)
        {
            StoreId = IdFactory.generateNewId();
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
            StoreId = IdFactory.generateNewId();
            StoreName = name;
            StoreAddress = address;
            Inventory = inv;
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
                    RemoveItemFromInventory(prod.Key);
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
            foreach(var prod in Inventory)
            {
                //print out the description (item name) and quantity
                Console.WriteLine($"{prod.Key}\t|\t{prod.Value}");
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
                if(Inventory.ContainsKey(prod.Key) && prod.Value <= 10)// checks if the item is in the inventory, and if a reasonable amount is being ordered.
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
        private void RemoveItemFromInventory(Product key)
        {
            try
            {
                if (Inventory.TryGetValue(key, out int value))//Item has more than one in stock
                {
                    if(value > 1) 
                    { 
                        //decrement
                    }
                    else
                    {
                        //remove
                    }
                }
                else//item not in inventory
                {
                    
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