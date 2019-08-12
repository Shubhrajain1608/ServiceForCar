using CarRentalProject.Models;
using CarRentalProject.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace CarRentalProject.Controllers
{
    public class CustomerController : Controller
    {
        ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }


        // GET: Customer
        //public ActionResult Index()
        //{
        //    HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Customers").Result;
        //    var userList = response.Content.ReadAsAsync<IEnumerable<ApplicationUser>>().Result;
        //    return View(userList);
        //}

        public ActionResult Index(string search = "", string option = "")
        {
            if (search.Equals(""))
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Customers").Result;
                var userList = response.Content.ReadAsAsync<IEnumerable<ApplicationUser>>().Result;
                var viewModel = new SearchBarViewModel
                {
                    ApplicationUsers = userList
                };
                return View(viewModel);
            }
            else
            {
                if (option.Equals("Email"))
                {
                    var users = _context.Users.Where(c => c.Email.Equals(search)).ToList();
                    var viewModel = new SearchBarViewModel
                    {
                        ApplicationUsers = users
                    };
                    return View(viewModel);
                }

                else if (option.Equals("PhoneNumber"))
                {
                    //try
                    //{
                        //var searchMobile = Convert.ToDouble(search);
                        var users = _context.Users.Where(c => c.PhoneNumber.Equals(search)).ToList();
                        var viewModel = new SearchBarViewModel
                        {
                            ApplicationUsers = users
                        };
                        return View(viewModel);
                    //}
                    //catch
                    //{
                    //    var users = _context.Users.ToList();
                    //    var viewModel = new SearchBarViewModel
                    //    {
                    //        ApplicationUsers = users,
                    //        CheckInteger = 1
                    //    };
                    //    return View(viewModel);

                    //}
                }

                else
                {
                    var users = _context.Users.Where(c => c.FirstName.Equals(search)).ToList();
                    var viewModel = new SearchBarViewModel
                    {
                        ApplicationUsers = users
                    };
                    return View(viewModel);
                }
            }
        }


        //[Authorize(Roles = Role.Admin)]
        public ActionResult CustForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(ApplicationUser applicationUser)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Customers", applicationUser).Result;
            TempData["SuccessMessage"] = "Saved Successfully";

            return RedirectToAction("Index", applicationUser);
        }


        public ActionResult Edit(ApplicationUser applicationUser)
        {
            //HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Customers/" + id.ToString()).Result;
            //var user = response.Content.ReadAsAsync<ApplicationUser>().Result;
            ////var user = _context.Users.Find(id);

            return View(applicationUser);
        }

        //[HttpPost]
        public ActionResult EditSave(ApplicationUser applicationUser)
        {

            HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Customers", applicationUser).Result;
            TempData["SuccessMessage"] = "Updated Successfully";

            return RedirectToAction("Index", applicationUser);
        }


        public ActionResult Delete(ApplicationUser applicationUser)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Customers/" + applicationUser.Id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");

            //using(var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("http://localhost:51313/api/");
            //    var deleteTask = client.DeleteAsync("Customers/" + applicationUser.Id.ToString());
            //    deleteTask.Wait();
            //    var result = deleteTask.Result;
            //    if (result.IsSuccessStatusCode)
            //    {
            //        return RedirectToAction("Index");
            //    }
            //}
            //return RedirectToAction("Index");
        }


        public ActionResult CustAndCarForm1(ApplicationUser applicationUser)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Cars").Result;
            var cars = response.Content.ReadAsAsync<IEnumerable<Car>>().Result;
            //var cars = _context.Cars.ToList();
            HttpResponseMessage response1 = GlobalVariables.WebApiClient.GetAsync("Customers/" + User.Identity.GetUserId().ToString()).Result;
            var users = response1.Content.ReadAsAsync<ApplicationUser>().Result;
            //var users = _context.Users.Find(User.Identity.GetUserId());

            var viewModel = new NewCustomerViewModel
            {
                ApplicationUser = users,
                Cars = cars
            };
            return View("CustAndCarForm", viewModel);
        }

        public ActionResult CustAndCarForm(ApplicationUser applicationUser)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Cars").Result;
            var cars = response.Content.ReadAsAsync<IEnumerable<Car>>().Result;
            //var cars = _context.Cars.ToList();
            HttpResponseMessage response1 = GlobalVariables.WebApiClient.GetAsync("Customers/" + applicationUser.Id.ToString()).Result;
            var users = response1.Content.ReadAsAsync<ApplicationUser>().Result;
            //var users = _context.Users.Find(applicationUser.Id);

            var viewModel = new NewCustomerViewModel
            {
                ApplicationUser = users,
                Cars = cars
            };
            return View(viewModel);
        }
    }
}


/*
public ActionResult CustForm()
{
    return View(applicationUser);
}

[HttpPost]

public ActionResult Save(SingleCarViewModel viewModel)
{
    if (!ModelState.IsValid)

    {
        return View("CarForm", viewModel);
    }

    viewModel.Car.UserId = viewModel.ApplicationUser.Id;
    var applicationUser = _context.Users.Find(viewModel.ApplicationUser.Id);
    var car = viewModel.Car;
    _context.Cars.Add(car);
    _context.SaveChanges();

    return RedirectToAction("CustAndCarForm", "Customer", applicationUser);

}*/

//[HttpPost]
//public ActionResult Save(int id = 0)
//{
//    if (id == 0)
//        return View(new Customer());
//    else
//    {
//        HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Customers/" + id.ToString()).Result;
//        return View(response.Content.ReadAsAsync<Customer>().Result);
//    }
//}

//[HttpPost]

//public ActionResult Save(Customer customer)
//{
//    if (!ModelState.IsValid)
//    {
//        var viewModel = new NewCustomerViewModel
//        {
//            Customer = customer

//        };
//        return View("CustForm", viewModel);
//    }
//    if (customer.Id == 0)
//        _context.Customers.Add(customer);
//    else
//    {
//        var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
//        customerInDb.FirstName = customer.FirstName;
//        customerInDb.LastName  = customer.LastName;
//        customerInDb.PhoneNumber = customer.PhoneNumber;
//        customerInDb.Email = customer.Email;
//    }
//    _context.SaveChanges();
//    return RedirectToAction("Index", "Customer");
//}


//    [Authorize(Roles = Role.Admin)]

//    public ActionResult Delete(int id)
//    {
//        Customer customer = _context.Customers.Find(id);
//        _context.Customers.Remove(customer);
//        _context.SaveChanges();
//        return RedirectToAction("Index");
//    }

//    public ActionResult CustAndCarForm(Customer customer)
//    {
//        var cars = _context.Cars.ToList();
//        var cust = _context.Customers.Find(customer.Id);
//        var viewModel = new NewCustomerViewModel
//        {
//            Customer = cust,
//            Cars = cars
//        };
//        return View(viewModel);
//    }

//    protected override void Dispose(bool disposing)
//    {
//        _context.Dispose();
//    }

//}
//}



//<script>
//$(document).ready(function(){
//  $("#myInput").on("keyup", function() {
//            var value = $(this).val().toLowerCase();
//    $("#myTable tr").filter(function() {
//      $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
//    });
//        });
//    });
//</script>
