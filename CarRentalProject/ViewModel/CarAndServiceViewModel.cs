using CarRentalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentalProject.ViewModel
{
    public class CarAndServiceViewModel
    {
        public Car Car { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public Service Service { get; set; }

        public IEnumerable<Service> Services { get; set; }

        public int CheckInteger { get; set; }

        public IEnumerable<ServiceType> ServiceType { get; set; }
    }
}