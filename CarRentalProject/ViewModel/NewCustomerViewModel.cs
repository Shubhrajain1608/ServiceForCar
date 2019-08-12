using CarRentalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentalProject.ViewModel
{
    public class NewCustomerViewModel
    {
        public IEnumerable<Car> Cars { get; set; }

        public ApplicationUser ApplicationUser  { get; set; }

    }
}