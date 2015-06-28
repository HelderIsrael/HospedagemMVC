using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HospedagemMVC.Startup))]
namespace HospedagemMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
