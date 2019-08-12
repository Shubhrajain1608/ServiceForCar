using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarRentalProject.Models;

namespace CarRentalProject.ViewModel
{
    public class ServiceTypeViewModel
    {
        public ServiceType ServiceType { get; set; }

        public IEnumerable<ServiceType> ServiceTypes { get; set; }
    }
}