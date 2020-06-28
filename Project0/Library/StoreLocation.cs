using System;
using System.Collections.Generic;

namespace Project0
{
    class StoreLocation
    {

        private string storeId {get; set; }
        private string storeName { get; set; }
        private string storeAddress { get; set; }
        private Dictionary<Product, int> inventory { get; set; }//current inventory. A Set may work a little better here. 

        public StoreLocation(string name, string address, Dictionary<Product, int> inv)
        {
            storeId = IdFactory.generateNewId();
            storeName = name;
            storeAddress = address;
            inventory = new Dictionary<Product, int>();
        }

        public bool fulfillOrder(Dictionary<Product, int> cart)
        {
            bool orderFulfilled = false;

            try 
            {
                if(orderValid(cart))
                {
                    foreach(var prod in cart)
                    {
                        removeItemFromInventory(prod.Key);
                        orderFulfilled = true;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid order");
                    return orderFulfilled = false;
                }
            }
            catch(Exception e)//define an actual exception here
            {
                Console.WriteLine("There was an error processing your order.");
                Console.Write(e);
            }
            return orderFulfilled;
        }
        public void displayInventoryCatalog()
        {
            foreach(var prod in inventory)
            {
                //print out the description (item name) and quantity
                Console.WriteLine($"{prod.Key}\t|\t{prod.Value}");
            }
        }
        private bool orderValid(Dictionary<Product, int> cart)
        {
            bool isValid = false;

            //check if the items in the cart are in the inventory and if there is a reasonable number of those items in the cart

            foreach(var prod in cart)
            {
                if(inventory.ContainsKey(prod.Key) && prod.Value <= 10)// checks if the item is in the inventory, and if a reasonable amount is being ordered.
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
        private void removeItemFromInventory(Product key)
        {
            if(inventory.GetValueOrDefault(key) > 1)//Item has more than one in stock
            {
            //Remove quantity from inventory
            }
            else//Item has only one in stock
            {
            //Remove from inventory
            }
        }
        // private void addItemToInventory(Product prod, int quantity)
        // {

        // }
    }
}