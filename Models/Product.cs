using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public int VendorID { get; set; }
        public virtual Vendor Vendor { get; set; }

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
