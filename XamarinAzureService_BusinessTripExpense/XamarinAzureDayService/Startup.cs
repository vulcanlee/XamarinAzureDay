using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(XamarinAzureDayService.Startup))]

namespace XamarinAzureDayService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}