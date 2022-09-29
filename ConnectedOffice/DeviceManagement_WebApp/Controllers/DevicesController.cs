using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Repository;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DeviceManagement_WebApp.Controllers
{

    public class DevicesController : Controller
    {
        private readonly IDeviceRepository _deviceRepository;
        public DevicesController(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public async Task<IActionResult> Index()
        {
            var device = _deviceRepository.GetAll();
            return View(device);
        }

        public IActionResult Create()
        {
            return View(new Device());
        }
        [HttpPost]

        public ActionResult Create(Device device)
        {
            _deviceRepository.AddDevice(device);
            _deviceRepository.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]

        public ActionResult Update(Guid id)
        {
            return View(_deviceRepository.GetDeviceById(id));
        }
        [HttpPost]

        public ActionResult Update(Device device)
        {
            _deviceRepository.UpdateDevice(device);
            _deviceRepository.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            _deviceRepository.DeleteDevice(id);
            _deviceRepository.SaveChanges();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(Guid id)
        {
            Device device = _deviceRepository.GetDeviceById(id);
            return View(device);
        }

        // GET: Device/Edit/5
        public ActionResult Edit(Guid id)
        {
            Device device = _deviceRepository.GetDeviceById(id);
            if (id == null)
                return NotFound();
            return View(device);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Device device)
        {
            var deviceRepository = _deviceRepository;
            _deviceRepository.UpdateDevice(device);
            _deviceRepository.SaveChanges();

            return RedirectToAction(nameof(Index));


        }
        // POST: Device/Delete/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var device = _deviceRepository.GetDeviceById(id);
            _deviceRepository.Remove(device);
            _deviceRepository.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



       

    }
}
