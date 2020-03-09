using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BhavisProducts
{
    public class CustomerProduct
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Paid { get; set; }
    }
}
