using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Vendor
    {
        [Key]
        public int ID { get; set; }
        public string CompanyName { get; set; }

        public ICollection<Product> products { get; set; }
    }
}
