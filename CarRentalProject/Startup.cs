using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarRentalProject.Startup))]
namespace CarRentalProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
