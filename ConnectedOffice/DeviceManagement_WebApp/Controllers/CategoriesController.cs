using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components;
using System.Data;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Repository;
using DeviceManagement_WebApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace DeviceManagement_WebApp.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IActionResult Create()
        {
            return View(new Category());
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            _categoryRepository.AddCategory(category);
            _categoryRepository.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(Guid id)
        {
            return View(_categoryRepository.GetCategoryById(id));
        }
        [HttpPost]
        public ActionResult Update(Category category)
        {
            _categoryRepository.UpdateCategory(category);
            _categoryRepository.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        // GET: Categories/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var category = _categoryRepository.GetCategoryById(id);
            _categoryRepository.Remove(category);
            _categoryRepository.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: Category 
        public async Task<IActionResult> Index()
        {
            var zone = _categoryRepository.GetAll();
            return View(zone);
        }

        //GET: Category/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            Category category = _categoryRepository.GetCategoryById(id);
            return View(category);
        }

        // GET: Category/Edit/5
        public ActionResult Edit(Guid id)
        {
            Category category = _categoryRepository.GetCategoryById(id);
            if (id == null)
                return NotFound();
            return View(category);

        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            var categoryRepository = _categoryRepository;
            _categoryRepository.UpdateCategory(category);
            _categoryRepository.SaveChanges();

            return RedirectToAction(nameof(Index));


        }




    }
}
