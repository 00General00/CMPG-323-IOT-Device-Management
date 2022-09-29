using DeviceManagement_WebApp.Models;
using System;

namespace DeviceManagement_WebApp.Repository
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Category GetMostRecentCategories();
        Category GetCategoryById(Guid? categoryId);
        void AddCategory(Category category);
        void SaveChanges();
        void UpdateCategory(Category category);
        void DeleteCategory(int id);
       


    }
}