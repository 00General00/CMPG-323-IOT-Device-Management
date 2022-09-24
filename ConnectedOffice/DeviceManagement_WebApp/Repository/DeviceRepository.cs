using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Repository;
using Microsoft.EntityFrameworkCore;
//using System.Web.Services.Discription;

namespace DeviceManagement_WebApp.Repository
{
    public class DeviceRepository : GenericRepository<Service>, IGenericRepository
    {
        public DeviceRepository(ConnectedOfficeContext _connectedOfficeContext) : base(_connectedOfficeContext)
        {

        }

        public Service GetMostRecentService()
        {
            return _connectedOfficeContext.Service.OrderByDescending(service => service.CreatedDate).FirstOrDefault();
        }
    }

}
   




