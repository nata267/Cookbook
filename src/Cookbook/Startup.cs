using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cookbook.Startup))]
namespace Cookbook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
