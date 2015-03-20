using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TotalSquash.Startup))]
namespace TotalSquash
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
