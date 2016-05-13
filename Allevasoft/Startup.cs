using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Allevasoft.Startup))]
namespace Allevasoft
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            //app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions
            //{
            //    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            //    LoginPath = new PathString("/Login")
            //});
            ConfigureAuth(app);
        }
    }
}
