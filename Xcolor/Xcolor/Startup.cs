using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Xcolor.Startup))]
namespace Xcolor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
