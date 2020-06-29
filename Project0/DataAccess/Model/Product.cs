using System;
using System.Collections.Generic;

namespace Project0.DataAccess.Model
{
    public partial class Product
    {
        public string ProductId { get; set; }
        public string ProductDescription { get; set; }
        public decimal? ProductPrice { get; set; }
    }
}
