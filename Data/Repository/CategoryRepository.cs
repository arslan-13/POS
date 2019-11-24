using Data.Interface;
using DataBase;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly POSDbContext cntx;

        public CategoryRepository(POSDbContext pOSDbContext)
        {
            cntx = pOSDbContext;
        }

        public void Add(Category category)
        {
            cntx.tblcategories.Add(category);
        }

        public void Delete(Category category)
        {
            cntx.tblcategories.Remove(category);
        }

        public void Edit(Category category)
        {
            cntx.tblcategories.Update(category);
        }

        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            return await cntx.tblcategories.ToListAsync();
        }

        public async Task<Category> GetVendorByID(int ID)
        {
            return await cntx.tblcategories.FindAsync(ID);
        }

        public async Task Save()
        {
            await cntx.SaveChangesAsync();
        }
    }
}
