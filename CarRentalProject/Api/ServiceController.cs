using CarRentalProject.Models;
using CarRentalProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarRentalProject.Api
{
    public class ServiceController : ApiController
    {
        ApplicationDbContext _context;
        public ServiceController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IEnumerable<Service> GetServices()
        {
            return _context.Services.ToList();
        }

        [HttpGet]
        public IHttpActionResult GetServices(int? id)
        {
            var service = _context.Services.Find(id);
            return Ok(service);
        }

        [HttpPost]
        public IHttpActionResult PostServices(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteServices(int id)
        {
            Service service = _context.Services.Find(id);
            _context.Services.Remove(service);
            _context.SaveChanges();
            return Ok();     
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}
