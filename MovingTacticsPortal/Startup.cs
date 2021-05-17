using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovingTacticsPortal.Startup))]
namespace MovingTacticsPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
