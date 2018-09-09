using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestTask.WebUI.Startup))]
namespace TestTask.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
