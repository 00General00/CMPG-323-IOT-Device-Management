using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repository
{
    public class ZonesRepository : GenericRepository<Zone>, IZonesRepository
    {
        public ZonesRepository(ConnectedOfficeContext context) : base(context)
        {
        }
        public Zone GetZoneById(Guid? zoneId)
        {
            return _context.Zone.Find(zoneId);
        }

        public void AddZone(Zone zone)
        {
            _context.Zone.Add(zone);
        }


        public Zone DeleteZone(int id)
        {
            return _context.Zone.Find(id);
        }

        public Zone GetMostRecentZones()
        {
            return _context.Zone.OrderByDescending(Zone => Zone.DateCreated).FirstOrDefault();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void UpdateZone(Zone zone)
        {
            _context.Entry(zone).State = EntityState.Modified;
        }

      //fix
        void IZonesRepository.DeleteZone(int id)
        {
            _context.Device.Find(id);
            _context.Remove(id);

        }


    }
}
