using Project0.Library;
using System.Collections.Generic;

namespace Project0.Library
{
    public class OrderHistory
    {
        public string CustomerId { get; set; }
        public string StoreId { get; set; }
        public Dictionary<Product, int> Order { get; set; }
        public OrderHistory(string _customerId, string _storeId, Dictionary<Product, int> _order)
        {
            CustomerId = _customerId;
            StoreId = _storeId;

            Order = new Dictionary<Product, int>();
            Order = _order;
        }
    }
}