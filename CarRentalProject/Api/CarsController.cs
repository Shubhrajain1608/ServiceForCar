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
    public class CarsController : ApiController
    {
        ApplicationDbContext _context;
        public CarsController()
        {
            _context = new ApplicationDbContext();
        }
        
        [HttpGet]
        public IEnumerable<Car> GetCars()
        {
            return _context.Cars.ToList();
        }

        [HttpGet]
        public IHttpActionResult GetCars(int? id)
        {
            Car car = _context.Cars.Find(id);
            return Ok(car);
        }

        [HttpPost]
        public IHttpActionResult PostCar(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
            return Ok(car);
        }

        [HttpPut]
        public IHttpActionResult PutCar(Car car)
        {
           
                var carInDb = _context.Cars.Find(car.Id);
                var applicationUser = _context.Users.Find(carInDb.UserId);
                carInDb.VIN = car.VIN;
                carInDb.Make = car.Make;
                carInDb.Model = car.Model;
                carInDb.Color = car.Color;
                carInDb.Year = car.Year;
                carInDb.Style = car.Style;
                carInDb.Miles = car.Miles;

                _context.SaveChanges();
           
            return Ok(car);
        }


        [HttpDelete]
        public IHttpActionResult DeleteCar(int id)
        {
            var car = _context.Cars.Find(id);
            _context.Cars.Remove(car);
            _context.SaveChanges();
            return Ok(car);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
