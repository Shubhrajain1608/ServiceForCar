using CarRentalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentalProject.ViewModel
{
    public class SingleCarViewModel
    {
        public Car Car { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}