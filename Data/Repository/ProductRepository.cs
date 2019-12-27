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
    public class ProductRepository : IProductRepository
    {

        private readonly POSDbContext cntx;

        public ProductRepository(POSDbContext pOSDbContext)
        {
            cntx = pOSDbContext;
        }


        public void Add(Product product)
        {
            cntx.tblproducts.Add(product);
        }

        public void Delete(Product product)
        {
            cntx.tblproducts.Remove(product);
        }

        public void Edit(Product product)
        {
            cntx.tblproducts.Update(product);
        }

        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            return await cntx.tblproducts.ToListAsync();
        }

        public async Task<Product> GetProductByID(int ID)
        {
            return await cntx.tblproducts.FindAsync(ID);
        }

        public async Task Save()
        {
            await cntx.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetProductWithCategory()
        {
            return await cntx.tblproducts.Include(x => x.Category).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductWithCategoryAndVendor()
        {
            return await cntx.tblproducts.Include(x => x.Category).Include(x => x.Vendor).ToListAsync();
        }
    }
}
