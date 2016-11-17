using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JL.VendingMachines.Startup))]
namespace JL.VendingMachines
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
