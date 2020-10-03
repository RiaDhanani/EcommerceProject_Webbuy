using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EcommerceProject_Webbuy.Startup))]
namespace EcommerceProject_Webbuy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
