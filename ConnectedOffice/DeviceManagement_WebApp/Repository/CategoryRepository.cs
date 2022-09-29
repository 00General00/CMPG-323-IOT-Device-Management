using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private ConnectedOfficeContext _connectedOfficeContext;

        public CategoryRepository(ConnectedOfficeContext _connectedOfficeContext) : base(_connectedOfficeContext)
        {

        }

        public async Task<Category> DeleteCategory(int id)
        {
            Category category = _connectedOfficeContext.Category.Find(id);
            _connectedOfficeContext.Category.Remove(category);

            return _context.Category.Find(id);
        }

        public void AddCategory(Category category)
        {
            _context.Category.Add(category);
        }

        public Category GetMostRecentCategories()
        {
            return _context.Category.OrderByDescending(Category => Category.DateCreated).FirstOrDefault();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
        }


        void ICategoryRepository.DeleteCategory(int id)
        {
            _context.Category.Find(id);
            _context.Remove(id);

        }

        public Category GetCategoryById(Guid? categoryId)
        {

            return _context.Category.Find(categoryId);

        }
    }
}