using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EventHub.Startup))]
namespace EventHub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
