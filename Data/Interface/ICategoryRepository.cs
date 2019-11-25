using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategory();
        Task<Category> GetCategoryByID(int ID);

        void Add(Category category);
        void Edit(Category category);
        void Delete(Category category);
        Task Save();
    }
}
