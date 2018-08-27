using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RTU_WaterData.Startup))]
namespace RTU_WaterData
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
