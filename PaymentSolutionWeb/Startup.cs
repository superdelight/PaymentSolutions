using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PaymentSolutionWeb.Startup))]
namespace PaymentSolutionWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
