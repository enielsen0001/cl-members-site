using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(memberSite.Startup))]
namespace memberSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
