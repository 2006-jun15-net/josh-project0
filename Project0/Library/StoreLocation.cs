using System.Collections.Generic;

namespace Project0
{
    class StoreLocation
    {
        public string storeName { get; set; }
        private string storeAddress { get; set; }
        private Dictionary<Product, int> inventory { get; set; }//current inventory. A Set may work a little better here. 

        private List<Order> storeOrderHistory {get; set;}

        public StoreLocation(string name, string address, Dictionary<Product, int> inv)
        {
            storeName = name;
            storeAddress = address;
            inventory = inv;
        }

        public bool addOrderToHistory(Order order)
        {

            storeOrderHistory.Add(order);
            return true;
        }

        public void fulfillOrder(List<Product> cart)
        {

            foreach(Product prod in cart)
            {
                removeItemFromInventory(prod);
            }

        }
        
        private void removeItemFromInventory(Product key)
        {
            int currentValue;
            if(inventory.TryGetValue(key, out currentValue))
            {
                //decrement the value of the given key
                inventory[key] = currentValue - 1;
            }
            else if(inventory.GetValueOrDefault(key)==1)
            {
                inventory.Remove(key);
            }

        }

    }
}