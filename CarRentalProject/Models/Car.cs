using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarRentalProject.Models
{
    public class Car
    {

        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Provide VIN")]
        public string VIN { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Provide Make")]
        public string Make { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Provide Model")]
        public string Model { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Provide Style")]
        public string Style { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Provide Year")]
        public int Year { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Provide Miles")]
        public double Miles { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Provide Color")]
        public string Color { get; set; }

        [ForeignKey("UserId")]
       
        public ApplicationUser ApplicationUser{get;set; }
        public string UserId { get; set; }
    }
}