using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface IVendorRepository
    {
        Task<IEnumerable<Vendor>> GetAllVendors();
        Task<Vendor> GetVendorByID(int ID);

        void Add(Vendor vendor);
        void Edit(Vendor vendor);
        void Delete(Vendor vendor);
        Task Save();
    }
}
