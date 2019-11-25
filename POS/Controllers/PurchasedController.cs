using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Interface;
using Microsoft.AspNetCore.Mvc;
using POS.ViewModels;

namespace POS.Controllers
{
    public class PurchasedController : Controller
    {

        #region Private variable & Contruction
        private readonly IProductRepository proRepo;
        private readonly ICategoryRepository cateRepo;
        private readonly IVendorRepository venRepo;

        public PurchasedController(IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            IVendorRepository vendorRepository)
        {
            proRepo = productRepository;
            cateRepo = categoryRepository;
            venRepo = vendorRepository;
        }
        #endregion

        #region List
        public IActionResult Index()
        {
            return View();
        }
        #endregion

        #region Purchased Order
        public async Task<IActionResult> PurchasedOrder()
        {
            List<PurchasedOrderViewModel> PO = new List<PurchasedOrderViewModel>
            {
                new PurchasedOrderViewModel
                {
                    categories=await cateRepo.GetAllCategory(),
                    vendor=await venRepo.GetAllVendors()
                }
            };
            return View(PO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PurchasedOrder(int ID)
        {
            return View();
        }

        #endregion
    }
}