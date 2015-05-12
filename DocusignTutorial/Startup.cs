using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DocusignTutorial.Startup))]
namespace DocusignTutorial
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
