using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ef
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }

        public ICollection<CustomerProduct> CustomerProducts { get; set; }
    }
}
