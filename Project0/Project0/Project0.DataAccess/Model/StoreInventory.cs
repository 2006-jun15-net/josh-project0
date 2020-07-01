using System;
using System.Collections.Generic;

namespace Project0.DataAccess.Model
{
    public partial class StoreInventory
    {
        public int StoreInvId { get; set; }
        public int? StoreId { get; set; }
        public int? ProductId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Store Store { get; set; }
    }
}
