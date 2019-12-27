using Data.Interface;
using Microsoft.AspNetCore.Mvc;
using Models;
using POS.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace POS.Controllers
{
    public class PurchasedController : Controller
    {

        #region Private variable & Constructor
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
                    categories=await cateRepo.GetAllCategory()
                }
            };

            return View(PO);
        }
        public async Task<JsonResult> getvondrer()
        {
            IEnumerable<Vendor> vendor = await venRepo.GetAllVendors();
            //List<Vendor> vendors = new List<Vendor>
            //{
            //    new Vendor
            //    {
            //        categories=await cateRepo.GetAllCategory()
            //    }
            //};
            return Json(vendor);
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