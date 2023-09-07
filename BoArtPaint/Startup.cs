using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BoArtPaint.Startup))]
namespace BoArtPaint
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
