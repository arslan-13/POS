using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.ViewModels
{
    public class PurchasedOrderViewModel
    {
        public IEnumerable<Vendor> vendor { get; set; }
        public int VendorFK { get; set; }

        public IEnumerable<Category> categories { get; set; }

        public Product product { get; set; }
    }
}
