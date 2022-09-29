using DeviceManagement_WebApp.Models;
using System;
using System.Collections;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repository
{
    public interface IDeviceRepository : IGenericRepository<Device>
    {

        Device GetMostRecentDevices();


        void AddDevice(Device device);
        void UpdateDevice(Device device);
        void DeleteDevice(int id);
        void SaveChanges();

        Device GetDeviceById(Guid? deviceId);




    }



}
