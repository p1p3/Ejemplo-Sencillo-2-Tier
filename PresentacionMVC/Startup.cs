using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PresentacionMVC.Startup))]
namespace PresentacionMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
