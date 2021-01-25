using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Library_MVC.Startup))]
namespace Library_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
