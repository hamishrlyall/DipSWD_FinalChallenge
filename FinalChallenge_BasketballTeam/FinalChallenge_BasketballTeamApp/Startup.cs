using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FinalChallenge_BasketballTeamApp.Startup))]
namespace FinalChallenge_BasketballTeamApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
