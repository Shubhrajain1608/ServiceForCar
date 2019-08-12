using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarRentalProject.Models
{
    public class ServiceType
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter Service Name")]
        public string Name { get; set; }
    }
}