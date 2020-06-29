using System;
using System.Collections.Generic;

namespace Project0
{
    class StoreLocation
    {

        public string StoreId {get; set; }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }
        private Dictionary<Product, int> Inventory { get; set; }//current inventory. A Set may work a little better here. 

        public StoreLocation(string name, string address)
        {
            StoreId = IdFactory.generateNewId();
            StoreName = name;
            StoreAddress = address;
            Inventory = new Dictionary<Product, int>();
        }

        public StoreLocation(string name, string address, Dictionary<Product, int> inv)
        {
            StoreId = IdFactory.generateNewId();
            StoreName = name;
            StoreAddress = address;
            Inventory = inv;
        }

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
        public void DisplayInventoryCatalog()
        {
            foreach(var prod in Inventory)
            {
                //print out the description (item name) and quantity
                Console.WriteLine($"{prod.Key}\t|\t{prod.Value}");
            }
        }
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
        private void RemoveItemFromInventory(Product key)
        {
            if(Inventory.GetValueOrDefault(key) > 1)//Item has more than one in stock
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