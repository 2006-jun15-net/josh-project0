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

        public bool removeItemFromInventory(Product key)
        {
            bool isSuccessful = false;
            
            if(inventory.GetValueOrDefault(key)>1)
            {
                //decrement the value of the given key
                isSuccessful = true;
            }
            else if(inventory.GetValueOrDefault(key)==1)
            {
                inventory.Remove(key);
                isSuccessful = true;
            }
            
            return isSuccessful;
        }

    }
}