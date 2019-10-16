using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AchieveCollegeProject.Startup))]
namespace AchieveCollegeProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
