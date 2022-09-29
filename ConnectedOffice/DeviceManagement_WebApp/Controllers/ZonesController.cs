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
using Microsoft.AspNetCore.Authorization;

namespace DeviceManagement_WebApp.Controllers
{
    [Authorize]
    public class ZonesController : Controller
    {
        private readonly IZonesRepository _zoneRepository;
        public ZonesController(IZonesRepository zoneRepository)
        {
            _zoneRepository = zoneRepository;
        }
        // GET: Zone
        public IActionResult Create()
        {
            return View(new Zone());
        }
        [HttpPost]

        public ActionResult Create(Zone zone)
        {
            _zoneRepository.AddZone(zone);
            _zoneRepository.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]

        public ActionResult Update(Guid id)
        {
            return View(_zoneRepository.GetZoneById(id));
        }
        [HttpPost]
       

        public ActionResult Update(Zone zone)
        {
            _zoneRepository.UpdateZone(zone);
            _zoneRepository.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        //deletes a record 

        public ActionResult Delete(int id)
        {
            _zoneRepository.DeleteZone(id);
            _zoneRepository.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Zones 
        public async Task<IActionResult> Index()
        {
            var zone = _zoneRepository.GetAll();
            return View(zone);
        }

        //GET: Zones/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            Zone zone = _zoneRepository.GetZoneById(id);
            return View(zone);
        }
        // GET: Zones/Edit/5
        public ActionResult Edit(Guid id)
        {
            Zone zone = _zoneRepository.GetZoneById(id);
            if (id == null)
                return NotFound();
            return View(zone);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Zone zone)
        {
            var zonesRepository = _zoneRepository;
            _zoneRepository.UpdateZone(zone);
            _zoneRepository.SaveChanges();

            return RedirectToAction(nameof(Index));


        }

        // POST: Zone/Delete/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var zone = _zoneRepository.GetZoneById(id);
            _zoneRepository.Remove(zone);
            _zoneRepository.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


    }
}
