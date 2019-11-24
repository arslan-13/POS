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

        [HttpPost]
        [ValidateAntiForgeryToken]
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

        #region Edit
        public async Task<IActionResult> Edit(int ID)
        {
            var vendor = await vendorRepo.GetVendorByID(ID);
            return View(vendor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Vendor vendor)
        {
            vendorRepo.Edit(vendor);
            await vendorRepo.Save();
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int ID)
        {
            var ven = await vendorRepo.GetVendorByID(ID);
            return View(ven);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConf(int ID)
        {
            var ven = await vendorRepo.GetVendorByID(ID);
            vendorRepo.Delete(ven);
            await vendorRepo.Save();
            return RedirectToAction(nameof(Index));
        }
        #endregion


    }
}