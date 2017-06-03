using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NovoChamado.Startup))]
namespace NovoChamado
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
