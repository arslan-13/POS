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
    public class VendorRepository : IVendorRepository
    {
        private readonly POSDbContext cntx;

        public VendorRepository(POSDbContext pOSDbContext)
        {
            cntx = pOSDbContext;
        }

        public void Add(Vendor vendor)
        {
            cntx.tblvendors.Add(vendor);
        }

        public void Delete(Vendor vendor)
        {
            cntx.tblvendors.Remove(vendor);
        }

        public void Edit(Vendor vendor)
        {
            cntx.tblvendors.Update(vendor);
        }

        public async Task<IEnumerable<Vendor>> GetAllVendors()
        {
            return await cntx.tblvendors.ToListAsync();
        }

        public async Task<Vendor> GetVendorByID(int ID)
        {
            return await cntx.tblvendors.FindAsync(ID);
        }

        public async Task Save()
        {
            await cntx.SaveChangesAsync();
        }
    }
}
