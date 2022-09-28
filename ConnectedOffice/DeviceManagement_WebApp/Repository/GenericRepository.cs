using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using System.Linq;

namespace DeviceManagement_WebApp.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ConnectedOfficeContext _context;
        public GenericRepository(ConnectedOfficeContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
    }
}





    /*
    public DbSet<Category> Categories { get; set; }
    public DbSet<Device> Devices { get; set; }
    public DbSet<Zone> Zones { get; set; }
    /*


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
  */

