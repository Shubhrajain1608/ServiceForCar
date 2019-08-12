using CarRentalProject.Models;
using CarRentalProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace CarRentalProject.Controllers
{
    public class CarController : Controller
    {
        ApplicationDbContext _context;

        public CarController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Car
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CarForm(ApplicationUser applicationUser)
        {
            var viewModel = new SingleCarViewModel
            {
                ApplicationUser = applicationUser
            };

            return View(viewModel);
        }

        [HttpPost]

        public ActionResult Save(SingleCarViewModel viewModel)
        {
            if (!ModelState.IsValid)

            {
                return View("CarForm", viewModel);
            }

            viewModel.Car.UserId = viewModel.ApplicationUser.Id;
            var car = viewModel.Car;
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Cars", car).Result;
            //_context.Cars.Add(car);
            //_context.SaveChanges();

            HttpResponseMessage response1 = GlobalVariables.WebApiClient.GetAsync("Customers/" + viewModel.ApplicationUser.Id.ToString()).Result;
            var applicationUser = response1.Content.ReadAsAsync<ApplicationUser>().Result;
            //var applicationUser = _context.Users.Find(viewModel.ApplicationUser.Id);

            return RedirectToAction("CustAndCarForm", "Customer", applicationUser);

        }

        public ActionResult EditForm(Car car)
        {
            HttpResponseMessage response1 = GlobalVariables.WebApiClient.GetAsync("Customers/" + car.UserId.ToString()).Result;
            var applicationUser = response1.Content.ReadAsAsync<ApplicationUser>().Result;
            //var applicationUser = _context.Users.Find(car.UserId);

            var viewModel = new SingleCarViewModel
            {
                Car = car,
                ApplicationUser = applicationUser
            };

            return View(viewModel);
        }

        [HttpPost]

        public ActionResult Edit(Car car)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new SingleCarViewModel
                {
                    Car = car
                };
                return View("EditForm", viewModel);
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Cars", car).Result;

                HttpResponseMessage response1 = GlobalVariables.WebApiClient.GetAsync("Customers/" + car.UserId.ToString()).Result;
                var applicationUser = response1.Content.ReadAsAsync<ApplicationUser>().Result;

                return RedirectToAction("CustAndCarForm", "Customer", applicationUser);
            }
        }

        public ActionResult Delete(Car car)
        {
            //HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Cars/" + id.ToString()).Result;
            //var car = response.Content.ReadAsAsync<Car>().Result;
            ////Car car = _context.Cars.Find(id);

            HttpResponseMessage response1 = GlobalVariables.WebApiClient.GetAsync("Customers/" + car.UserId.ToString()).Result;
            var applicationUser = response1.Content.ReadAsAsync<ApplicationUser>().Result;
            //var applicationUser = _context.Users.Find(car.UserId);

            HttpResponseMessage response2 = GlobalVariables.WebApiClient.DeleteAsync("Cars/" + car.Id.ToString()).Result; 
            //_context.Cars.Remove(car);
            //_context.SaveChanges();
            return RedirectToAction("CustAndCarForm", "Customer", applicationUser);
        }


        public ActionResult AddNewServices(Car car)
        {
            HttpResponseMessage response1 = GlobalVariables.WebApiClient.GetAsync("Service").Result;
            var services = response1.Content.ReadAsAsync<IEnumerable<Service>>().Result;
            List<Service> pastServices = new List<Service>();
            foreach (var v in services)
            {
                if(v.CarId == car.Id)
                {
                    pastServices.Add(v);
                    
                }
            }
            pastServices.Reverse();
            //var service = _context.Services.Where(c => c.CarId == car.Id).OrderByDescending(c => c.DateAdded).ToList();

            HttpResponseMessage response2 = GlobalVariables.WebApiClient.GetAsync("ServiceTypes").Result;
            var serviceType = response2.Content.ReadAsAsync<IEnumerable<ServiceType>>().Result;

            //List<ServiceType> serviceType = _context.ServiceTypes.ToList();

            var viewModel = new CarAndServiceViewModel
            {
                Car = car,
                Services = pastServices,
                ServiceType = serviceType
            };

            return View(viewModel);
        }


        [HttpPost]
        public ActionResult AddServices(CarAndServiceViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.Service.DateAdded = DateTime.Today;
                viewModel.Service.CarId = viewModel.Car.Id;


                HttpResponseMessage response1 = GlobalVariables.WebApiClient.GetAsync("Cars/" + viewModel.Car.Id).Result;
                var car = response1.Content.ReadAsAsync<Car>().Result;
                //var car = _context.Cars.Find(viewModel.Car.Id);

                HttpResponseMessage response2 = GlobalVariables.WebApiClient.PostAsJsonAsync("Service/", viewModel.Service).Result;
                
                //_context.Services.Add(viewModel.Service);
                //_context.SaveChanges();

                return RedirectToAction("AddNewServices", "Car", car);
            }

            viewModel.Car = _context.Cars.Find(viewModel.Car.Id);
            viewModel.Services = _context.Services.Where(c => c.CarId == viewModel.Car.Id).OrderByDescending(c => c.DateAdded).ToList();

            viewModel.ServiceType = _context.ServiceTypes.ToList();

            return View("AddNewServices", viewModel);

        }

        public ActionResult Delete1(Service service)
        {
          
            HttpResponseMessage response2 = GlobalVariables.WebApiClient.GetAsync("Service/" + service.Id).Result;
            var service1 = response2.Content.ReadAsAsync<Service>().Result;

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Cars/" + service1.CarId.ToString()).Result;
            var car = response.Content.ReadAsAsync<Car>().Result;

            //var car = _context.Cars.Find(service.CarId);

            HttpResponseMessage response1 = GlobalVariables.WebApiClient.DeleteAsync("Service/" + service.Id).Result;
            //Service service = _context.Services.Find(id);

            //_context.Services.Remove(service);
            //_context.SaveChanges();
            return RedirectToAction("AddNewServices", car);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        //public ActionResult ShowLessServiceForm(Car car)
        //{
        //    var service = _context.Services.Where(c => c.CarId == car.Id).OrderByDescending(c => c.DateAdded).ToList();
        //    var serviceList = new List<Service>();
        //    int i = 0;

        //    foreach (var item in service)
        //    {
        //        i++;
        //        if (i <= 5)
        //        {
        //            serviceList.Add(item);
        //        }
        //    }

        //    var viewModel = new CarAndServiceViewModel
        //    {
        //        Car = car,
        //        Services = serviceList,
        //        CheckInteger = i,
        //        ServiceType = _context.ServiceTypes.ToList()
        //    };

        //    return View(viewModel);
        //}
    }
}