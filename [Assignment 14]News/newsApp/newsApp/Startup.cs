using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(newsApp.Startup))]
namespace newsApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
