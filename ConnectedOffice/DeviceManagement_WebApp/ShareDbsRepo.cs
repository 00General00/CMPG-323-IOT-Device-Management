using System;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Repository;

namespace DeviceManagement_WebApp
{
    public class ShareDbsRepo
    {
        private ConnectedOfficeContext context = new ConnectedOfficeContext();

        private GenericRepository<Category> categoryRepository;
        private GenericRepository<Device> deviceRepository;
        private GenericRepository<Zone> zoneRepository;

        public GenericRepository<Category> CategoryRepository
        {
            get
            {

                if (this.categoryRepository == null)
                {
                    this.categoryRepository = new GenericRepository<Category>(context);
                }
                return categoryRepository;
            }
        }

        public GenericRepository<Zone> ZoneRepository
        {
            get
            {

                if (this.zoneRepository == null)
                {
                    this.zoneRepository = new GenericRepository<Zone>(context);
                }
                return zoneRepository;
            }
        }    
        public GenericRepository<Zone> DeviceRepository
        {
            get
            {

                if (this.deviceRepository == null)
                {
                    this.deviceRepository = new GenericRepository<Device>(context);
                }
                return zoneRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

    }
}
