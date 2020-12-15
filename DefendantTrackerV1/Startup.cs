using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DefendantTrackerV1.Startup))]
namespace DefendantTrackerV1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
