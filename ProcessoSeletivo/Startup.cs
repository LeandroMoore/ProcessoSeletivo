using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProcessoSeletivo.Startup))]
namespace ProcessoSeletivo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
