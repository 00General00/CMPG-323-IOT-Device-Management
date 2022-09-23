using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DeviceManagement_WebApp.Repository
{
    public class CategoryRepository
    {
        protected readonly ConnectedOfficeContext _connectedOfficeContext = new ConnectedOfficeContext();


        // GET ALL: Category
        public IEnumerable<Category> GetAll()
        {
            return _connectedOfficeContext.Category.ToList();

        }
        // TO DO: Add ‘Get By Id’
        public IEnumerable<Category> GetById(int id)
        {
            return _connectedOfficeContext.Category.ToList();

        }
        // TO DO: Add ‘Create’ (CategoryName)
        public void Add(Category category)
        {
            _connectedOfficeContext.Category.Add(category);

            

        }
        // TO DO: Add ‘Edit’
        public IEnumerable<Category> Edit()
        {
            return _connectedOfficeContext.Category.ToList();

        }
        // TO DO: Add ‘Delete’
        public void Remove(Category category)
        {
            _connectedOfficeContext.Category.Remove(category);

        }
        // TO DO: Add ‘Exists’
        public Category Update(Category category)
        {
            _connectedOfficeContext.Category.Update(category);

            return category;

        }

    }
}
