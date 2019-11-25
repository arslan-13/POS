using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class PurchasedOrder
    {
        [Key]
        public int POID { get; set; }
        [Required]
        public DateTime OrderTime { get; set; }

        //public int ProductID { get; set; }
        public ICollection<Product> Product { get; set; }
    }
}
