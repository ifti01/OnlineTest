using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DItest.Models
{
    public class Product:BaseClass
    {
        public string ProductName { get; set; }
        public int Rate { get; set; }
        public string Unit { get; set; }
    }
}