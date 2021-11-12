using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DItest.Models
{
    public class SaleProduct:BaseClass
    { 
        public virtual Sale Sale { get; set; }
        public int SaleId { get; set; }
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
        public int Qty { get; set; }
        public int Rate { get; set; }
        public double Amount { get; set; }

    }
}