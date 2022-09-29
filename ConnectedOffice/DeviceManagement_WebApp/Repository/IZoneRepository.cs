using DeviceManagement_WebApp.Models;
using System;

namespace DeviceManagement_WebApp.Repository
{
    public interface IZonesRepository : IGenericRepository<Zone>
    {
        Zone GetMostRecentZones();
        void DeleteZone(int id);

        void UpdateZone(Zone zone);
        void AddZone(Zone zone);
    
        void SaveChanges();
        Zone GetZoneById(Guid? zoneId);
    }
}
