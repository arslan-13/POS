using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProduct();
        Task<Product> GetProductByID(int ID);

        void Add(Product product);
        void Edit(Product product);
        void Delete(Product product);
        Task Save();
    }
}
