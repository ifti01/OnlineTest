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
        public string ProductId { get; set; }
        public decimal Qty { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }

    }
}