using System.Collections.Generic;

namespace Project0
{
    class OrderHistory
    {
        public string customerId { get; set; }
        public string storeId { get; set; }
        public Dictionary<Product, int> order { get; set; }
        public OrderHistory(string _customerId, string _storeId, Dictionary<Product, int> _order)
        {
            customerId = _customerId;
            storeId = _storeId;

            order = new Dictionary<Product, int>();
            order = _order;
        }
    }
}