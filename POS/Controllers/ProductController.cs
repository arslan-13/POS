using Data.Interface;
using Microsoft.AspNetCore.Mvc;
using POS.ViewModels;
using Rotativa.AspNetCore;
using System.Threading.Tasks;

namespace POS.Controllers
{
    public class ProductController : Controller
    {
        #region Private Variable and Constructor

        private readonly IProductRepository ProdRepo;
        private readonly ICategoryRepository cateRepo;
        private readonly IVendorRepository venRepo;

        public ProductController(IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            IVendorRepository vendorRepository)
        {
            ProdRepo = productRepository;
            cateRepo = categoryRepository;
            venRepo = vendorRepository;
        }

        #endregion Private Variable and Constructor

        #region Index

        public async Task<IActionResult> Index()
        {
            var AP = await ProdRepo.GetProductWithCategory();
            return View(AP);
        }

        #endregion Index

        #region Add

        public async Task<IActionResult> Add()
        {
            var AP = new AddProductViewModel();
            AP.categories = await cateRepo.GetAllCategory();
            AP.vendors = await venRepo.GetAllVendors();
            return View(AP);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddProductViewModel addProductVM)
        {
            if (ModelState.IsValid)
            {
                ProdRepo.Add(addProductVM.product);
                await ProdRepo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        #endregion Add

        #region Edit

        public async Task<IActionResult> Edit(int ID)
        {
            var AP = new AddProductViewModel();
            AP.categories = await cateRepo.GetAllCategory();
            AP.vendors = await venRepo.GetAllVendors();
            AP.product = await ProdRepo.GetProductByID(ID);
            return View(AP);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AddProductViewModel addProductVM)
        {
            if (ModelState.IsValid)
            {
                ProdRepo.Edit(addProductVM.product);
                await ProdRepo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        #endregion Edit

        #region Report

        public async Task<IActionResult> Report()
        {
            var pro = await ProdRepo.GetProductWithCategoryAndVendor();
            return new ViewAsPdf("Report", pro)
            {
                PageSize = Rotativa.AspNetCore.Options.Size.A4,
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                CustomSwitches = "--page-offset 0 --footer-center [page] --footer-font-size 12",
                PageMargins = { Left = 5, Bottom = 5, Right = 5, Top = 5 }
                //Model = pro
            };

            //return report;
        }

        //public ActionResult Export()
        //{
        //    Response.AddHeader("Content-Type", "application/vnd.ms-excel");
        //    return View();
        //}

        #endregion Report
    }
}