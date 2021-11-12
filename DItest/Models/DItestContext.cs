using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DItest.Models
{
    public class DItestContext:DbContext
    { 
        public DbSet <Customer> Customers { get; set; } 
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleProduct> SaleProducts { get; set; }

    }
}