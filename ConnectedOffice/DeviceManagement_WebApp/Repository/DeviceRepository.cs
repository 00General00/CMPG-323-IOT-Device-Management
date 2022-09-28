using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
//using System.Web.Services.Discription;

namespace DeviceManagement_WebApp.Repository
{
    public class DeviceRepository : GenericRepository<Device>,IDeviceRepository
    {

        private readonly IDeviceRepository _repository;
        public DeviceRepository(ConnectedOfficeContext _connectedOfficeContext) : base(_connectedOfficeContext)
        {

        }

        public Device GetMostRecentService()
        {
            return _context.Device.OrderByDescending(Device => Device.DateCreated).FirstOrDefault();
        }
    }

}
   




