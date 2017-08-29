using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(housemaker.Startup))]
namespace housemaker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
