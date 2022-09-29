using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal.Account;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repository
{
    public class DeviceRepository : GenericRepository<Device>, IDeviceRepository
    {
        public DeviceRepository(ConnectedOfficeContext context) : base(context)
        {

        }


        public void AddDevice(Device device)
        {
            _context.Device.Add(device);
        }

        public Device DeleteDevice(int id)
        {
            return _context.Device.Find(id); ;
        }

        public Device GetDeviceById(Guid? deviceId)
        {
            return _context.Device.Find(deviceId);
        }

        public Device GetMostRecentDevices()
        {
            return _context.Device.OrderByDescending(Device => Device.DateCreated).FirstOrDefault();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void UpdateDevice(Device device)
        {
            _context.Entry(device).State = EntityState.Modified;
        }
        // there is an error here!!!!! remember to fix before submitting
        void IDeviceRepository.DeleteDevice(int id)
        {
            _context.Device.Find(id);
            _context.Remove(id);

        }

    }


}
