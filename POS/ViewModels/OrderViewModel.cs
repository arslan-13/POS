using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.ViewModels
{
    public class OrderViewModel
    {

        public OrderViewModel()
        {

        }
        public List<PurchasedOrderViewModel> purchasedorderViewModel { get; set; }

        public IEnumerable<Vendor> vendor { get; set; }
    }
}
