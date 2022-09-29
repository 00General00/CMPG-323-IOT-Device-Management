using DeviceManagement_WebApp.Models;
using System;

namespace DeviceManagement_WebApp.Repository
{
    public interface IZonesRepository : IGenericRepository<Zone>
    {
        Zone GetMostRecentZones();
        // the following methods are defined to be used in the zones controller 
        Zone GetZoneById(Guid? zoneId);

        void AddZone(Zone zone);
        void UpdateZone(Zone zone);
        void DeleteZone(int id);
        void SaveChanges();

    }
}
