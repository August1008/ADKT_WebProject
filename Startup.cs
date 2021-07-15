using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ADKT_WebProject.Startup))]
namespace ADKT_WebProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
