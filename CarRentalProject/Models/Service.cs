using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarRentalProject.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter miles")]
        public double Miles { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter price")]
        public double Price { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter Details")]
        public string Details { get; set; }


        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DateAdded { get; set; }

        public Car Car { get; set; }
        public int CarId { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "Enter ServiceType")]
        public ServiceType ServiceType { get; set; }
        public int ServiceTypeId { get; set; }
    }
}