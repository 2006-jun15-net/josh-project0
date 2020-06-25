using System;
using System.Collections.Generic;

namespace Project0
{
    class StoreLocation
    {
        public string storeName { get; set; }
        private string storeAddress { get; set; }
        private Dictionary<Product, int> inventory { get; set; }//current inventory. A Set may work a little better here. 

        private List<Order> storeOrderHistory { get; set; }

        public StoreLocation(string name, string address, Dictionary<Product, int> inv)
        {
            storeName = name;
            storeAddress = address;
            inventory = inv;
            storeOrderHistory = new List<Order>();
        }

        private void addOrderToHistory(Order order)
        {
            storeOrderHistory.Add(order);
        }

        public void fulfillOrder(List<Product> cart, Order order)
        {
            try //define exception here for if someone puts too many items in their cart. If there is an error, the order should not be processed.
            {
                foreach(Product prod in cart)
                {
                    removeItemFromInventory(prod);
                }

                addOrderToHistory(order);
            }
            catch(Exception e)//define an actual exception here
            {
                Console.WriteLine("There was an error processing your order.");
                Console.Write(e);
            }
        }

        private void removeItemFromInventory(Product key)
        {
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

        }

    }
}