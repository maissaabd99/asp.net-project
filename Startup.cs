using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System.Web.Services.Description;
using testest.Models;

[assembly: OwinStartupAttribute(typeof(testest.Startup))]
namespace testest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.CreatePerOwinContext(ApplicationDbContext.Create); 
        }
        
    }
}
