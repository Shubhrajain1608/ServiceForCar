using CarRentalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentalProject.ViewModel
{
    public class SearchBarViewModel
    {
        public ApplicationUser ApplicationUser { get; set; }
        public IEnumerable<ApplicationUser> ApplicationUsers { get; set; }
        public int? CheckInteger { get; set; }
    }
}