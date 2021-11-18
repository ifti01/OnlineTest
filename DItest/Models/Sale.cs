using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace DItest.Models
{
    public class Sale:BaseClass
    { 
        public virtual Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public string DeliveryAddress { get; set; }
        public DateTime SaleDateTime { get; set; }
        public decimal TotalAmount { get; set; }
    }
}