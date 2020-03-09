using BhavisProducts.Data_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BhavisProducts
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
