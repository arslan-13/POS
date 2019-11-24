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
        [Required]
        public string CompanyName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }

        public ICollection<Product> products { get; set; }
    }
}
