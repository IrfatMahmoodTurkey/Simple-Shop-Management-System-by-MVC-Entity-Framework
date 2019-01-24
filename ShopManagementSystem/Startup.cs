using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShopManagementSystem.Startup))]
namespace ShopManagementSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
