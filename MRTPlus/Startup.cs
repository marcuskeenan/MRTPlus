using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MRTPlus.Startup))]
namespace MRTPlus
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
