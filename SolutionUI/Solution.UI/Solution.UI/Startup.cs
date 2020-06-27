using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Solution.UI.Startup))]
namespace Solution.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
