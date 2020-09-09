using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(APPers.Startup))]
namespace APPers
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
