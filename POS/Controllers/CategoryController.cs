using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Interface;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace POS.Controllers
{
    public class CategoryController : Controller
    {

        #region Private Variable & Constructor
        private readonly ICategoryRepository cateRepo;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            cateRepo = categoryRepository;
        }

        #endregion

        #region Index
        public async Task<IActionResult> Index()
        {
            var cate = await cateRepo.GetAllCategory();
            return View(cate);
        }

        #endregion

        #region Add

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Category category)
        {
            if (ModelState.IsValid)
            {
                cateRepo.Add(category);
                await cateRepo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
        #endregion

        #region Edit
        public async Task<IActionResult> Edit(int ID)
        {
            var cate = await cateRepo.GetCategoryByID(ID);
            return View(cate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category category)
        {
            cateRepo.Edit(category);
            await cateRepo.Save();
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int ID)
        {
            var ven = await cateRepo.GetCategoryByID(ID);
            return View(ven);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConf(int ID)
        {
            var ven = await cateRepo.GetCategoryByID(ID);
            cateRepo.Delete(ven);
            await cateRepo.Save();
            return RedirectToAction(nameof(Index));
        }
        #endregion


    }
}