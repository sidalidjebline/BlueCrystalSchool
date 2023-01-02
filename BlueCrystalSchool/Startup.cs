using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlueCrystalSchool.Startup))]
namespace BlueCrystalSchool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
