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
    public class ServiceTypeController : Controller
    {
        //ApplicationDbContext _context;

        //public ServiceTypeController()
        //{
        //    _context = new ApplicationDbContext();
        //}

        // GET: Customer
        public ActionResult Index()
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("ServiceTypes").Result;
            var servList = response.Content.ReadAsAsync<IEnumerable<ServiceType>>().Result;

            var viewModel = new ServiceTypeViewModel
            {
                ServiceTypes = servList
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddNewService(ServiceTypeViewModel serviceTypeViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", serviceTypeViewModel);
            }

            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("ServiceTypes", serviceTypeViewModel.ServiceType).Result;
            return RedirectToAction("Index", "ServiceType");
        }


        public ActionResult Delete(int? id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("ServiceTypes/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index","ServiceType");
        }

    }
}
