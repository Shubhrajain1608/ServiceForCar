using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CarRentalProject.Models;

namespace CarRentalProject.Api
{
    public class ServiceTypesController : ApiController
    {

        private ApplicationDbContext _context;

        public ServiceTypesController ()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<ServiceType> GetServices()
        {
            return _context.ServiceTypes.ToList();
        }

        public ServiceType GetServiceById(int? id)
        {
            return _context.ServiceTypes.SingleOrDefault(c => c.Id == id);
        }


        [HttpPost]
        public void AddNewService(ServiceType serviceType)
        {
           _context.ServiceTypes.Add(serviceType);
           _context.SaveChanges();
        }


        [HttpDelete]
        public void DeleteServiceType(int? id)
        {
            var ServiceTypeInDb = _context.ServiceTypes.SingleOrDefault(c => c.Id == id);
            if (ServiceTypeInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.ServiceTypes.Remove(ServiceTypeInDb);
            _context.SaveChanges();
        }

      
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

    }
}
