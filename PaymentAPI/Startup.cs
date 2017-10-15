using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PaymentAPI.Startup))]
namespace PaymentAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
