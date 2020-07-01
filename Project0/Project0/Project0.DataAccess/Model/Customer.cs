using System;
using System.Collections.Generic;

namespace Project0.DataAccess.Model
{
    public partial class Customer
    {
        public Customer()
        {
            OrderHistory = new HashSet<OrderHistory>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<OrderHistory> OrderHistory { get; set; }
    }
}
