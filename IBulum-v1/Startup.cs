using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IBulum_v1.Startup))]
namespace IBulum_v1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
