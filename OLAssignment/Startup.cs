using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OLAssignment.Startup))]
namespace OLAssignment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
