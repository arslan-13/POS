using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.ViewModels
{
    public class VendorDropdown
    {
        public IEnumerable<Vendor> vendor { get; set; }
        public int VendorFK { get; set; }
    }
}
