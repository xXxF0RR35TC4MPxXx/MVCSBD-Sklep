using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCSBD_Sklep.Startup))]
namespace MVCSBD_Sklep
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
