using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyMedicalGuide.Web.Startup))]
namespace MyMedicalGuide.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
