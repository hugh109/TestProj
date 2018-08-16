using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAp.Startup))]
namespace WebAp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
