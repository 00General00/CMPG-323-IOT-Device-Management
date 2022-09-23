using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using DeviceManagement_WebApp.Models;

namespace DeviceManagement_WebApp.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
        void Remove(T Category);
        void Add(T Category);

        IEnumerable<T> GetAll();

        //existing
        Category Update(Category category);

        void AddRange(IEnumerable<T> entities);
        
        void RemoveRange(IEnumerable<T> entities);
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
    }

}
