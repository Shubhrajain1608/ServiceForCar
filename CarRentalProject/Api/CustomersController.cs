using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CarRentalProject.Models;

namespace CarRentalProject.Api
{
    public class CustomersController : ApiController
    {

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }


        // GET api/Customer
        public IEnumerable<ApplicationUser> GetApplicationUser()
        {
            return _context.Users.ToList();
        }

        // GET api/Customer/1
        [ResponseType(typeof(ApplicationUser))]
        public IHttpActionResult GetCustomer(string id)
        {
            ApplicationUser applicationUser = _context.Users.Find(id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            return Ok(applicationUser);
        }

        //POST api/Customer
        //[ResponseType(typeof(ApplicationUser))]

        [HttpPost]
        public IHttpActionResult PostCustomer(ApplicationUser applicationUser)
        {
          
             // throw new HttpResponseException(HttpStatusCode.BadRequest);
      
            _context.Users.Add(applicationUser);
            _context.SaveChanges();
            return Ok(applicationUser);

            // return CreatedAtRoute("Customer", new { id = applicationUser.Id }, applicationUser);
        }


        // PUT api/Customer
        [HttpPut]
        public IHttpActionResult PutCustomer(ApplicationUser applicationUser)
        {

            if (applicationUser.Id==null)
            {
                return BadRequest();
            }

            try
            {
                var user = _context.Users.Find(applicationUser.Id);
                user.FirstName = applicationUser.FirstName;
                user.LastName = applicationUser.LastName;
                user.Email = applicationUser.Email;
                user.PhoneNumber = applicationUser.PhoneNumber;                                
                user.City = applicationUser.City;
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (ApplicationUserExists(applicationUser.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE api/Customer
      
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(string id)
        {
            var applicationUser = _context.Users.Find(id);
            if (applicationUser == null)
            {
                return NotFound();
            }
            _context.Users.Remove(applicationUser);
            _context.SaveChanges();

            return Ok(applicationUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ApplicationUserExists(string id)
        {
            return _context.Users.Count(c => c.Id.Equals(id)) > 0;
        }    
    }
}
