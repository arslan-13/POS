using Data.Interface;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.ViewModels
{
    public class PurchasedOrderViewModel
    {
        //private readonly ICategoryRepository cateRepo;
        //public PurchasedOrderViewModel(ICategoryRepository categoryRepository)
        //{
        //    cateRepo = categoryRepository;
        //}

        //public IEnumerable<Vendor> vendor { get; set; }
        public IEnumerable<Category> categories { get; set; }

        public Product product { get; set; }
    }
}
