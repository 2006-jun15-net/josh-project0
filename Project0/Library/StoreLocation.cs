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

        public void fulfillOrder(Dictionary<string, int> cart)
        {
            try //define exception here for if someone puts too many items in their cart. If there is an error, the order should not be processed.
            {
                foreach(var prod in cart)
                {
                    removeItemFromInventory(prod.Key);
                }
            }
            catch(Exception e)//define an actual exception here
            {
                Console.WriteLine("There was an error processing your order.");
                Console.Write(e);
            }
            finally
            {
                //put file/object closing code here
            }
        }

        public void displayInventoryCatalog()
        {
            
        }

        private void addOrderToHistory(Order order)
        {
            
        }

        private void removeItemFromInventory(string key)
        {
            //search through the Dictionary of products in the catelog



            /*
            int currentValue;
            if(inventory.GetValueOrDefault(key) > 1)
            {
                inventory.TryGetValue(key, out currentValue);
                //decrement the value of the given key
                inventory[key] = currentValue - 1;
                Console.WriteLine($"Removed one {key.productDescription} from the inventory. {inventory[key]} remains in stock.");
            }
            else if(inventory.GetValueOrDefault(key)==1)
            {
                inventory.Remove(key);
                Console.WriteLine($"{key.productDescription} is now out of stock");
            }
            else
            {
                Console.WriteLine($"{key.productDescription} could not be found in the stockroom.");
            }
            */
            
        }

    }
}