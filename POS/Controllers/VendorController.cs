using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Interface;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace POS.Controllers
{
    public class VendorController : Controller
    {
        #region Private Variable and constructor

        private readonly IVendorRepository vendorRepo;

        public VendorController(IVendorRepository vendorRepository)
        {
            vendorRepo = vendorRepository;
        }
        #endregion

        #region Index
        public async Task<IActionResult> Index()
        {
            var vendor = await vendorRepo.GetAllVendors();
            return View(vendor);
        }
        #endregion

        #region Add
        public IActionResult Add()
        {
            return View();
        }

        public async Task<IActionResult> Add(Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                vendorRepo.Add(vendor);
                await vendorRepo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(vendor);
        }
        #endregion

    }
}