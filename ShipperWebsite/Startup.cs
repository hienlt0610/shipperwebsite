using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShipperWebsite.Startup))]
namespace ShipperWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
