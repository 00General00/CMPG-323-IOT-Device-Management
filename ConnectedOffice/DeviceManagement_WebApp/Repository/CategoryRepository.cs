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
        public IEnumerable<Category> GetId()
        {
            return _connectedOfficeContext.Category.ToList();

        }
        // TO DO: Add ‘Create’
        // TO DO: Add ‘Edit’
        // TO DO: Add ‘Delete’
        // TO DO: Add ‘Exists’


    }
}
