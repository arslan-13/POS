using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public virtual Vendor Vendor { get; set; }

        public virtual Category Category { get; set; }
    }
}
