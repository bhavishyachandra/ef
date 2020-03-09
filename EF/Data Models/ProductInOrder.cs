using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BhavisProducts.Data_Models
{
    public class ProductInOrder
    {
        public int ProductInOrderId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public int AdjustedPrice { get; set; }
    }
}
