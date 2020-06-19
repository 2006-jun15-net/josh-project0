using System.Collections.Generic;

namespace Project0
{
    class StoreLocation
    {
        private string storeName { get; set; }
        private string storeAddress { get; set; }
        private Dictionary<Product, int> inventory { get; set; }

        //storeOrderHistory

        public StoreLocation(string name, string address, Dictionary<Product, int> inv)
        {

        }
    }
}