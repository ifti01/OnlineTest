using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DItest.Models;

namespace DItest.ViewModel
{
    public class SaleCreateViewModel
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public List<Customer> customers { get; set; }

        public string DeliveryAddress { get; set; }
        public DateTime SaleDateTime { get; set; }
        public double TotalAmount { get; set; }
    }

    public class SaleInfoViewModel
    {
        public Sale customerin { get; set; }
        public List<SaleProduct> productin { get; set; }
    }

    public class SaleListViewModel
    {
        public List<Product> Products { get; set; }
        public List<Customer> Customers { get; set; }
    }
}