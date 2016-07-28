using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WimbledonWines.Startup))]
namespace WimbledonWines
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
