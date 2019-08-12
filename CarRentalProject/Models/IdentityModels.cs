using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CarRentalProject.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is Mandatory")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "First Name Should be min 3 and max 20")]
        [RegularExpression(@"^([A-Za-z]+)", ErrorMessage = "Enter valid First Name")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name is Mandatory")]
        [RegularExpression(@"^([A-Za-z]+)", ErrorMessage = "Enter valid Last Name")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Last Name Should be min 3 and max 20")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone Number is Mandatory")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Invalid Phone Number")]
        public override string PhoneNumber { get => base.PhoneNumber; set => base.PhoneNumber = value; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please Provide vaild Email")]
        public override string Email { get => base.Email; set => base.Email = value; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "City Name is Mandatory")]
        [RegularExpression(@"^([A-Za-z]+)", ErrorMessage = "Enter valid City Name")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "City Name Should be min 3 and max 20")]
        public string City { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Car> Cars { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<ServiceType> ServiceTypes { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}