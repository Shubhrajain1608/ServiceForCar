using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarRentalProject.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is Mandatory")]
        [StringLength(20,MinimumLength = 3, ErrorMessage = "First Name Should be min 3 and max 20")]
        [RegularExpression(@"^([A-Za-z]+)", ErrorMessage = "Enter valid First Name")]


        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name is Mandatory")]
        [RegularExpression(@"^([A-Za-z]+)", ErrorMessage = "Enter valid Last Name")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Last Name Should be min 3 and max 20")]
        
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone Number is needed")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Invalid Phone number")]

        public double PhoneNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please Provide Valid Email")]

        public string Email { get; set; }

    }
}